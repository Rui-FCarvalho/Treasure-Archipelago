using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    public GameObject mapUI;
    bool active = false;

    public void ShowMap()
    {
        mapUI.SetActive(!active);
        active = !active;
    }
}