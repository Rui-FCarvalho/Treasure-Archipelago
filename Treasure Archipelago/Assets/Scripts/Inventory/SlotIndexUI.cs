using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotIndexUI : MonoBehaviour, IDropHandler
{
    public int index;
    public UIItem uItem;

    public InventorySlotUI ui;
    public void Awake()
    {
        uItem = GetComponentInChildren<UIItem>();
        ui = GameObject.Find("InventorySystem").GetComponent<InventorySlotUI>();
        ui.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var Ui_item = eventData.pointerDrag.GetComponent<UIItem>();

        if (Ui_item._parentSlot == null)
        {
            Item item1;

            item1 = Ui_item.item;
            Ui_item.UpdateItem(uItem.item);
            ui.UpdateSlot(index, item1);
            return;
        }

        if (Ui_item._parentSlot.index == index || Ui_item.item == null)
        {
            return;
        }

        Item item;

        item = uItem.item;
        uItem.item = Ui_item.item;
        Ui_item.item = item;

        Debug.Log(Ui_item.item);
        Debug.Log(uItem.item);
        ui.UpdateSlot(index, uItem.item);
        ui.UpdateSlot(Ui_item._parentSlot.index, Ui_item.item);
    }
}
