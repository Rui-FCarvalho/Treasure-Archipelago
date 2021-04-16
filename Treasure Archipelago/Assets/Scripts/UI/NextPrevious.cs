using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPrevious : MonoBehaviour
{
    int current = 0;

    public manager gamemanager;
    public BattleScript battlemanager;
    public GameObject image;
    public GameObject shopbutton;
    public Sprite island, shop, ambush, sea, seabattle;
    public GameObject text, currentButton;
    public BuyItem openStore;

    void Start()
    {
        battlemanager=GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleScript>();

        gamemanager=GameObject.FindGameObjectWithTag("GameController").GetComponent<manager>();
    }

    public void Next()
    {
        
        Debug.Log(resources.sailmode);
        gamemanager.passturn();
        if (current == MapManager.places.Count)
        {
            //Debug.Log("Making new place...");
            MapManager.ChoosePlace(MapManager.RollCharacteristic(), MapManager.RollPlace());
            //Debug.Log("Place chosen...");
            current = MapManager.places.Count;
            //Debug.Log("Visited " + MapManager.places.Count + " places.");
        }
        else
        {
            //Debug.Log("Moving to next place...");
            current++;
        }
        if (openStore.open == true)
        {
            openStore.open = false;
           for(int i = 0; i<openStore.buttons.Count; i++)
            {
                openStore.buttons[i].interactable = true;
            }
        }
        SetImage();
        SetText();
    }

    public void Previous()
    {
        if (current > 1)
        {
            //Debug.Log("Moving back...");
            current--;
            SetPImage();
            SetText();
        }
        else
        {
            //Debug.Log("Can't go back! current is: " + current);
        }
    }

    public void CurrentPosition()
    {
        current = MapManager.places.Count;
        SetPImage();
        SetText();
    }

    public void SetText()
    {
        if (current == MapManager.places.Count)
        {
            currentButton.SetActive(false);
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
            currentButton.SetActive(true);
        }
    }

    public void SetImage()   //script encounters run here
    {
        shopbutton.SetActive(false);
        
        //Debug.Log("Setting map image...");
        if (MapManager.places[current - 1].p == Place.Island)
        {

            switch(MapManager.places[current - 1].c)
            {
                case Characteristic.Desert:
                    MapManager.SetImage(image, island);
                    break;
                case Characteristic.Ambush:             //Island fights only in high sea mode '????
                    if (resources.sailmode==Sailmode.HighSeas)
                    {
                        MapManager.SetImage(image,ambush);
                        battlemanager.ChooseEnemy();
                    }
                    if (resources.sailmode==Sailmode.TradeRoutes)
                    {
                        shopbutton.SetActive(true);
                        MapManager.SetImage(image,shop);
                    }
                    break;
                case Characteristic.Habited:
                    shopbutton.SetActive(true);
                    MapManager.SetImage(image,shop);
                    break;
            }
        }
        if (MapManager.places[current - 1].p == Place.Sea)
        {
            MapManager.SetImage(image, sea);
            switch(MapManager.places[current - 1].c)
            {
                case Characteristic.Desert:
                    MapManager.SetImage(image, sea);
                    break;
                case Characteristic.Ambush:
                    MapManager.SetImage(image,seabattle);
                    battlemanager.ChooseEnemy();
                    break;
                case Characteristic.Habited:
                    MapManager.SetImage(image,sea);
                    break;
            }
            
        }
    }

        public void SetPImage()   //script encounters run here
    {
        
        //Debug.Log("Setting map image...");
        if (MapManager.places[current - 1].p == Place.Island)
        {

            switch(MapManager.places[current - 1].c)
            {
                case Characteristic.Desert:
                    MapManager.SetImage(image, island);
                    break;
                case Characteristic.Ambush:             //Island fights only in high sea mode '????
                    if (resources.sailmode==Sailmode.HighSeas)
                    {
                        MapManager.SetImage(image,ambush);
                        //battlemanager.ChooseEnemy();
                    }
                    if (resources.sailmode==Sailmode.TradeRoutes)
                    {
                        MapManager.SetImage(image,shop);
                    }
                    break;
                case Characteristic.Habited:
                    
                    MapManager.SetImage(image,shop);
                    break;
            }
        }
        if (MapManager.places[current - 1].p == Place.Sea)
        {
            MapManager.SetImage(image, sea);
            switch(MapManager.places[current - 1].c)
            {
                case Characteristic.Desert:
                    MapManager.SetImage(image, sea);
                    break;
                case Characteristic.Ambush:
                    MapManager.SetImage(image,seabattle);
                    //battlemanager.ChooseEnemy();
                    break;
                case Characteristic.Habited:
                    MapManager.SetImage(image,sea);
                    break;
            }
            
        }
    }
}