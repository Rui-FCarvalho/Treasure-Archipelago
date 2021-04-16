using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateListButton : MonoBehaviour
{
    public GameObject pirateListUI;
    bool active = false;

    public void PirateListUIButton()
    {
        pirateListUI.SetActive(!active);
        active = !active;
    }
}