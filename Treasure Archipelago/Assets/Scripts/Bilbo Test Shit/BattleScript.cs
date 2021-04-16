using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum stage
{
    fire,
    sword
}

public enum Type
{
    Pirate,
    Merch,
    Navy
}


public class BattleScript : MonoBehaviour
{
    public class Enemy
    {
        public string name;
        public int hp;
        public int fp;
        public int sp;
        public int cannondmg;
        public Type type;
        
        public Enemy(string Name, int HP, int FP, int SP, int Cannondmg, Type typ)
        {
            name=Name;
            hp=HP;
            fp=FP;
            sp=SP;
            cannondmg=Cannondmg;
            type = typ;
        }
    }

    public Enemy SmallMerchantShip = new Enemy("small merchant ship",100,5,10,10, Type.Merch);
    public Enemy SmallPirateShip=new Enemy("small pirate ship",100,10,5,10, Type.Pirate);
    Enemy latestenemy;

    public TextMeshProUGUI log;
    public manager manager;
    public Inventory inventory;
    

    public TextMeshProUGUI nbullets,ndrugs;

    int mult;
    int add;



    public int esp, efp;
    public int psp,pfp;
    public int elp;
    public stage currentstage;
    GameObject popupmanager;

    


    public GameObject window, firebutton, swordbutton;





    public void ChooseEnemy()
    {
        
        switch(resources.sailmode)
        {
            case Sailmode.HighSeas:
                StartBattle(SmallPirateShip);
                break;
            case Sailmode.TradeRoutes:
                StartBattle(SmallMerchantShip);
                break;
        }
    }
    public void StartBattle(Enemy enemy)
    {
        latestenemy=enemy;
        currentstage=stage.fire;

        
       
        elp=enemy.hp;
        esp=enemy.sp;
        efp=enemy.fp;
        log.text= "-Captain, we have spotted a " + enemy.name + ", just give the order and we'll send those scurvy dogs to the bottom of the sea.";
        window.SetActive(true);
        ContinueBattle();
    }
    public void ContinueBattle()
    {
        switch (currentstage)
        {
            case stage.sword:
                firebutton.SetActive(false);
                swordbutton.SetActive(true);
            break;
            case stage.fire:
                firebutton.SetActive(true);
                swordbutton.SetActive(false);
            break;
        }

    }
    public void Run()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int  myroll = Random.Range(0, psp+1); 
        
        int  enemyroll = Random.Range(0, esp+1);

