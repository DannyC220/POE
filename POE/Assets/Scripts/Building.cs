using UnityEngine;

    abstract class Building
    {
        //variables created for factory and resource to inherit from
        protected int xPosition;
        protected int yPosition;
        protected int hp;
    protected int maxHp;
    protected string team;
        protected string symbol;
        protected int VikingweaponResources;
        protected int rogueWeaopenResources;

        //accssesors created for methods to obtain
      public int XPosition
      {
        get
        {
            return xPosition;
        }
        set
        {
            xPosition = value;
        }
      }
      public int YPosition
      {
        get
        {
            return yPosition;
        }
        set
        {
            yPosition = value;
        }
      }
        public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
        }
    }
        public string Team
    {
        get { return team; }
        set
        {
            team = value;
        }
    }
        public string Symbol
    {
        get { return symbol; }
        set
        {
            symbol = value;
        }
    }
        public int WeaponResources
    {
        get { return VikingweaponResources; }
        set
        {
            VikingweaponResources = value;
        }
    }
        public int RogueWeaopenResources
    {
        get { return rogueWeaopenResources; }
        set
        {
            rogueWeaopenResources = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }

    public Building(int Xposition, int Yposition, string team, string symbol)
        {
          this.XPosition = XPosition;
          this.YPosition = Yposition;
        }

        public virtual int runWeaponResources()
        {
            return 0;
        }

        public virtual int runRogueWeaponResources()
        {
            return 0;
        }
    }

