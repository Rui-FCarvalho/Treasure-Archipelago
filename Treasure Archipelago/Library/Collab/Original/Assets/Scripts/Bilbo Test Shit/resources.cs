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
        sailmode = Sailmode.HighSeas;
        dirtiness = 0;
        food = 200;
        oranges=200;
        water = 200;
        booze =200;
        gold = 9999;
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