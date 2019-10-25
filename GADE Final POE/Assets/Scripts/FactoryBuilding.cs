using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

 class FactoryBuilding: Building
{
    private FactoryType type; //using an int or string is also fine 
    private int productionSpeed;
    private int spawnY;

    public FactoryBuilding(int x, int y, string faction) : base(x, y, 100, faction, 'F')
    {
        if (y >= Map.SIZE - 1)
        {
            spawnY = y - 1;
        }
        else
        {
            spawnY = y + 1;
        }

        type = (FactoryType)GameEngine.random.Next(0, 2);
        productionSpeed = GameEngine.random.Next(3, 7);
    }

    public FactoryBuilding(string values)
    {
        string[] parameters = values.Split(',');

        x = int.Parse(parameters[1]);
        y = int.Parse(parameters[2]);
        health = int.Parse(parameters[3]);
        maxHealth = int.Parse(parameters[4]);
        type = (FactoryType)int.Parse(parameters[5]);
        productionSpeed = int.Parse(parameters[6]);
        spawnY = int.Parse(parameters[7]);
        faction = parameters[8];
        symbol = parameters[9][0];
        isDestroyed = parameters[10] == "True" ? true : false;
    }

    public int ProductionSpeed
    {
        get { return productionSpeed; }
    }

    public override void Destroy()
    {
        isDestroyed = true;
        symbol = '=';
    }

    //public override string Save()
    //{
    //    return string.Format(
    //            $"Factory,{x},{y},{health},{maxHealth}," +
    //            $"{(int)type},{productionSpeed},{spawnY}," +
    //            $"{faction},{symbol},{isDestroyed}");
    //}

    public Unit SpawnUnit()
    {
        Unit unit;
        if (type == FactoryType.MELEE)
        {
            unit = new MeleeUnit(x, spawnY, faction);
        }
        else
        {
            unit = new RangedUnit(x, spawnY, faction);

        }
        return unit;
    }

    private string GetFactoryTypeName()
    {
        return new string[] { "Melee", "Ranged" }[(int)type];
    }

    public override string ToString()
    {
        return
             "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" + Environment.NewLine + "Factory Building (" + symbol + "/" + faction[0] + ")" + Environment.NewLine +
             "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _" + Environment.NewLine + "Type: " + GetFactoryTypeName() + Environment.NewLine + base.ToString() + Environment.NewLine;
    }

}
