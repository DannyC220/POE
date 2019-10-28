using System;
using UnityEngine;



class Map
{
    
    //map array created for game to be parametered around
    public string[,] mapArray = new string[20, 20];
    //unit array created to stroe the amount of units 
    public MeleeUnit[] marrUnits;
    public RangedUnit[] rarrUnits;
    public WizardUnit[] warrUnits;
    public ResourceBuilding[] res;
    public FactoryBuilding[] fact;




    //string name array created to store the different units from different teams
    string[] Names = new string[]{
            "Ragnor","Bravo","Kaylee","Sondheim","Loki","Slika","Hela","Asger","Grobble","Egil","Steve","Hagen","Jumanji"
            ,"Rakitic","Dyablo","Jerrik","Halvar","Igor"
    };




    System.Random r = new System.Random();

    public MeleeUnit[] MarrUnits
    {
        get
        {
            return marrUnits;
        }       
    }

    public RangedUnit[] RarrUnits
    {
        get
        {
            return rarrUnits;
        }
       
    }

    public ResourceBuilding[] Res
    {
        get
        {
            return res;
        }

        set
        {
            res = value;
        }
    }

    public FactoryBuilding[] Fact
    {
        get
        {
            return fact;
        }

        set
        {
            fact = value;
        }
    }

    public WizardUnit[] WarrUnits
    {
        get
        {
            return warrUnits;
        }
    }

    public Map()
    {
        marrUnits = new MeleeUnit[10];
        rarrUnits = new RangedUnit[10];
        warrUnits = new WizardUnit[10];
       

        for (int k = 0; k < 10; k++)
        {
            {
                marrUnits[k] = new MeleeUnit(r.Next(0, 20), r.Next(0, 20), "rogue", "m","def");
                rarrUnits[k] = new RangedUnit(r.Next(0, 20), r.Next(0, 20), "viking", "r","def");
                warrUnits[k] = new WizardUnit(r.Next(0, 20), r.Next(0, 20), "wizard","w","def");
            }
        }
        res = new ResourceBuilding[5];
        fact = new FactoryBuilding[5];

        for (int j = 0; j < 5; j++)
        {
            {
                res[j] = new ResourceBuilding(r.Next(0, 20), r.Next(0, 20), "rogue", "r");
                fact[j] = new FactoryBuilding(r.Next(0, 20), r.Next(0, 20), "viking", "f");
                res[j] = new ResourceBuilding(r.Next(0, 20), r.Next(0, 20), "wizard", "r");
            }
        }

    }

    //this method places the units within the map
    public void UnitPlacing()
    {
        for (int k = 0; k < marrUnits.Length; k++)
        {
            
            
                int unitSelection;
                int Team;
                int name = r.Next(0, Names.Length);

                string placeTeam = "";
                string placeSymbol = "";

                int x = r.Next(0, 20);
                int y = r.Next(0,20) ;

                unitSelection = r.Next(1, 3);

                switch (unitSelection)
                {
                    case 1://meleee unit of the rogues who are the villains
                        Team = r.Next(1, 3);
                        switch (Team)
                        {
                            case 1:
                                placeTeam = "rogue";
                                placeSymbol = "M";
                                break;

                            case 2:
                                placeTeam = "rogue";
                                placeSymbol = "m";
                                break;
                        }
                        marrUnits[k] = new MeleeUnit(x,y, placeTeam, placeSymbol, Names[name]);
                        break;

                    case 2://meleee unit of the rogues who are the villains
                    Team = r.Next(1, 3);
                    switch (Team)
                    {
                        case 1:
                            placeTeam = "viking";
                            placeSymbol = "R";
                            break;

                        case 2:
                            placeTeam = "viking";
                            placeSymbol = "r";
                            break;
                    }
                    rarrUnits[k] = new RangedUnit(x, y, placeTeam, placeSymbol, Names[name]);
                    break;

                }
                mapArray[marrUnits[k].YPosition, marrUnits[k].XPosition] = marrUnits[k].Symbol;
                mapArray[rarrUnits[k].YPosition, rarrUnits[k].XPosition] = rarrUnits[k].Symbol;



        }
        //for(int j=0;j<rarrUnits.Length;j++)
        //{
        //    int unitSelection;
        //    int Team;
        //    int name = r.Next(0, Names.Length);

        //    string placeTeam = "";
        //    string placeSymbol = "";

        //    int x = r.Next(0, 20);
        //    int y = r.Next(0, 20);

        //    unitSelection = r.Next(1, 3);

        //    switch (unitSelection)
        //    {
        //        case 1://meleee unit of the rogues who are the villains
        //            Team = r.Next(1, 3);
        //            switch (Team)
        //            {
        //                case 1:
        //                    placeTeam = "viking";
        //                    placeSymbol = "R";
        //                    break;

        //                case 2:
        //                    placeTeam = "viking";
        //                    placeSymbol = "r";
        //                    break;
        //            }
        //            rarrUnits[j] = new RangedUnit(x, y, placeTeam, placeSymbol, Names[name]);
        //            break;

        //    }
        //    mapArray[rarrUnits[j].YPosition, rarrUnits[j].XPosition] = rarrUnits[j].Symbol;

        //}
    }

        

    



    public void Battlefield()
    {
        //populates the map and fills it with the array size of 20 x 20 fullstops
        for (int k = 0; k < 20; k++)
        {
            for (int j = 0; j < 20; j++)
            {
                mapArray[k, j] = " ";
            }
        }
    }

    public void FillMap()
    {
       

        BuildPlacing();
        UnitPlacing();
        //for (int k = 0; k < marrUnits.Length; k++)
        //{
        //    Debug.Log(marrUnits[k].ToString());
        //}
        //for (int k = 0; k < rarrUnits.Length; k++)
        //{
        //    Debug.Log(rarrUnits[k].ToString());
        //}
        for (int k = 0; k < res.Length; k++)
        {
            Debug.Log(res[k].ToString());
        }
        for (int j = 0; j < fact.Length; j++)
        {
            Debug.Log(fact[j].ToString());
        }




    }

    //this method adds buildings to the map
    public void BuildPlacing()
    {
        int i = 0;
        int Team;

        string placeTeam = "";
        string placeSymbol = "";

        //assigned factory buildings to the first to teams
        fact[i] = new FactoryBuilding(1, 1, "Rogue Team", "p");
        mapArray[fact[i].YPosition, fact[i].XPosition] = fact[i].Symbol;
        i++;
        fact[i] = new FactoryBuilding(19, 19, "Rogue team", "p");
        mapArray[fact[i].YPosition, fact[i].XPosition] = fact[i].Symbol;

        //resource buiidings assigned to secong two teams
        for (int g = 2; g < res.Length; g++)
        {
            Team = r.Next(1, 3);
            int x = r.Next(0, 20);
            int y = r.Next(0, 20);

            switch (Team)
            {
                case 1:
                    placeTeam = "Viking team";
                    placeSymbol = "V";
                    break;  
                case 2:
                    placeTeam = "Viking team";
                    placeSymbol = "v";
                    break;
            }

            res[g] = new ResourceBuilding(x, y, placeTeam, placeSymbol);
            mapArray[res[g].YPosition, res[g].XPosition] = res[g].Symbol;

        }

    }
}


