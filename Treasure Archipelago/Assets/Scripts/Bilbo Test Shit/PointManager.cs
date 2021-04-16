using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Equipment
{
    normal,
    good,
    superb,
    mastercrafted
};
public class PointManager : MonoBehaviour
{


    public int fppfighter, sppfighter,sppsailor, fppsailor;

    private int bfppfighter, bsppfighter,bsppsailor, bfppsailor;
    private int Fweaponbuff, Sweaponbuff, Ftoolbuff, Stoolbuff;
    public manager manager;

    public Equipment Weapons;
    public Equipment Tools;
    public Equipment Cannons;
    public Equipment Hull;

    void Start()
    {
        bsppsailor=2;
        bfppsailor=1;

        bsppfighter=1;
        bfppfighter=2; 

        manager=this.gameObject.GetComponent<manager>();
    }

    void Update()
    {
        
        switch(Weapons)
        {
            case Equipment.normal:
            Fweaponbuff=0;
            Sweaponbuff=0;
            break;

            case Equipment.good:
            Fweaponbuff=2;
            Sweaponbuff=1;
            break;

            case Equipment.superb:
            Fweaponbuff=4;
            Sweaponbuff=1;
            break;

            case Equipment.mastercrafted:
            Fweaponbuff=8;
            Sweaponbuff=1;
            break;
        }

        switch(Tools)
        {
            case Equipment.normal:
            Stoolbuff=0;
            Ftoolbuff=0;
            break;

            case Equipment.good:
            Stoolbuff=2;
            Ftoolbuff=1;
            break;

            case Equipment.superb:
            Stoolbuff=4;
            Ftoolbuff=1;
            break;

            case Equipment.mastercrafted:
            Stoolbuff=8;
            Ftoolbuff=1;
            break;
        }
        
        fppfighter = bfppfighter+Fweaponbuff;
        sppfighter = bsppfighter+Ftoolbuff;


        switch(Cannons)
        {
            case Equipment.normal:
                manager.cannondmg=10;
                break;

            case Equipment.good:
                manager.cannondmg=20;
                break;

            case Equipment.superb:
                manager.cannondmg=30;
                break;

            case Equipment.mastercrafted:
                manager.cannondmg=40;
                break;
        }

        switch(Hull)
        {
            case Equipment.normal:
                manager.MaxHull=100;
                break;

            case Equipment.good:
                manager.MaxHull=150;
                break;

            case Equipment.superb:
                manager.MaxHull=200;
                break;

            case Equipment.mastercrafted:
                manager.MaxHull=300;
                break;
        }

        switch(manager.sailorsfight)
        {
            case true:
                fppsailor=bfppsailor+Sweaponbuff;
                break;
            case false:
                fppsailor=0;
                break;
        }
        sppsailor=bsppsailor+Stoolbuff;


    }



    public void pointcalc(List<pirate> pirates)
    {
        int sailorcount=0;
        int fightercount=0;
        foreach (pirate p in pirates)
        {
            if(p.prof==Class.Sailor)
            {
                sailorcount++;
            }
            if(p.prof==Class.Fighter)
            {
                fightercount++;
            }
        }



        manager.sailpoint = sailorcount * sppsailor + fightercount * sppfighter;
        manager.fightpoint = sailorcount * fppsailor + fightercount * fppfighter;
    }
}
