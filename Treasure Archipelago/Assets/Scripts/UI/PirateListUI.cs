using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateListUI : MonoBehaviour
{
    manager m;
    Slider[] sliders;

    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("GameController");
        m = g.GetComponent<manager>();
        CreatePirateListUI();
    }

    public void CreatePirateListUI()
    {
        foreach (pirate p in m.pirates)
        {
            GameObject g = (GameObject)Instantiate(Resources.Load("UI/CharacterStatsSlot"));
            //g.transform.parent = gameObject.transform;
            g.transform.SetParent(gameObject.transform, false);

            //Sliders
            sliders = g.GetComponentsInChildren<Slider>();
            //3 simple rule
            sliders[0].value = p.hunger / 15; //hunger ORDER SENSITIVE
            sliders[1].value = p.thirst / 5; //thirst
            sliders[2].value = p.php / p.maxphp; //P Health
            sliders[3].value = p.mhp / p.maxmhp; //M Health

            //Sick Icon
            Sick_Icon s = g.GetComponentInChildren<Sick_Icon>();
            if(p.diseases.Count > 0)
            {
                s.IconShow();
            }
        }
    }

    void Update()
    {
        UpdatePirateListUI();
    }

    public void UpdatePirateListUI()
    {
        CheckListRemovedAdded();
        int i = 0;
        foreach (pirate p in m.pirates)
        {
            //sliders + nome
            sliders = gameObject.transform.GetChild(i).GetComponentsInChildren<Slider>();
            gameObject.transform.GetChild(i).GetComponentInChildren<Text>().text = p.name;
            sliders[0].value = p.hunger / 15;
            sliders[1].value = p.thirst / 5;
            sliders[2].value = p.php / p.maxphp; //P Health
            sliders[3].value = p.mhp / p.maxmhp; //P Health

            //sick
            Sick_Icon s = gameObject.transform.GetChild(i).GetComponentInChildren<Sick_Icon>();
            if(p.diseases.Count > 0)
            {
                s.IconShow();
            }
            else
            {
                s.IconHide();
            }

            i++;
        }
    }

    public void CheckListRemovedAdded()
    {
        if (gameObject.transform.childCount != m.pirates.Count)
        {
            Debug.Log("Change detected on pirate list");
            RemoveAllFromList();
            if (gameObject.transform.childCount != 0)
            {
                CreatePirateListUI();
            }
        }
    }

    public void RemoveAllFromList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}