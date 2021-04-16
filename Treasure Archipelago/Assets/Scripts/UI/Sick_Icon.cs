using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sick_Icon : MonoBehaviour
{
    public GameObject icon;

    // Start is called before the first frame update
    public void IconShow()
    {
        icon.SetActive(true);
    }

    public void IconHide()
    {
        icon.SetActive(false);
    }
}