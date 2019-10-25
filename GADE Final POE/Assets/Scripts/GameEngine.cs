using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

class GameEngine
{
    public static System.Random random = new System.Random();

    const string UNITS_FILENAME = "units.txt";
    const string BUILDINGS_FILENAME = "buildings.txt";
    const string ROUND_FILENAME = "rounds.txt";

    Map map;
    bool isGameOver = false;
    string winningFaction = "";
    int round = 0;

    public GameEngine(int width, int height)
    {
        //map = new Map(10, 10);
        map = new Map(10, 10, width, height);
    }

    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    public string WinningFaction
    {
        get { return winningFaction; }
    }

    public int Round
    {
        get { return round; }
    }

    public void GameLoop()
    {
        UpdateUnits();
        UpdateBuildings();
        map.UpdateMap();
        round++;
    }

    void UpdateBuildings()
    {
        foreach (Building building in map.Buildings)
        {
            if (building is FactoryBuilding)
            {
                FactoryBuilding factoryBuilding = (FactoryBuilding)building;

                if (round % factoryBuilding.ProductionSpeed == 0)
                {
                    Unit newUnit = factoryBuilding.SpawnUnit();
                    map.AddUnit(newUnit);
                }
            }

            else if (building is ResourceBuilding)
            {
                ResourceBuilding resourceBuilding = (ResourceBuilding)building;
                resourceBuilding.GenerateResources();

            }

        }
    }


    void UpdateUnits()
    {
        foreach (Unit unit in map.Units)
        {
            //ignore this unit if it is destroyed 
            if (unit.IsDestroyed)
            {
                continue;
            }


            Unit closestUnit = unit.GetClosestUnit(map.Units);
            Building closestBuilding = unit.GetClosestBuilding(map.Buildings);
            if (closestUnit == null)
            {
                //if a unit has not target it means the game has ended 
                isGameOver = true;
                winningFaction = unit.Faction;
                map.UpdateMap();
                return;
            }

            double healthPercentage = unit.Health / unit.MaxHealth;

            if (unit.Faction == "N-Team" && healthPercentage <= 0.5)
            {
                unit.RunAway();
            }
            else if (healthPercentage <= 0.25)
            {
                unit.RunAway();
            }

            else if (unit.Faction == "N-Team")
            {
                foreach (Unit otherUnit in map.Units)
                {
                    if (unit.IslnRange(otherUnit))
                    {
                        unit.Attack(otherUnit);
                        Debug.Log(unit.Name + " " + unit.X + " " + unit.Y + " is attacking " + otherUnit);
                    }
                }

            }

            else if (GetDistance(closestUnit, unit) > GetDistance(closestBuilding, unit))
            {
                if (unit.IslnRange(closestBuilding))
                {
                    unit.Attack(closestBuilding);
                }
                else if (unit.IslnRange(closestUnit))
                {
                    unit.Attack(closestUnit);
                }
                else
                {
                    unit.Move(closestUnit);
                }
            }

            else
            {
                if (unit.IslnRange(closestUnit))
                {
                    unit.Attack(closestUnit);
                }
                else if (unit.IslnRange(closestBuilding))
                {
                    unit.Attack(closestBuilding);
                }
                else
                {
                    unit.Move(closestUnit);
                }
            }


            StaylnBounds(unit, map.Size);
        }

    }

    private double GetDistance(Unit otherUnit, Unit currentUnit)
    {
        double xDistance = otherUnit.X - currentUnit.X;
        double yDistance = otherUnit.Y - currentUnit.Y;
        return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
    }

    private double GetDistance(Building otherBuilding, Unit currentUnit)
    {
        double xDistance = otherBuilding.X - currentUnit.X;
        double yDistance = otherBuilding.Y - currentUnit.Y;
        return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
    }

    private void StaylnBounds(Unit unit, int size)
    {
        if (unit.X < 0)
        {
            unit.X = 0;
        }

        else if (unit.X >= size)
        {
            unit.X = size - 1;
        }


        if (unit.Y < 0)
        {
            unit.Y = 0;
        }

        else if (unit.Y >= size)
        {
            unit.Y = size - 1;
        }
    }

    public int NumUnits
    {
        get { return map.Units.Length; }
    }

    public int NumBuildings
    {
        get { return map.Buildings.Length; }
    }

    public string MapDisplay
    {
        get { return map.GetMapDisplay(); }
    }

    public string GetUnitInfo()
    {
        string unitlnfo = "";
        foreach (Unit unit in map.Units)
        {
            unitlnfo += unit + Environment.NewLine;
        }
        return unitlnfo;
    }

    public string GetBuildingsInfo()
    {
        string buildingslnfo = "";
        foreach (Building building in map.Buildings)
        {
            buildingslnfo += building + Environment.NewLine;
        }
        return buildingslnfo;
    }

    public void Reset()
    {
        map.Reset();
        isGameOver = false;
        round = 0;
    }

    //public void SaveGame()
    //{
    //    Save(UNITS_FILENAME, map.Units);
    //    Save(BUILDINGS_FILENAME, map.Buildings);
    //    SaveRound();
    //}

    public void LoadGame()
    {
        map.Clear();
        Load(UNITS_FILENAME);
        Load(BUILDINGS_FILENAME);
        LoadRound();
        map.UpdateMap();
    }

    private void Load(string filename)
    {
        FileStream inFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(inFile);

        string recordln;
        recordln = reader.ReadLine();
        while (recordln != null)
        {
            int length = recordln.IndexOf(",");
            string firstField = recordln.Substring(0, length);
            switch (firstField)
            {
                case "Melee": map.AddUnit(new MeleeUnit(recordln)); break;
                case "Ranged": map.AddUnit(new RangedUnit(recordln)); break;
                case "Factory": map.AddBuilding(new FactoryBuilding(recordln)); break;
                case "Resource": map.AddBuilding(new ResourceBuilding(recordln)); break;
            }
            recordln = reader.ReadLine();
        }

        reader.Close();
        inFile.Close();

    }

    //private void Save(string filename, object[] objects)
    //{
    //    FileStream outFile = new FileStream(filename, FileMode.Create, FileAccess.Write);
    //    StreamWriter writer = new StreamWriter(outFile);
    //    foreach (object obj in objects)
    //    {
    //        if (obj is Unit)
    //        {
    //            Unit unit = (Unit)obj;
    //            writer.WriteLine(unit.Save());
    //        }
    //        else if (obj is Building)
    //        {
    //            Building unit = (Building)obj;
    //            writer.WriteLine(unit.Save());
    //        }
    //    }
    //    writer.Close();
    //    outFile.Close();
    //}

    private void SaveRound()
    {
        FileStream outFile = new FileStream(ROUND_FILENAME, FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(outFile);
        writer.WriteLine(round);
        writer.Close();
        outFile.Close();
    }

    private void LoadRound()
    {
        FileStream inFile = new FileStream(
          ROUND_FILENAME, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(inFile);
        round = int.Parse(reader.ReadLine());
        reader.Close();
        inFile.Close();
    }

}
