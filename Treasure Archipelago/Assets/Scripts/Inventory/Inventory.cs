using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    //Stuff
    // public List<Item> itemList = new List<Item>();
    public ItemDatabase dataBase;
    public InventorySlotUI slotUi;

    private void Start()
    {
        //AddItem(1, 2);
    }

    public bool FindItem(int ID)
    {
        int ver = slotUi.slots.FindIndex(i => i.uItem != null && i.uItem.item.ID == ID);

        if(ver == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int NumberOfItem(int ID)
    {
        int count = 0;
        for(int i = 0; i < slotUi.slots.Count; i++)
        {
            if(slotUi.slots[i].uItem.item!= null && slotUi.slots[i].uItem.item.ID == ID)
            {
                count += slotUi.slots[i].uItem.item.stack;
            }
        }
        return count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
        //    AddItem(10, 1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
         //   RemoveItem(10, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
         //   AddItem(0, 12);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
          //  RemoveItem(0, 10);
        }
    }

    public void AddItem(int ID, int n)
    {
        Item item = dataBase.GetItem(ID);
        Item item2 = new Item(item.ID, item.title, item.desc, item.sellValue, item.stack, item.maxStack);

        int slot = slotUi.slots.FindIndex(k => k.uItem.item != null && 
        k.uItem.item.ID == item.ID && 
        k.uItem.item.stack < item.maxStack);

        Debug.Log(slot);

        if (slot == -1)
        {
            slot = slotUi.slots.FindIndex(k => k.uItem.item == null);
            if(slot == -1)
            {
                Debug.Log("INVENTORY FULL");
                return;
            }

            slotUi.slots[slot].uItem.item = item2;
            slotUi.UpdateSlot(slot, item2);
            n -= 1;

        }
        Debug.Log("slot pos if" + slot);

        for (int i = 0; i < n; i++)
        {
            if (slotUi.slots[slot].uItem.item.stack < slotUi.slots[slot].uItem.item.maxStack)
            {
                slotUi.slots[slot].uItem.item.stack += 1;
                slotUi.UpdateSlot(slot, slotUi.slots[slot].uItem.item);
                Debug.Log("stack " + slotUi.slots[slot].uItem.item.stack);
            }

            else
            {
                Debug.Log("Adding Item" + item2);
                item2 = new Item(item.ID, item.title, item.desc, item.sellValue, item.stack, item.maxStack);
                slot = slotUi.slots.FindIndex(k => k.uItem.item == null);
                slotUi.slots[slot].uItem.item = item2;
                Debug.Log("slot pos add for" + slot);
                slotUi.UpdateSlot(slot, item2);
            }
        }

        Debug.Log(slotUi.slots[slot].uItem.item.stack);
        Debug.Log("Added item: " + item.title);
    }

    public void RemoveItem(int ID, int n)
    {
        Item item = dataBase.GetItem(ID);

        int slot = slotUi.slots.FindIndex(k => k.uItem.item != null && k.uItem.item.ID == item.ID);
        Debug.Log("SLOT 1:  " + slot);

        if (slot != -1)
        {
            for (int i = 0; i < n; i++)
            {            
                slotUi.slots[slot].uItem.item.stack -= 1;
                slotUi.UpdateSlot(slot, slotUi.slots[slot].uItem.item);

                Debug.Log("-1 stack");
                Debug.Log(slotUi.slots[slot].uItem.item.stack);

                if (slotUi.slots[slot].uItem.item.stack <= 0)
                {
                    Debug.Log("I WAS HERE");

                    slotUi.UpdateSlot(slot, null);
                    slot = slotUi.slots.FindIndex(k => k.uItem.item != null && k.uItem.item.ID == item.ID);

                    if(slot == -1)
                    {
                        Debug.Log("EVERYTHING DELETED");
                        return;
                    }
                }
            }

            Debug.Log("Item Removed: " + item.title);
        }
    }
}

