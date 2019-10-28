using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameEngine eng = new GameEngine();






    const float Padding = 5.12f;
    float xOff, yOff;
    private const int RefreshCount = 60;
    private int count = 0;







    // Use this for initialization
    void Start()
    {



        xOff = (-2 * Camera.main.orthographicSize) / 2;
        yOff = Camera.main.orthographicSize;



        FillGrass();
        FillUnits(eng.map.MarrUnits);
        FillUnits(eng.map.RarrUnits);
        //Vikings();
        FillUnits(eng.map.WarrUnits);
        FillFactory(eng.map.Fact);
        FillResources(eng.map.Res);





    }

    // Update is called once per frame
    void Update()
    {

        if (eng.playing && count % RefreshCount == 0)
        {


            eng.BeginGame();            
            reDraw();

        }
        count++;

        

    }



    void FillUnits(MeleeUnit[] marrUnits)
    {
        for (int k = 0; k < eng.map.marrUnits.Length; k++)
        {
            if (eng.map.marrUnits[k] != null)
            {

                Instantiate(Resources.Load("rogue"), new Vector3(xOff + (marrUnits[k].XPosition * Padding), yOff + (-marrUnits[k].YPosition * Padding), -1), Quaternion.identity);
                Instantiate(Resources.Load(DetermineHP(eng.map.marrUnits[k].Hp, eng.map.marrUnits[k].MaxHP)), new Vector3(xOff + (eng.map.marrUnits[k].XPosition * Padding), yOff + (-eng.map.marrUnits[k].YPosition * Padding), -2), Quaternion.identity);

            }


        }

    }

    void FillUnits(RangedUnit[] rarrUnits)
    {
        for (int j = 0; j < eng.map.rarrUnits.Length; j++)
        {

            if (eng.map.marrUnits[j] != null)
            {
                Instantiate(Resources.Load("viking"), new Vector3(xOff + (rarrUnits[j].XPosition * Padding), yOff + (-rarrUnits[j].YPosition * Padding), -1), Quaternion.identity);
                Instantiate(Resources.Load(DetermineHP(eng.map.rarrUnits[j].Hp, eng.map.rarrUnits[j].MaxHP)), new Vector3(xOff + (eng.map.rarrUnits[j].XPosition * Padding), yOff + (-eng.map.rarrUnits[j].YPosition * Padding), -2), Quaternion.identity);
            }

        }
    }

    void FillUnits(WizardUnit[] warrUnits)
    {
        for (int j = 0; j < eng.map.warrUnits.Length; j++)
        {
            if (eng.map.warrUnits[j] != null)
            {
                Instantiate(Resources.Load("wizards"), new Vector3(xOff + (warrUnits[j].XPosition * Padding), yOff + (-warrUnits[j].YPosition * Padding), -1), Quaternion.identity);
                Instantiate(Resources.Load(DetermineHP(eng.map.warrUnits[j].Hp, eng.map.warrUnits[j].MaxHP)), new Vector3(xOff + (eng.map.warrUnits[j].XPosition * Padding), yOff + (-eng.map.warrUnits[j].YPosition * Padding), -2), Quaternion.identity);
            }
        }
    }

    void FillFactory(FactoryBuilding[] fact)
    {
        for (int j = 0; j < eng.map.fact.Length; j++)
        {


            Instantiate(Resources.Load("FactoryBuilding"), new Vector3(xOff + (fact[j].XPosition * Padding), yOff + (-fact[j].YPosition * Padding), -1), Quaternion.identity);
            Instantiate(Resources.Load(DetermineHP(fact[j].Hp, fact[j].MaxHp)), new Vector3(xOff + (fact[j].XPosition * Padding), yOff + (-fact[j].YPosition * Padding), -2), Quaternion.identity);

        }


    }

    

    void FillResources(ResourceBuilding[] res)
    {
        for (int k = 0; k < eng.map.res.Length; k++)
        {


            Instantiate(Resources.Load("ResourceBuilding"), new Vector3(xOff + (res[k].XPosition * Padding), yOff + (-res[k].YPosition * Padding), -1), Quaternion.identity);
            Instantiate(Resources.Load(DetermineHP(res[k].Hp, res[k].MaxHp)), new Vector3(xOff + (res[k].XPosition * Padding), yOff + (-res[k].YPosition * Padding), -2), Quaternion.identity);

        }
    }

    //void Vikings()
    //{
    //    for (int k = 0; k< 3; k++)
    //    {
    //        for (int j = 0; j < 3; j++)
    //        {
    //            Instantiate(Resources.Load("viking"), new Vector3(xOff +  (j * Padding), yOff + (-k * Padding), 0), Quaternion.identity);
    //        }
    //    }
    //}

    void FillGrass()
    {
        for (int k = 0; k < 20; k++)
        {
            for (int j = 0; j < 20; j++)
            {
                Instantiate(Resources.Load("grass"), new Vector3(xOff + (j * Padding), yOff + (-k * Padding), 0), Quaternion.identity);

            }
        }
    }


    void reDraw()
    {
        DestroyAll();


        FillUnits(eng.map.MarrUnits);
        FillUnits(eng.map.RarrUnits);
        //Vikings();
        FillUnits(eng.map.warrUnits);
        FillFactory(eng.map.Fact);
        FillResources(eng.map.Res);
        eng.BeginGame();

        eng.map.UnitPlacing();
        //code below outputs the print of units 
        for (int k = 0; k <eng.map.marrUnits.Length; k++)
        {
            Debug.Log(eng.map.marrUnits[k].ToString());
        }
        for (int j = 0; j < eng.map.rarrUnits.Length; j++)
        {
            Debug.Log(eng.map.rarrUnits[j].ToString());
        }
        for (int k = 0; k < eng.map.res.Length; k++)
        {
            Debug.Log(eng.map.res[k].ToString());
        }
        for (int j = 0; j < eng.map.fact.Length; j++)
        {
            Debug.Log(eng.map.fact[j].ToString());
        }


        //code used initially for implentation of redraw
        for (int k = 0; k < eng.map.marrUnits.Length; k++)
        {
            if (eng.map.marrUnits[k] != null)
            {
                if (eng.map.marrUnits[k].Symbol == "M")
                {
                    Instantiate(Resources.Load("rogue"), new Vector3(xOff + (eng.map.marrUnits[k].XPosition * Padding), yOff + (-eng.map.marrUnits[k].YPosition * Padding), -1), Quaternion.identity);
                    Instantiate(Resources.Load(DetermineHP(eng.map.marrUnits[k].Hp, eng.map.marrUnits[k].MaxHP)), new Vector3(xOff + (eng.map.marrUnits[k].XPosition * Padding), yOff + (-eng.map.marrUnits[k].YPosition * Padding), -2), Quaternion.identity);

                }
                else if (eng.map.marrUnits[k].Symbol == "m")
                {
                    Instantiate(Resources.Load("rogue"), new Vector3(xOff + (eng.map.marrUnits[k].XPosition * Padding), yOff + (-eng.map.marrUnits[k].YPosition * Padding), -1), Quaternion.identity);
                    Instantiate(Resources.Load(DetermineHP(eng.map.marrUnits[k].Hp, eng.map.marrUnits[k].MaxHP)), new Vector3(xOff + (eng.map.marrUnits[k].XPosition * Padding), yOff + (-eng.map.marrUnits[k].YPosition * Padding), -2), Quaternion.identity);
                }
            }
        }
        for (int j = 0; j < eng.map.rarrUnits.Length; j++)
        {
            if (eng.map.rarrUnits[j] != null)
            {
                if (eng.map.rarrUnits[j].Symbol == "R")
                {
                    Instantiate(Resources.Load("viking"), new Vector3(xOff + (eng.map.rarrUnits[j].XPosition * Padding), yOff + (-eng.map.rarrUnits[j].YPosition * Padding), -1), Quaternion.identity);
                    Instantiate(Resources.Load(DetermineHP(eng.map.rarrUnits[j].Hp, eng.map.rarrUnits[j].MaxHP)), new Vector3(xOff + (eng.map.rarrUnits[j].XPosition * Padding), yOff + (-eng.map.rarrUnits[j].YPosition * Padding), -2), Quaternion.identity);
                }
                else if (eng.map.rarrUnits[j].Symbol == "r")
                {
                    Instantiate(Resources.Load("viking"), new Vector3(xOff + (eng.map.rarrUnits[j].XPosition * Padding), yOff + (-eng.map.rarrUnits[j].YPosition * Padding), -1), Quaternion.identity);
                    Instantiate(Resources.Load(DetermineHP(eng.map.rarrUnits[j].Hp, eng.map.rarrUnits[j].MaxHP)), new Vector3(xOff + (eng.map.rarrUnits[j].XPosition * Padding), yOff + (-eng.map.rarrUnits[j].YPosition * Padding), -2), Quaternion.identity);
                }
            }
        }




    }

    string DetermineHP(int hp, int maxHP)
    {
        string returnVal = "hp";
        double result = ((double)hp);
        int num = Mathf.CeilToInt((float)result);
        num = Mathf.RoundToInt(num/5)*5;
        returnVal += num;
        return returnVal;
    }

    private void Move()
    {

    }

    void DestroyAll()
    {
        GameObject[] killAllUnits = GameObject.FindGameObjectsWithTag("reDraw");

        foreach (GameObject unit in killAllUnits)
        {
            Destroy(unit);
        }
        CheckDeath();

    }

    void CheckDeath()
    {
        if (eng.map.MarrUnits[0].IsDead())
        {
            GameObject deadUnit = GameObject.Find("rogue");
            Destroy(deadUnit);
        }

        if (eng.map.RarrUnits[1].IsDead())
        {
            GameObject deadUnit = GameObject.Find("viking");
            Destroy(deadUnit);
        }
    }







}
