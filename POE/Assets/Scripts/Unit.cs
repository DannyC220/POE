using UnityEngine; 

    public abstract class Unit
    {
        //variables created for meleeunit and rangedunit to inherit from
        protected int xPosition;
        protected int yPosition;
        protected int hp;
        protected int attack;
        protected int range;
        protected string team;
        protected string symbol;
        protected string name;
        protected int maxHP;
        protected bool isAttacking;

        //accessors created for methods to handle
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
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
      }
      public int Attack
      {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
      }
      public int Range
      {
        get
        {
            return range;
        }
        set
        {
            range = value;
        }
      }
      public string Team
      {
        get
        {
            return team;
        }
        set
        {
            team = value;
        }
      }
      public string Symbol
      {
        get
        {
            return symbol;
        }
        set
        {
            symbol = value;
        }
      }
      public string Name
      {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
      }
      public int MaxHP
      {
        get
        {
            return maxHP;
        }
        set
        {
            maxHP = value;
        }
      }
      public bool IsAttacking
      {
        get
        {
            return isAttacking;
        }
        set
        {
            isAttacking = value;
        }
      }

        public Unit(int Xposition, int Yposition, string team, string symbol, string name)
        {
        this.XPosition = Xposition;
        this.YPosition = Yposition;
        this.Name = name;
        }

        //checks position of another unit closest to a certain unit
        public abstract Unit closestUnit(Unit[] units);

        //checks to see if one unit is within attack range of the other unit
        public abstract bool withinRange(Unit enemy);

        //batlle between meleeunit and rangedunit
        public abstract void Combat(Unit enemy);//move to enemy

        //moves units to a new position
        public abstract void NewPos();

        public abstract int Atk();

        
    }

