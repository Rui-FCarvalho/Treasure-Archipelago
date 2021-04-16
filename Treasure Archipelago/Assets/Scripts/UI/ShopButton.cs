using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{

        public static bool reroll;
        public GameObject window;
        public BuyItem sida;
        public GameObject Inventorysystem;

        




        public void close()
        {
            Inventorysystem.GetComponent<InventorySlotUI>().Redraw(Inventorysystem.GetComponent<InventorySlotUI>().slotPanel);
            window.SetActive(false);
        }


        public void open()
        {

            //sida.GenerateItems();
            Inventorysystem.GetComponent<InventorySlotUI>().Redraw(Inventorysystem.GetComponent<InventorySlotUI>().slotPanel2);
            window.SetActive(true);
        }
}
