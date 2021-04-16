using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyItem : MonoBehaviour
{
    public ItemDatabase dataBase;
    public Inventory inv;

    int dataCount;

    public bool open;

    int BuyI;

    public List<Button> buttons = new List<Button>();

    public List<Image> images = new List<Image>();

    public List<Text> texts = new List<Text>();

    public List<Item> items = new List<Item>();

    public void Start()
    {
        open = false;
        dataBase = GameObject.Find("ItemDataBase").GetComponent<ItemDatabase>();
        inv = GameObject.Find("InventoryStuff").GetComponent<Inventory>();

        dataCount = dataBase.items.Count;

        for (int i = 0; i < dataCount; i++)
        {
            if(dataBase.items[i].ID > 5)
            {
                BuyI += 1;
                Debug.Log(BuyI);
            }
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].name = i.ToString();
            images.Add(buttons[i].GetComponent<Image>());
            texts.Add(buttons[i].GetComponentInChildren<Text>());
            items.Add(dataBase.items[0]);
        }

        GenerateItems();
    }

    public void GenerateItems()
    {
        if (open == false)
        {
            open = true;
            for (int i = 0; i < 4; i++)
            {
                int ranN = Random.Range(dataCount - BuyI, dataCount);
                Debug.Log("I was here");
                Debug.Log(images[i].sprite);
                images[i].sprite = Resources.Load<Sprite>(dataBase.items[ranN].title);
                items[i] = dataBase.items[ranN];
                texts[i].text = (dataBase.items[ranN].sellValue + Random.Range(3, 20)).ToString();
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for(int i = 0; i<buttons.Count; i++)
            {
                buttons[i].interactable = true;
            }
            GenerateItems();
        }
    }

    public void BuyItemStuff()
    {
        Debug.Log("I was here 1");
        for(int i = 0; i< buttons.Count; i++)
        {
            Debug.Log("I was here cycle");
            if (EventSystem.current.currentSelectedGameObject.name.ToString() == buttons[i].name.ToString())
            {
                Debug.Log("I was here inside");
                int value = int.Parse(texts[i].text);
                Debug.Log(value);
                if(resources.gold < value)
                {
                    Debug.Log("lolol no moneyzz ");
                    return;
                }
                inv.AddItem(items[i].ID, 1);
                resources.gold -= value;
                buttons[i].interactable = false;
                images[i].sprite = Resources.Load<Sprite>("Sold");
                texts[i].text = "";
                return;
            }
        }
    }
}
