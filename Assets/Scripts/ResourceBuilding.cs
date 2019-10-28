using UnityEngine;

    class ResourceBuilding:Building
    {
        
        //resourcebuilding inherits buildings variables
        public ResourceBuilding(int Xposition, int Yposition, string team, string symbol):base(Xposition,Yposition,team,symbol)
        {
            //each variable is assigned to value or a accessor
            this.hp = 100;
        this.maxHp = 100;
            this.XPosition = Xposition;
            this.YPosition= Yposition;
            this.team = team;
            this.symbol = symbol;
            this.VikingweaponResources = WeaponResources;
            this.rogueWeaopenResources = RogueWeaopenResources;
        }

        //to string method handles the output of each unit so that the location on the map is shown
        public override string ToString()
        {
            string[] unitSelection = GetType().ToString().Split('.');
            string mySelection = unitSelection[unitSelection.Length - 1];

            return Team + ","  + mySelection + "," + (XPosition + 1) + "," + (YPosition + 1) + "," + Hp;
        }

        public override int runWeaponResources()
        {
            return WeaponResources++;
        }

        public override int runRogueWeaponResources()
        {
            return rogueWeaopenResources++;
        }
    }

