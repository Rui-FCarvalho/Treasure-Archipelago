using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotSellUI : MonoBehaviour, IDropHandler
{
    public UIItem uItem;
    public Text text;

    public InventorySlotUI ui;
    public void Awake()
    {
        uItem = GetComponentInChildren<UIItem>();
        ui = GameObject.Find("InventorySystem").GetComponent<InventorySlotUI>();
        ui.enabled = true;
        text = GetComponentInChildren<Text>();
    }

    public void Update()
    {

        if (uItem.item != null)
        {
            Debug.Log("I'm here");
            text.text = (uItem.item.sellValue * uItem.item.stack).ToString();
        }
        else
        {
            text.text = "";
        }
    }

    public void SellButton()
    {
        resources.gold += uItem.item.sellValue * uItem.item.stack;
        uItem.UpdateItem(null);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var Ui_item = eventData.pointerDrag.GetComponent<UIItem>();

        Item item;

        item = uItem.item;
        uItem.item = Ui_item.item;
        Ui_item.item = item;

        Debug.Log(Ui_item.item);
        Debug.Log(uItem.item.title);
        uItem.UpdateItem(uItem.item);
        ui.UpdateSlot(Ui_item._parentSlot.index, Ui_item.item);
    }
}

