using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        SoundManager.Play("YouAreAPirate");
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SoundManager.Stop("YouAreAPirate");
        //Debug.Log("Stopped music...");
        ManagerScenes.LoadScene(ManagerScenes.scenes.Game);
        //Debug.Log("Loaded scene...");
        SoundManager.Play("Sea");
        //Debug.Log("Started music...");
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
    }
}