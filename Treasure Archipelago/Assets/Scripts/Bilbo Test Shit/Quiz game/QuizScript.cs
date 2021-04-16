using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizScript : MonoBehaviour
{
        [System.Serializable]
        public class Question
    {
        public string question;
        public bool aswer;
    }
    public List<Question> questions= new List<Question>();
    Question thisquestion;
    public TextMeshProUGUI tquestion;
    public TextMeshProUGUI tanswer;

    public void ChooseQuestion()
    {
        thisquestion= questions [Random.Range(0,questions.Count)];
        tquestion.text=thisquestion.question;
    }


    public void Atrue()
    {
        switch (thisquestion.aswer)
        {
            case true:
                tanswer.text="Yer' Right";
                ChooseQuestion();
                break;
            case false:
                tanswer.text="Yer' Wrong";
                ChooseQuestion();
                break;
        }
    }

    public void Afalse()
    {
        switch (thisquestion.aswer)
        {
            case false:
                tanswer.text="Yer' Right";
                ChooseQuestion();
                break;
            case true:
                tanswer.text="Yer' Wrong";
                ChooseQuestion();
                break;
        }
    }

    

    void Start()
    {
        ChooseQuestion();
        
    }
}
