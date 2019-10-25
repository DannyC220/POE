using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WizardUnit : Unit
{
    public WizardUnit(int x, int y, string faction) : base(x, y, 150, 1, 25, 5, faction, 'W', "Merlin")
    {

    }

    public WizardUnit(string values) : base(values)
    {

    }

}
