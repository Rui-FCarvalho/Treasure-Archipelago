using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum Resource
{
    food, 
    oranges, 
    water, 
    booze, 
    gold,
};

public class ResourcesUI : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;

    public Resource tittymilk;

    // Use this for initialization
    void Start()
    {
        textmeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
            switch(tittymilk) {
                case Resource.food :
                    textmeshPro.text = resources.food.ToString();
                    break;
                case Resource.oranges :
                    textmeshPro.text = resources.oranges.ToString();
                    break;
                case Resource.water :
                    textmeshPro.text = resources.water.ToString();
                    break;
                case Resource.booze :
                    textmeshPro.text=resources.booze.ToString();
                    break;
                case Resource.gold :
                    textmeshPro.text=resources.gold.ToString();
                    break;

            }
    }
}
