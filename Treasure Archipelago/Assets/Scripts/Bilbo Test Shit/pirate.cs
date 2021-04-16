using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum Class
    {
        //Captain,
        Sailor,
        Fighter,
        //Medic,
        //Musician,
        //Navigator
    };

[System.Serializable]
public class pirate
{
    public string name;

    [HideInInspector]
    public List<Disease> diseases;

    [HideInInspector]
    public float maxphp;
    [HideInInspector]
    public float maxmhp;

    public float php;
    public float mhp;

    public float hunger;
    public float thirst;

    public float vc;
    public bool dead = false;

    public Class prof;

    public pirate()
    {
        diseases = new List<Disease>();
    }

    public void eat(State state)
    {
        if(resources.oranges+resources.food<2)
        {
            state= State.normal;
        }
        if(resources.oranges+resources.food<1)
        {
            state= State.ration;
        }
        if(resources.oranges+resources.food<=0)
        {
            hunger++;
            vc--;
            mhp-=2;
        }
        else 
        {
            switch(state)
            {
                case State.normal:
                    if (resources.oranges!=0){resources.oranges--;vc=50;}
                    else {resources.food--;vc--;}
                    hunger=0;
                    break;
                case State.ration:
                    if (resources.oranges!=0){resources.oranges-=0.5f;}
                    else {resources.food-=0.5f;vc--;}
                     mhp-=1;
                     php-=1;
                    break;
                case State.feast:
                    if (resources.oranges!=0){resources.oranges-=2;vc=50;}
                    else {resources.food-=2;vc--;}
                    hunger=0;
                    mhp+=1;
                    break;
            }
        }

        php-=hunger;
        if (mhp<=0 || php<=0)
        {
            dead = true;
        }
    }

    public void drink(State state)
    {
        if(resources.water+resources.booze<2)
        {
            state= State.normal;
        }
        if(resources.water+resources.booze<1)
        {
            state= State.ration;
        }
        if(resources.water+resources.booze<=0)
        {
            thirst++;
            mhp-=2;
        }
        else 
        {
            switch(state)
            {
                case State.normal:
                    if (resources.booze!=0){resources.booze--;}
                    else {resources.water--;mhp-=0.5f;}
                    thirst=0;
                    break;
                case State.ration:
                    if (resources.booze!=0){resources.booze-=0.5f;}
                    else {resources.water-=0.5f;mhp-=0.5f;}
                     mhp-=1;
                    break;
                case State.feast:
                    if (resources.booze!=0){resources.booze-=2;mhp+=2;}
                    else {resources.water-=2;}
                    thirst=0;
                    break;
            }
        }

        php-=5*thirst;
        if (mhp<=0 || php<=0)
        {
            dead = true;
        }
    }

    
}
