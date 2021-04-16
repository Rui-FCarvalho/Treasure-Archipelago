using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct PlaceWithCharacteristics
{
    public Place p;
    public Characteristic c;
}

public enum Place
{
    Island = 0,
    Sea = 1,
    Random = 2
};

public enum Characteristic
{
    Habited = 0,
    Desert = 1,
    Ambush = 2,
    Random = 3
};

public class MapManager : MonoBehaviour
{
    //int maxPlaceTypes = 2;
    public GameObject image;
    public static List<PlaceWithCharacteristics> places;

    void Start()
    {
        places = new List<PlaceWithCharacteristics>();
        PlaceWithCharacteristics p = new PlaceWithCharacteristics();
        p.p = Place.Sea;
        p.c = Characteristic.Desert;
        places.Add(p);
    }

    public static void ChoosePlace(Characteristic c, Place p)
    {
        PlaceWithCharacteristics place;
        if (c == Characteristic.Random)
        {
            place.c = RollCharacteristic();
        }
        else
        {
            place.c = c;
        }
        if (p == Place.Random)
        {
            place.p = RollPlace();
        }
        else
        {
            place.p = p;
        }

        //Sound
        /* if (p == Place.Island)
        {
            SoundManager.Stop("Sea");
        }
        else if (places[places.Count - 1].p != Place.Sea)
        {
            SoundManager.Play("Sea");
        } */
        places.Add(place);
    }

    public static Characteristic RollCharacteristic()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int rnd = Random.Range(0, 100); //0-100
        //Debug.Log(rnd + " " + resources.sailmode);

        switch(resources.sailmode)
        {
            case Sailmode.HighSeas:
                if (rnd < 5)
                {
                    Debug.Log("Attack");
                    return Characteristic.Ambush;
                }
                else
                {
                    Debug.Log("Desert");
                    return Characteristic.Desert;
                }
                //break;
            case Sailmode.TradeRoutes:
                if (rnd < 20)
                {
                    Debug.Log("Attack");
                    return Characteristic.Ambush;
                }
                else
                {
                    Debug.Log("Habited");
                    return Characteristic.Habited;
                }
                //break;
            default:
                return Characteristic.Desert;
                //break;
        }
    }

    public static Place RollPlace()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int rnd =  Random.Range(0, 101); //0-100


        switch(resources.sailmode)
        {
            case Sailmode.HighSeas:
                if (rnd < 20)
                {
                    Debug.Log("Land");
                    return Place.Island;
                }
                else
                {
                    Debug.Log("Sea");
                    return Place.Sea;
                }
                //break;
            case Sailmode.TradeRoutes:
                if (rnd < 50)
                {
                    Debug.Log("Land");
                    return Place.Island;
                }
                else
                {
                    Debug.Log("Sea");
                    return Place.Sea;
                }
                //break;
            default:
                Debug.Log("Something failed");
                return Place.Sea;
                //break;
        }
    }

    public static void SetImage(GameObject image, Sprite texture)
    {
        image.GetComponent<Image>().sprite = texture;
    }
}