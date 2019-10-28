using UnityEngine;

class GameEngine
{
    //map class called upon so game engine inherits its methods and game map
    public Map map = new Map();
    //public MeleeUnit[] marrUnits;
    //public RangedUnit[] rarrUnits;
    //public ResourceBuilding[] res;
    //public FactoryBuilding[] fact;







    //resource building class called upon so gameengine inherits its methods for placing of buildings 

    public bool playing = true;

    public bool Playing
    {
        get
        {
            return playing;
        }

    }





    public GameEngine()
    {


    }









    private void SwitchUnitTurn()
    {
        //searches for a specific unit and selects their turn
        for (int k = 0; k < map.marrUnits.Length; k++)
        {
            if (map.marrUnits[k] != null)
            {
                //this replaces the original position of with a open space, checks also if theres an empty space.
                map.mapArray[map.marrUnits[k].YPosition, map.marrUnits[k].XPosition] = " ";



                //checks to see if a units alive
                if (map.marrUnits[k].Hp > 0)
                {
                    //if a specific unit drops below the hp of 25 it runs away
                    if ((map.marrUnits[k].Hp / map.rarrUnits[k].MaxHP) * 100 <= 25 / 100)
                    {
                        //checks to see if an enemy is in range, a unit will attack within that range
                        map.rarrUnits[k].NewPos();
                    }
                    //this else checks to see if a unit is not running away
                    else
                    {
                        if (map.marrUnits[k].withinRange(map.rarrUnits[k].closestUnit(map.marrUnits)) == true)
                        {
                            map.marrUnits[k].closestUnit(map.rarrUnits).Hp -= map.marrUnits[k].Atk();
                            for (int z = 0; z < map.marrUnits.Length; z++)
                            {
                                if (map.marrUnits[z] == map.marrUnits[k].closestUnit(map.rarrUnits) && map.marrUnits[z] != null) map.rarrUnits[z].Hp -= map.marrUnits[k].Atk();
                            }
                        }
                        else
                        {
                            map.marrUnits[k].Combat(map.rarrUnits[k].closestUnit(map.rarrUnits));
                        }
                    }

                    //places a symbol on the map to locate the units position
                    map.mapArray[map.marrUnits[k].YPosition, map.marrUnits[k].XPosition] = map.marrUnits[k].Symbol;

                }
                //checks if a unit is dead
                else
                {
                    //if a unit is dead it places a star symbol to signify death of unit
                    map.mapArray[map.marrUnits[k].YPosition, map.marrUnits[k].XPosition] = "*";
                    map.rarrUnits[k] = null;
                }
            }
        }
    }



    public void BeginGame()
    {
        SwitchUnitTurn();
        rangeTurn();

        //    for(int k =0; k < map.build.Length;k++)
        //    {
        //        if (map.build[k] != null)
        //            map.mapArray[map.build[k].XPosition, map.build[k].YPosition] = map.build[k].Symbol;
        //    }       

    }


    private void rangeTurn()
    {
        for (int k = 0; k < map.rarrUnits.Length; k++)
        {
            if (map.rarrUnits[k] != null)
            {
                map.mapArray[map.rarrUnits[k].YPosition, map.rarrUnits[k].XPosition] = "viking";
                if (map.rarrUnits[k].Hp > 0)
                {
                    if ((map.rarrUnits[k].Hp / map.rarrUnits[k].MaxHP) * 100 <= 25 / 100)
                    {
                        map.marrUnits[k].NewPos();
                        if (map.marrUnits[k].withinRange(map.marrUnits[k].closestUnit(map.rarrUnits)) == true)
                        {
                            for (int z = 0; z < map.rarrUnits.Length; z++)
                            {
                                if (map.rarrUnits[z] == map.marrUnits[k].closestUnit(map.rarrUnits) && map.rarrUnits[z] != null) map.rarrUnits[z].Hp -= map.rarrUnits[k].Atk();
                            }
                        }
                    }
                    else
                    {
                        if (map.rarrUnits[k].withinRange(map.rarrUnits[k].closestUnit(map.marrUnits)) == true)
                        {
                            for (int z = 0; z < map.marrUnits.Length; z++)
                            {
                                if (map.marrUnits[z] == map.rarrUnits[k].closestUnit(map.marrUnits) && map.rarrUnits != null) map.marrUnits[z].Hp -= map.rarrUnits[k].Atk();

                            }

                        }
                        else
                            map.rarrUnits[k].Combat(map.marrUnits[k].closestUnit(map.marrUnits));
                    }
                    map.mapArray[map.rarrUnits[k].YPosition, map.rarrUnits[k].XPosition] = map.rarrUnits[k].Symbol;

                }
                else
                {
                    map.mapArray[map.rarrUnits[k].YPosition, map.rarrUnits[k].XPosition] = "viking";
                    map.marrUnits[k] = null;
                }

            }

        }
    }
}





