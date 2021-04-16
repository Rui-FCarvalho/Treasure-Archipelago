using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum State
{
    normal,
    ration,
    feast
};

public class manager : MonoBehaviour
{

    public Sailmode current;
    public bool sailorsfight;
    public float debugfood, debugoranges, debugwater, debugbooze, debuggold;

    public List<pirate> pirates;

    public PointManager pm;
    
    public int fightpoint, sailpoint;
    private Lexic.NameGenerator namegen;

    public State FoodState;
    public State WaterState;

    [HideInInspector]
    public List<pirate> dead;

    private void Start()
    {
        pm=gameObject.GetComponent<PointManager>();
        namegen=gameObject.GetComponent<Lexic.NameGenerator>();
        debugfood=resources.food;
        debugoranges=resources.oranges;
        debugwater=resources.water;
        debugbooze=resources.booze;
        debuggold=resources.gold;
        for (int i =0;i<10;i++)
        {
            pirate p= new pirate();
            p.maxphp=100f;
            p.maxmhp=100f;

            p.mhp=p.maxmhp;
            p.php=p.maxphp;
            p.name=namegen.GetNextRandomName();

            if (i<5)
            {
                p.prof = Class.Sailor;
            }
            else
            {
                p.prof = Class.Fighter;
            }

            pirates.Add(p);
        }
    }


    void Update()
    {
        //Debug.Log(pm);//NULL
        resources.sailmode=current;
        pm.pointcalc(pirates);
    }

    
    public void passturn()
    {
        Illness.TurnDisease(pirates);
        try
        {
            EventManagerList.Turn();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        foreach (pirate p in pirates)
        {
            p.eat(FoodState);
            p.drink(WaterState);
        }
        checkdead();
    }

    public void checkdead()
    {
        //Debug.Log("im here");
        foreach(pirate p in pirates)
        {
            if (p.mhp<=0 || p.php<=0)
            {
                p.dead = true;
            }
            if(p.dead==true){ dead.Add(p);}
        }

        foreach(pirate p in dead)
        {
            pirates.Remove(p);
        }
        dead.Clear();
    }

    public void addresource()
    {
        resources.food=debugfood;
        resources.oranges=debugoranges;
        resources.water=debugwater;
        resources.booze=debugbooze;
        resources.gold=debuggold;
    }
}