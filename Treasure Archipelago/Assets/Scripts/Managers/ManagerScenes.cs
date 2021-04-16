using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public enum scenes //NAME SENSITIVE
    {
        MainMenu = 0,
        Game = 1,
        Lose = 2
    };

    public static void LoadScene(scenes s)//Experimental untested
    {
        SceneManager.LoadScene(s.ToString());
    }
}