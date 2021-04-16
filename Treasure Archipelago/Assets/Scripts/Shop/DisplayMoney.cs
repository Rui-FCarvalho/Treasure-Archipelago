using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DisplayMoney : MonoBehaviour
{
    public Text moneyz;
    public float money;

    public void Start()
    {
        moneyz = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        money = resources.gold;
        moneyz.text = money.ToString();
    }
}
