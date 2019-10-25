using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

 class MeleeUnit: Unit
{
    public MeleeUnit(int x, int y, string faction) : base(x, y, 200, 2, 20, 1, faction, '*', "Swordsman")
    {

    }

    public MeleeUnit(string values) : base(values)
    {

    }

    //public override string Save()
    //{
    //    return string.Format("Melee," + x +",",{y},{health},{maxHealth},{speed},{attack},{attackRange}," +
    //      "/n" +"{faction},{symbol},{name},{isDestroyed}");
    //}

}
