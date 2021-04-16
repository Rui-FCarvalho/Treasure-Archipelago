using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButton : MonoBehaviour
{

    public GameObject quiz;
    public void ButtonCLick()
    {
        quiz.SetActive(!quiz.activeSelf);
    }
}
