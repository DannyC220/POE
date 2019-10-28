using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WizardUnit : Unit
{
    public WizardUnit(int Xposition, int Yposition,string team, string symbol, string name): base(Xposition,Yposition,team,symbol,name)
    {

    }

    //public WizardUnit(string values) : base(values)
    //{

    //}

    public override Unit closestUnit(Unit[] units)
    {
        throw new System.NotImplementedException();
    }

    public override bool withinRange(Unit enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void Combat(Unit enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void NewPos()
    {
        throw new System.NotImplementedException();
    }

    public override int Atk()
    {
        throw new System.NotImplementedException();
    }
}
