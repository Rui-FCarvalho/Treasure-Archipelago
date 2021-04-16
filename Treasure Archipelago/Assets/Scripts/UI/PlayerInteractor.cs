using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteractor : MonoBehaviour
{
    public GameObject menu;
   // public GameObject cleanToggle;
    public GameObject foodMode;
    public GameObject waterMode;
    public GameObject sailMode;
    public GameObject report;

    static Toggle cleanToggleT;
    static TMP_Dropdown foodModeD;
    static TMP_Dropdown sailModeD;
    static TMP_Dropdown waterModeD;
    static TextMeshProUGUI reportT;

    // Start is called before the first frame update
    void Start()
    {
        //cleanToggleT = cleanToggle.GetComponent<Toggle>();
        foodModeD = foodMode.GetComponent<TMP_Dropdown>();
        sailModeD = sailMode.GetComponent<TMP_Dropdown>();
        waterModeD = waterMode.GetComponent<TMP_Dropdown>();
        reportT = report.GetComponent<TextMeshProUGUI>();
    }

    public void ShowMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public static void UpdatePlayerChoices()
    {
        GameObject gamemanager = GameObject.FindGameObjectWithTag("GameController");

        /* if (cleanToggleT.isOn) //clean
        {

        } */

        if (foodModeD.value == 0) //Normal
        {
            gamemanager.GetComponent<manager>().FoodState = State.normal;

        }
        else if (foodModeD.value == 1) //Ration
        {
            gamemanager.GetComponent<manager>().FoodState = State.ration;
        }
        else //Feast
        {
            gamemanager.GetComponent<manager>().FoodState = State.feast;

        }

        if (waterModeD.value == 0) //Normal
        {
            gamemanager.GetComponent<manager>().WaterState = State.normal;

        }
        else if (waterModeD.value == 1) //Ration
        {
            gamemanager.GetComponent<manager>().WaterState = State.ration;
        }
        else //Feast
        {
            gamemanager.GetComponent<manager>().WaterState = State.feast;

        }

        if (sailModeD.value == 0) //Trade route
        {
            gamemanager.GetComponent<manager>().current = Sailmode.TradeRoutes;
        }
        else //High Sea
        {
            gamemanager.GetComponent<manager>().current = Sailmode.HighSeas;
        }
    }

    public static void UpdateReport(float foodDif, float waterDif, float fruitDif, float boozeDif, float coinDif, List<pirate> piratelist)
    {
        int sickcount = 0;
        foreach (pirate p in piratelist)
        {
            if (p.diseases.Count > 0)
            {
                sickcount++;
            }
        }

        reportT.text = sickcount + " out of " + piratelist.Count + " are sick\n" + "Resource Balance:\n Food: " + foodDif + ", Oranges: " + fruitDif+ ", Water: " + waterDif + ", Booze: " + boozeDif + ", Coin: " + coinDif + ".\n";
    }
}