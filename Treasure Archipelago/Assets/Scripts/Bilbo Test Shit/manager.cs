using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum State
{
    normal,
    ration,
    feast
};

public class manager : MonoBehaviour
{

    public int turncount;

    public TextMeshProUGUI life;


    public Sailmode current;
    public bool sailorsfight;

    
    public int MaxHull;
    public int HullPoint;
    public int cannondmg;
    //public float debugfood, debugoranges, debugwater, debugbooze, debuggold;

    public List<pirate> pirates;

    public PointManager pm;
    
    public int fightpoint, sailpoint;

    [HideInInspector]
    public static Lexic.NameGenerator namegen;

    public State FoodState;
    public State WaterState;

    [HideInInspector]
    public List<pirate> dead;

    private void Start()
    {
        //test
        //UnityEngine.Random r = new UnityEngine.Random();
        //UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        //for (int i = 0; i < 100; i++)
        //{
        //    Debug.Log(UnityEngine.Random.Range(0, 100));
        //}

        turncount=0;
        MaxHull=100;
        HullPoint=MaxHull;
        pm=gameObject.GetComponent<PointManager>();
        namegen=gameObject.GetComponent<Lexic.NameGenerator>();
        /*debugfood=resources.food;
        debugoranges=resources.oranges;
        debugwater=resources.water;
        debugbooze=resources.booze;
        debuggold=resources.gold;*/
        for (int i =0;i<10;i++)
        {
            pirate p= new pirate();
            p.vc=50;
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
        if (pirates.Count==0){ManagerScenes.LoadScene(ManagerScenes.scenes.Lose);}
        life.text="Your ship has " + HullPoint + "/" + MaxHull+ " life points";
    }

    
    public void passturn()
    {
        float foodn = resources.food;
        float orangesn=resources.oranges;
        float watern=resources.water;
        float boozen=resources.booze;
        float goldn=resources.gold;
        

        resources.dirtiness++;

        PlayerInteractor.UpdatePlayerChoices();
        turncount++;
        EventManagerList.Turn();

        Illness.TurnDisease(pirates);

        foreach (pirate p in pirates)
        {
            p.eat(FoodState);
            p.drink(WaterState);
        }
        checkdead();
        PlayerInteractor.UpdateReport(foodn-resources.food,watern-resources.water,orangesn-resources.oranges,boozen-resources.booze,goldn-resources.gold,pirates);
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


    public void suckmyballsunity()
    {
        sailorsfight=!sailorsfight;
    }
    public void Maintnence()
    {
        HullPoint=MaxHull;
        resources.dirtiness-=20;
        passturn();
    }
}