using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponentInChildren<Slider>().value = UserSettings.volume;
    }

    public void BackButton(bool mainmenu)
    {
        if(mainmenu)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
        Debug.Log("Exited options");
    }

    void OnEnable()
    {
        gameObject.GetComponentInChildren<Slider>().value = UserSettings.volume;
    }

    public void ApplyButton()
    {
        Slider s = gameObject.GetComponentInChildren<Slider>();
        UserSettings.volume = s.value;
        SoundManager.UpdateVolume();
    }
}