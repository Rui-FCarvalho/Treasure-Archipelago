using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotUI : MonoBehaviour
{
    //UI
    [SerializeField] SlotIndexUI slotPrefab;
    public List<SlotIndexUI> slots = new List<SlotIndexUI>();
    public Transform slotPanel;
    public Transform slotPanel2;
    public int numberOfSlots = 8;

    //Load UI
    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            var instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            instance.index = i;
            slots.Add(instance);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Redraw(slotPanel2);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Redraw(slotPanel);
        }
    }

    public void Redraw(Transform slotp)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].transform.SetParent(slotp);
            UpdateSlot(slots[i].index, slots[i].uItem.item);
        }
    }


    

    public void UpdateSlot(int slot, Item item)
    {
        Debug.Log("I WAS HERE UPDATE");
        slots[slot].uItem.UpdateItem(item);
    }
}
