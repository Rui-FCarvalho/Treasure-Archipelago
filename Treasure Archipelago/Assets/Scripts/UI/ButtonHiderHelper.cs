using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHiderHelper : MonoBehaviour
{
    public GameObject respectivebutton;
    Button b;

    void Start()
    {
        b = respectivebutton.GetComponent<Button>();
        OnEnable();
    }

    void OnEnable()
    {
        try
        {
            ButtonHider.HideAllBut(b);
        }
        catch
        {
            //Debug.Log("Np");
        }
    }

    void OnDisable()
    {
        ButtonHider.ShowAll();
    }
}