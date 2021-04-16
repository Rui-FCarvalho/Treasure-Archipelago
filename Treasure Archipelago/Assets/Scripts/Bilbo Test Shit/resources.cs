using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Sailmode
{
    TradeRoutes,
    HighSeas
}
public class resources : MonoBehaviour
{

    public static float food, oranges, water, booze, gold, dirtiness;

    public static Sailmode sailmode;
    
    private void Start()
    {
        sailmode = Sailmode.TradeRoutes;
        dirtiness = 0;
        food = 200;
        oranges=200;
        water = 200;
        booze =200;
        gold = 200;
    }

    public void Update()   //cheesy fix I know but it works
    {
        if(dirtiness<0){dirtiness=0;}
        if(food<0){food=0;}
        if(oranges<0){oranges=0;}
        if(water<0){water=0;}
        if(booze<0){booze=0;}
        if(gold<0){gold=0;}
    }



    public void addfood()
    {
        food++;
    }

    public void addwater()
    {
        water++;
    }
}