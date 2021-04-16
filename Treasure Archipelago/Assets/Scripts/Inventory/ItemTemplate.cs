using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID;
    public string title;
    public string desc;
    public float sellValue;
    public int stack;
    public int maxStack;
    public Sprite Icon;

    public Item(int ID, string title, string desc, 
        float sellValue, int stack, int maxStack)
    {
        this.ID = ID;
        this.title = title;
        this.desc = desc;
        this.sellValue = sellValue;
        this.stack = stack;
        this.maxStack = maxStack;
        this.Icon = Resources.Load<Sprite>(title);
    }

    public Item(Item item)
    {
        this.ID = item.ID;
        this.title = item.title;
        this.desc = item.desc;
        this.sellValue = item.sellValue;
        this.stack = item.stack;
        this.maxStack = item.maxStack;
        this.Icon = Resources.Load<Sprite>(item.title);
    }
}
