using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Catalog : MonoBehaviour
{
    public GameObject catalog;
    public GameObject leftText;
    public GameObject rightText;
    public GameObject leftTitle;
    public GameObject rightTitle;
    public GameObject NextButtonCatalog;
    public GameObject PreviousButtonCatalog;

    TextMeshProUGUI leftTextTM;
    TextMeshProUGUI rightTextTM;
    TextMeshProUGUI leftTitleTM;
    TextMeshProUGUI rightTitleTM;

    int numPag;

    void Start()
    {
        leftTextTM = leftText.GetComponent<TextMeshProUGUI>();
        rightTextTM = rightText.GetComponent<TextMeshProUGUI>();
        leftTitleTM = leftTitle.GetComponent<TextMeshProUGUI>();
        rightTitleTM = rightTitle.GetComponent<TextMeshProUGUI>();

        Illness.Initialize();

        numPag = 1;
        SetText(numPag);
    }

    public void ButtonCLick()
    {
        catalog.SetActive(!catalog.activeSelf);
    }

    public void SetText(int numPage)
    {
        if (numPage == 1)
        {
            //Entrance
            leftTextTM.text = "Greetin's.\nHere I shall document many illnesses our crew has come across while on our travels.";

            if (Illness.Desyntery.unlocked)
            {
                rightTitleTM.text = Illness.Desyntery.diseaseName;
                rightTextTM.text = Illness.Desyntery.diseaseDesc;
            }
            else
            {
                rightTitleTM.text = "";
                rightTextTM.text = "";
            }
        }
        else if (numPage == 2)
        {
            if (Illness.Scurvy.unlocked)
            {
                leftTitleTM.text = Illness.Scurvy.diseaseName;
                leftTextTM.text = Illness.Scurvy.diseaseDesc;
            }
            else
            {
                leftTitleTM.text = "";
                leftTextTM.text = "";
            }

            if (Illness.Typhoid.unlocked)
            {
                rightTitleTM.text = Illness.Typhoid.diseaseName;
                rightTextTM.text = Illness.Typhoid.diseaseDesc;
            }
            else
            {
                rightTitleTM.text = "";
                rightTextTM.text = "";
            }
        }
        else
        {
            if (Illness.Typhus.unlocked)
            {
                leftTitleTM.text = Illness.Typhus.diseaseName;
                leftTextTM.text = Illness.Typhus.diseaseDesc;
            }
            else
            {
                leftTitleTM.text = "";
                leftTextTM.text = "";
            }

            if (Illness.Malaria.unlocked)
            {
                rightTitleTM.text = Illness.Malaria.diseaseName;
                rightTextTM.text = Illness.Malaria.diseaseDesc;
            }
            else
            {
                rightTitleTM.text = "";
                rightTextTM.text = "";
            }
        }
    }

    public void Next()
    {
        numPag++;
        if (numPag > 2)
        {
            NextButtonCatalog.SetActive(false);
        }
        PreviousButtonCatalog.SetActive(true);
        SetText(numPag);
    }

    public void Previous()
    {
        numPag--;
        if (numPag < 2)
        {
            PreviousButtonCatalog.SetActive(false);
        }
        NextButtonCatalog.SetActive(true);
        SetText(numPag);
    }
}