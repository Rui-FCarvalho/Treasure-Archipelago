using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindowScript : MonoBehaviour
{
    public GameObject Title;
    public GameObject description;

    TextMeshProUGUI titletextpro;

    TextMeshProUGUI desctextpro;


    public void Spawn(string title, string desc)
    {
        titletextpro=Title.GetComponent<TextMeshProUGUI>();
        titletextpro.text=title;

        desctextpro=description.GetComponent<TextMeshProUGUI>();
        desctextpro.text=desc;
    }

    public void close()
    {
        Destroy(this.gameObject);
    }
}
