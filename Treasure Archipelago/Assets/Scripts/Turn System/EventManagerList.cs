using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct EventToPirateList
{
    public Event choosenEvent;
    public List<pirate> pirates;
}

public class EventManagerList : MonoBehaviour
{
    public List<Event> eventToCopy;
    public List<GlobalEvent> globaleventstocopy;
    public static List<Event> events;
    public static List<GlobalEvent> globalevents;

    void Start()
    {
        events = eventToCopy;
        globalevents = globaleventstocopy;
    }

    public static void Turn()
    {
        GameObject test;
        int count = 0;

        test = GameObject.FindGameObjectWithTag("popup manager");
        
        //Particular events
        List<EventToPirateList> list = AvailableEvents(GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().pirates);
        foreach (EventToPirateList v in list)
        {
            
            Random.InitState(System.DateTime.Now.Millisecond);
            int rnd = Random.Range(0, 101);//min inclusive, max exclusive
            if (rnd <= v.choosenEvent.chance)
            {
                string title = v.choosenEvent.Name;
                string desc=v.choosenEvent.Description;
                test.GetComponent<PopupSpawner>().PopEvent(title + " has happened to " + v.pirates[count].name , desc);
                Debug.Log(v.choosenEvent.Name + " is happening");
                ApplyEvent(v);
            }
            else
            {
                //Debug.Log(v.choosenEvent.Name + " is NOT happening");
            }
            count += 1;
        }

        //Global events
        List<GlobalEvent> list2 = AvailableGlobalEvents();
        foreach(GlobalEvent e in list2)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            int rnd = Random.Range(0, 101);//min inclusive, max exclusive
            if (rnd <= e.chance)
            {
                test.GetComponent<PopupSpawner>().PopEvent(e.Name,e.Description);
                //Debug.Log(e.Name + " is happening");
                ApplyGlobalEvent(e);
            }
            else
            {
                //Debug.Log(e.Name + " is NOT happening");
            }
        }
        
    }

    public static List<GlobalEvent> AvailableGlobalEvents()
    {
        List<GlobalEvent> tempglobalevents = new List<GlobalEvent>();

        float mhmedia = 0;
        float phmedia = 0;
        int count = 0;

        foreach(pirate p in GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().pirates)
        {
            mhmedia += p.mhp;
            phmedia += p.php;
            count++;
        }

        mhmedia = mhmedia / count;
        phmedia = phmedia / count;

        foreach(GlobalEvent e in globalevents)
        {
            bool add = true;
            foreach (RequirementGlobal r in e.requirements)
            {
                if (!CheckFood(r.requirementType, r.bigger,resources.food , r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckWater(r.requirementType, r.bigger, resources.water, r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckOranges(r.requirementType, r.bigger, resources.booze, r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckMH(r.requirementType, r.bigger, mhmedia, r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckPH(r.requirementType, r.bigger, phmedia, r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckCoin(r.requirementType, r.bigger, resources.gold, r.requirement))
                {
                    add = false;
                    break;
                }
                if (!CheckDirtiness(r.requirementType, r.bigger, resources.dirtiness, r.requirement))
                {
                    add = false;
                    break;
                }
            }
            if(add)
            {
                tempglobalevents.Add(e);
            }
        }

        return tempglobalevents;
    }

    public static List<EventToPirateList> AvailableEvents(List<pirate> pirates)
    {
        List<EventToPirateList> tempevent = new List<EventToPirateList>();

        foreach (Event e in events)
        {
            EventToPirateList etp = new EventToPirateList();
            etp.choosenEvent = e;
            etp.pirates = new List<pirate>();
            foreach (pirate p in pirates)
            {
                bool add = true;
                foreach (Requirement r in e.requirements)
                {
                    if (!CheckHunger(r.requirementType, r.bigger, p.hunger, r.requirement))
                    {
                        add = false;
                        break;
                    }
                    if (!CheckThirst(r.requirementType, r.bigger, p.thirst, r.requirement))
                    {
                        add = false;
                        break;
                    }
                    if (!CheckPH(r.requirementType, r.bigger, p.php, r.requirement))
                    {
                        add = false;
                        break;
                    }
                    if (!CheckMH(r.requirementType, r.bigger, p.mhp, r.requirement))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    etp.pirates.Add(p);
                }
            }
            if (etp.pirates.Count > 0)
            {
                tempevent.Add(etp);
            }
        }
        return tempevent;
    }

    public static bool CheckFood(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.Food)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckWater(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.Water)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckOranges(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.Fruit)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckCoin(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.Coin)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckDirtiness(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.cleanliness)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckMH(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.MH)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckPH(ResourceGlobal r, bool bigger, float resourcestat, int requirement)
    {
        if (r == ResourceGlobal.PH)
        {
            if (bigger)
            {
                if (resourcestat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (resourcestat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckHunger(Stat s, bool bigger, float pirateStat, int requirement)
    {
        if (s == Stat.Food) //FOOD
        {
            if (bigger)
            {
                if (pirateStat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (pirateStat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckThirst(Stat s, bool bigger, float pirateStat, int requirement)
    {
        if (s == Stat.Water) //FOOD
        {
            if (bigger == true)
            {
                if (pirateStat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (pirateStat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckPH(Stat s, bool bigger, float pirateStat, int requirement)
    {
        if (s == Stat.PH) //PHYSICAL HEALTH
        {
            if (bigger == true)
            {
                if (pirateStat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (pirateStat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static bool CheckMH(Stat s, bool bigger, float pirateStat, int requirement)
    {
        if (s == Stat.MH) //MENTAL HEALTH
        {
            if (bigger == true)
            {
                if (pirateStat <= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
            else
            {
                if (pirateStat >= requirement)//doesn't satisfy requirement
                {
                    return false;//won't add
                }
            }
        }
        return true;
    }

    public static void ApplyGlobalEvent(GlobalEvent e)
    {
        foreach(EffectGlobal effect in e.effects)
        {
            if (effect.effectType == ResourceGlobal.Food)
            {
                resources.food += effect.effect;
            }
            else if (effect.effectType == ResourceGlobal.Water)
            {
                resources.water += effect.effect;
            }
            else if(effect.effectType == ResourceGlobal.MH)
            {
                List<pirate> ps = GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().pirates;

                foreach(pirate p in ps)
                {
                    p.mhp += effect.effect;
                }
            }
            else if (effect.effectType == ResourceGlobal.PH)
            {
                List<pirate> ps = GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>().pirates;

                foreach (pirate p in ps)
                {
                    p.php += effect.effect;
                }
            }
            else if(effect.effectType == ResourceGlobal.Booze)
            {
                resources.booze += effect.effect;
            }
            else if (effect.effectType == ResourceGlobal.Fruit)
            {
                resources.oranges += effect.effect;
            }
        }
    }

    //public static void ApplyAllEvent(Event e, List<pirate> pirates)
    //{
    //    foreach (pirate p in pirates)
    //    {
    //        foreach (Effect effect in e.effects)
    //        {
    //            if (effect.effectType == Stat.Food)
    //            {
    //                p.hunger += effect.effect;
    //            }
    //            else if (effect.effectType == Stat.Water)
    //            {
    //                p.thirst += effect.effect;
    //            }
    //        }
    //    }
    //}

    public static void ApplyEvent(EventToPirateList eventAndPirates)
    {
        foreach (pirate p in eventAndPirates.pirates)
        {
            foreach (Effect effect in eventAndPirates.choosenEvent.effects)
            {
                if (effect.effectType == Stat.Food)
                {
                    p.hunger += effect.effect;
                }
                else if (effect.effectType == Stat.Water)
                {
                    p.thirst += effect.effect;
                }
                else if (effect.effectType == Stat.MH)
                {
                    p.mhp += effect.effect;
                }
                else if (effect.effectType == Stat.PH)
                {
                    p.php += effect.effect;
                }
            }
        }
    }
}