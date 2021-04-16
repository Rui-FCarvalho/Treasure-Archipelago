using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSpawner : MonoBehaviour
{

    public GameObject Eventwindow;
    public GameObject canvas;




    public void PopEvent(string title, string desc)
    {
         GameObject Evento = Instantiate(Eventwindow) as GameObject;
         Evento.GetComponent<WindowScript>().Spawn(title,desc);
         Evento.transform.SetParent(canvas.transform);
         Evento.transform.position=canvas.transform.position;
    }
}
