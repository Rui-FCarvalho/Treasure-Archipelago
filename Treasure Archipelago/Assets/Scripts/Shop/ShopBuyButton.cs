using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopBuyButton : MonoBehaviour
{

    GameObject gamemanager;

    int size;
    public TextMeshProUGUI tfoodprice, twaterprice, torangeprice, tboozeprice, tfighterprice, tsailorprice, tcuremprice, tcurepprice, tupgradetoolprice, tupgradeweaponprice, tupgradecannonprice, tupgradehullprice;

    public int foodprice, waterprice, orangeprice, boozeprice, fighterprice, sailorprice, curemprice, curepprice;

    public int[] upgradetoolprice, upgradeweaponprice, upgradecannonprice, upgradehullprice;

    

    public void Awake()
    {
        gamemanager=GameObject.FindGameObjectWithTag("GameController");


        tupgradeweaponprice.text=upgradeweaponprice[0].ToString();
        tupgradetoolprice.text=upgradetoolprice[0].ToString();
        tupgradecannonprice.text=upgradecannonprice[0].ToString();
        tupgradehullprice.text=upgradehullprice[0].ToString();
        
    }

    void Update()
    {
        
        tfoodprice.text=foodprice.ToString();
        twaterprice.text=waterprice.ToString();
        torangeprice.text=orangeprice.ToString();
        tboozeprice.text=boozeprice.ToString();

        tfighterprice.text=fighterprice.ToString();
        tsailorprice.text=sailorprice.ToString();

        tcuremprice.text=(curemprice*gamemanager.GetComponent<manager>().pirates.Count).ToString();
        tcurepprice.text=(curepprice*gamemanager.GetComponent<manager>().pirates.Count).ToString();





    }

    public void BuyFood()
    {
        if (resources.gold < foodprice)
        {
            Debug.Log("lololol");
            return;
        }
        resources.food += 10;
        resources.gold -= foodprice;
    }

    public void BuyOrange()
    {
        if (resources.gold < orangeprice)
        {
            Debug.Log("lolollol");
            return;
        }
        resources.oranges += 10;
        resources.gold -= orangeprice;
    }

    public void BuyWater()
    {
        if (resources.gold < waterprice)
        {
            Debug.Log("lololol");
            return;
        }
        resources.water += 10;
        resources.gold -= waterprice;
    }

    public void BuyBottle()
    {
        if (resources.gold < boozeprice)
        {
            Debug.Log("lololol");
            return;
        }
        resources.booze += 10;
        resources.gold -= boozeprice;
    }



    public void UpgradeWeapons()
    {
        switch(gamemanager.GetComponent<PointManager>().Weapons)
        {
            case Equipment.normal:
                if (resources.gold >= upgradeweaponprice[0])
                {
                    resources.gold-=upgradeweaponprice[0];
                    gamemanager.GetComponent<PointManager>().Weapons=Equipment.good;
                    tupgradeweaponprice.text=upgradeweaponprice[1].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.good:
                if (resources.gold >= upgradeweaponprice[1])
                {
                    resources.gold-=upgradeweaponprice[1];
                    gamemanager.GetComponent<PointManager>().Weapons=Equipment.superb;
                    tupgradeweaponprice.text=upgradeweaponprice[2].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.superb:
                if (resources.gold >= upgradeweaponprice[2])
                {
                    resources.gold-=upgradeweaponprice[2];
                    gamemanager.GetComponent<PointManager>().Weapons=Equipment.mastercrafted;
                    tupgradeweaponprice.text="MAX";
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.mastercrafted:
                Debug.Log("max level");
                break;
        }
    }

    public void UpgradeTools()
    {
        switch(gamemanager.GetComponent<PointManager>().Tools)
        {
            case Equipment.normal:
                if (resources.gold >= upgradetoolprice[0])
                {
                    resources.gold-=upgradetoolprice[0];
                    gamemanager.GetComponent<PointManager>().Tools=Equipment.good;
                    tupgradetoolprice.text=upgradetoolprice[1].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.good:
                if (resources.gold >= upgradetoolprice[1])
                {
                    resources.gold-=upgradetoolprice[1];
                    gamemanager.GetComponent<PointManager>().Tools=Equipment.superb;
                    tupgradetoolprice.text=upgradetoolprice[2].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.superb:
                if (resources.gold >= upgradetoolprice[2])
                {
                    resources.gold-=upgradetoolprice[2];
                    gamemanager.GetComponent<PointManager>().Tools=Equipment.mastercrafted;
                    tupgradetoolprice.text="MAX";
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.mastercrafted:
                Debug.Log("max level");
                break;
        }
    }

    public void UpgradeCannons()
    {
        switch(gamemanager.GetComponent<PointManager>().Cannons)
        {
            case Equipment.normal:
                if (resources.gold >= upgradecannonprice[0])
                {
                    resources.gold-=upgradecannonprice[0];
                    gamemanager.GetComponent<PointManager>().Cannons=Equipment.good;
                    tupgradecannonprice.text=upgradecannonprice[1].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.good:
                if (resources.gold >= upgradecannonprice[1])
                {
                    resources.gold-=upgradecannonprice[1];
                    gamemanager.GetComponent<PointManager>().Cannons=Equipment.superb;
                    tupgradecannonprice.text=upgradecannonprice[2].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.superb:
                if (resources.gold >= upgradecannonprice[2])
                {
                    resources.gold-=upgradecannonprice[2];
                    gamemanager.GetComponent<PointManager>().Cannons=Equipment.mastercrafted;
                    tupgradecannonprice.text= "MAX";
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.mastercrafted:
                Debug.Log("max level");
                break;
        }
    }

    public void UpgradeHull()
    {
        switch(gamemanager.GetComponent<PointManager>().Hull)
        {
            case Equipment.normal:
                if (resources.gold >= upgradehullprice[0])
                {
                    resources.gold-=upgradehullprice[0];
                    gamemanager.GetComponent<PointManager>().Hull=Equipment.good;
                    tupgradehullprice.text=upgradehullprice[1].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.good:
                if (resources.gold >= upgradehullprice[1])
                {
                    resources.gold-=upgradehullprice[1];
                    gamemanager.GetComponent<PointManager>().Hull=Equipment.superb;
                    tupgradehullprice.text=upgradehullprice[2].ToString();
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.superb:
                if (resources.gold >= upgradehullprice[2])
                {
                    resources.gold-=upgradehullprice[2];
                    gamemanager.GetComponent<PointManager>().Hull=Equipment.mastercrafted;
                    tupgradehullprice.text="MAX";
                }
                else {Debug.Log ("no money fag");return;}
                break;

            case Equipment.mastercrafted:
                Debug.Log("max level");
                return;
        }
        gamemanager.GetComponent<manager>().HullPoint=gamemanager.GetComponent<manager>().MaxHull;

    }


    public void AddFighter()
    {
        if (resources.gold>=fighterprice)
        {
            pirate p = new pirate();
            p.vc=50;
            p.maxphp=100f;
            p.maxmhp=100f;

            p.mhp=p.maxmhp;
            p.php=p.maxphp;

            p.name=manager.namegen.GetNextRandomName();
            p.prof= Class.Fighter;

            gamemanager.GetComponent<manager>().pirates.Add(p);
            
        }else
            Debug.Log("No money");
    }



    public void AddSailor()
    {
        if (resources.gold>=sailorprice)
        {
            pirate p = new pirate();
            p.vc=50;
            p.maxphp=100f;
            p.maxmhp=100f;

            p.mhp=p.maxmhp;
            p.php=p.maxphp;

            p.name=manager.namegen.GetNextRandomName();
            p.prof= Class.Sailor;

            gamemanager.GetComponent<manager>().pirates.Add(p);
        }else
            Debug.Log("No money");
    }




    public void Brothel()
    {
        if(resources.gold >= int.Parse(tcuremprice.text))
        {
            resources.gold -= int.Parse(tcuremprice.text);
            foreach (pirate item in gamemanager.GetComponent<manager>().pirates)
            {
                item.mhp = item.maxmhp;
            }
        }else
        Debug.Log("No money");
    }

    public void Inn()
    {
        if(resources.gold >= int.Parse(tcurepprice.text))
        {
            resources.gold -= int.Parse(tcurepprice.text);
            foreach (pirate item in gamemanager.GetComponent<manager>().pirates)
            {
                item.php = item.maxphp;
            }
        }else
        Debug.Log("No money");
    }

}