        if(myroll>enemyroll)
        {

            RunAway();
            //run away function here

        }
        else
        {
            manager.HullPoint-=20;
            log.text="Your ship tried to run away but your enemy manage to catch up, landing a direct hit with their cannons during the persuit.\n Your ship took 20 damage";
            NextStage();
        }
    }
    public void FireFight()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        //your shot
        int myshot = Random.Range(psp-5,psp+6);  //20
        Debug.Log(myshot);
        int enemyeva = Random.Range(esp-5,esp+6); //15
        Debug.Log(enemyeva);
        int myacc = myshot-enemyeva;    //20-15=5
        int mydmg=manager.cannondmg*mult;
        Debug.Log(myacc);

        if (myacc<0)
            {
                log.text="The enemy ship evaded your shots";
                elp-=0;
            }
        else if (myacc >=0 && myacc <5)
            {
                log.text = "You landed a hit on the enemy ship doing " + mydmg + " damage";
                elp-=mydmg;
            }
        else if (myacc>=5)
            {
                log.text = "You landed a direct hit on the enemy ship doing " + mydmg*2 + " damage";
                elp-=(mydmg * 2);
            }

        //enemy shot
        int enemyshot = Random.Range(psp-5,psp+6);  //20
        //Debug.Log(enemyshot);
        int myeva = Random.Range(esp-5,esp+6); //15
        //Debug.Log(myeva);
        int enemyacc = enemyshot-myeva;    //20-15=5
        //Debug.Log(enemyacc);

        if (enemyacc<0)
            {
                log.text += "\n You evaded all enemy shots";
                manager.HullPoint-=0;
            }
        else if (enemyacc >=0 && enemyacc <5)
            {
                log.text += "\n The enemy ship landed a hit on your ship doing " + latestenemy.cannondmg +  " damage";
                manager.HullPoint-=latestenemy.cannondmg;
            }
        else if (enemyacc>=5)
            {
                log.text += "\n The enemy ship landed a direct hit on your ship doing " + latestenemy.cannondmg *2 + " damage";
                manager.HullPoint-=( latestenemy.cannondmg * 2);
            }

        NextStage();
    }
    public void supershot()
    {
        bool a = inventory.FindItem(10);

        switch(a)
        {
            case true:
                inventory.RemoveItem(10,1);
                mult=2;
                FireFight();
                mult=1;
                break;

            case false:
                Debug.Log("no bullet");
                break;
        }
    }
    public void Disengage()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int  myroll = Random.Range(0, psp+1);
        int  enemyroll = Random.Range(0, esp+1);

        if(myroll>=enemyroll)
        {
            log.text="Your crew manages to safely disengage the enemy and sail to a safe distance";
            NextStage();
        }
        else
        {
            log.text="Your crew isn't able to disengage the enemy. Your ship takes 40 damage.";
            manager.HullPoint-=40;  //maybe should change???
            NextStage();
        }
    }
    public void SwordFight()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int myroll = Random.Range(pfp-5,pfp+6) + add;
        Debug.Log(myroll);
        int enemyroll=Random.Range(efp-5,efp+6);
        Debug.Log(enemyroll);

        int result = myroll-enemyroll;
        Debug.Log(result);

        bool win;
        if (result>=0)
        {
            win=true;
        }
        else 
        {
            win=false;
            result*=-1;
        }

        int damage=result*10;

        switch(win)
        {
            case true:

                elp-=damage*mult;
                log.text = "With Fire and Steel your crew wins the fight and does " + damage*mult + "  damage to the enemy ship.\n That'll teach those rats who's the real king of the seas!";

                foreach (pirate p in manager.pirates)
                {
                    if (p.prof== Class.Sailor && manager.sailorsfight==true)
                    {
                        p.php-=0.5f;
                        p.mhp-=0.5f;
                    }else if (p.prof==Class.Fighter)
                    {
                        p.php-=0.5f;
                    }
                    manager.checkdead();
                }
              

                break;
            case false:
                manager.HullPoint-=damage;
                log.text = "Your crew fought bravely but it wasn't able to hold back the enemy assault, your ship takes " + damage + "  damage.\n We'll get those pox-ridden maggots next time!";

                foreach (pirate p in manager.pirates)
                {
                    if (p.prof== Class.Sailor && manager.sailorsfight==true)
                    {
                        p.php-=1f;
                        p.mhp-=1f;
                    }else if (p.prof==Class.Fighter)
                    {
                        p.php-=1f;
                    }
                }

                
                manager.checkdead();
                break;
        }

        NextStage();
    }
    public void Usedrugs()
    {
        bool a = inventory.FindItem(9);

        switch(a)
        {
            case true:
                inventory.RemoveItem(9,1);

                foreach (pirate p in manager.pirates)
                {
                    if (p.prof== Class.Sailor && manager.sailorsfight==true)
                    {
                        p.mhp-=1f;
                    }else if (p.prof==Class.Fighter)
                    {
                        p.mhp-=1f;
                    }
                }
                
                mult=2;
                add=5;
                SwordFight();
                mult=1;
                add=0;
                break;

            case false:
                Debug.Log("no drug");
                break;
        }

    }
    public void NextStage()
    {
        switch(currentstage)
        {
            case stage.fire:
                currentstage=stage.sword;
                break;
            case stage.sword:
                currentstage=stage.fire;
                break;
        }


        if(manager.HullPoint<=0)
        {
            LoseBattle();
        }
        else if(elp<=0)
        {
            WinBattle();
        }
        else
            {ContinueBattle();}
    }
    public void WinBattle()
    {
        window.SetActive(false);

        int loot = latestenemy.fp*10+latestenemy.sp*10; //to change later

        if (latestenemy.type == Type.Merch)
        {
            int ranF = Random.Range(20, 40);
            resources.food += ranF;

            int ranW = Random.Range(20, 40);
            resources.water += ranW;

            int ranO = Random.Range(20, 40);
            resources.oranges += ranO;

            int ranR = Random.Range(0, 100);

            if (ranR <= 10)
            {
                inventory.AddItem(0, 1);
            }
        }
        else if(latestenemy.type == Type.Pirate)
        {
            int ranB = Random.Range(20, 40);
            resources.booze += ranB;

            int ranO = Random.Range(10, 20);
            resources.oranges += ranO;

            for (int i = 6; i < 3; i++)
            {
                int ranR = Random.Range(0, 100);
                int ranR2 = Random.Range(0, 100);

                if (ranR <= 25)
                {
                    inventory.AddItem(10, 1);
                }

                if(ranR2 <= 15)
                {
                    inventory.AddItem(2, 1);
                }

            }
        }
        

        resources.gold+=loot;

        foreach (pirate p in manager.pirates)
        {
            p.mhp+=1;
        }
        string title ="You win";
        string desc ="You sank the " + latestenemy.name + " and plundered " + loot + " Dobloons!";
        popupmanager.GetComponent<PopupSpawner>().PopEvent(title ,desc);
    }
    public void LoseBattle()
    {
        window.SetActive(false);
        string title ="You lose";
        string desc ="You lose";
        popupmanager.GetComponent<PopupSpawner>().PopEvent(title, desc);
        ManagerScenes.LoadScene(ManagerScenes.scenes.Lose);
    }
    public void RunAway()
    {
        
        window.SetActive(false);
        string title = "Battle Over";
        string desc ="You sailed away from the battle, leaving your enemy behind.\n Better to live to fight another day then to die at the bottom of the sea.";
        popupmanager.GetComponent<PopupSpawner>().PopEvent(title,desc);
    }





    
    // Start is called before the first frame update
    void Start()
    {
        popupmanager = GameObject.FindGameObjectWithTag("popup manager");
        manager=this.gameObject.GetComponent<manager>();
        mult=1;
        add=0;
    }


    public void Update()
    {
        nbullets.text = inventory.NumberOfItem(10).ToString();
        ndrugs.text = inventory.NumberOfItem(9).ToString();
        psp=manager.sailpoint;
        pfp=manager.fightpoint;   
    }




}
