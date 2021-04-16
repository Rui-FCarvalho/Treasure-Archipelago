using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEscFunctionality : MonoBehaviour
{
    bool active = false;
    public GameObject optionsMenu;
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) DEBUG ONLY
        //{
        //    gameObject.transform.GetChild(0).gameObject.SetActive(!active);
        //    active = !active;
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }

    public void ShowList()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(!active);
        active = !active;
    }
}