using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

abstract class Building
{
    protected int x;
    protected int y;
    protected int health;
    protected int maxHealth;
    protected string faction;
    protected char symbol;
    protected bool isDestroyed = false;

    public Building(int x, int y, int health, string faction, char symbol)
    {
        this.x = x;
        this.y = y;
        this.health = health;
        this.maxHealth = health;
        this.faction = faction;
        this.symbol = symbol;
    }

    public Building() { }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public string Faction
    {
        get { return faction; }
    }

    public char Symbol
    {
        get { return symbol; }
    }

    public bool IsDestroyed
    {
        get { return isDestroyed; }
    }

    public abstract void Destroy();

    //public abstract string Save();

    public override string ToString()
    {
        return
           "Faction: " + faction + Environment.NewLine +
           "Position: " + x + ", " + y + Environment.NewLine +
     "Health: " + health + " / " + maxHealth + Environment.NewLine;
    }





    public enum ResourceType
    {
        WOOD,
        FOOD,
        ROCK,
        GOLD
    }

    public enum FactoryType
    {
        MELEE,
        RANGE
    }

}
