using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool active = false;

    public void ShowInventory()
    {
        inventoryPanel.SetActive(!active); 
        active = !active;
    }
}
