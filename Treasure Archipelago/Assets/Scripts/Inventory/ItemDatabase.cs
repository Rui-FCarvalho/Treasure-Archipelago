using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int ID)
    {
        return items.Find(item => item.ID == ID);
    }

    void BuildDatabase()
    {
        //PUT IMAGES WITH PROPER NAME ON RESOURCES FOLDER  TITLE = IMAGE NAME ON FOLDER PLEASE
        items = new List<Item>() {
            new Item(0, "Treasure", "xDDDDDD", 150f, 1, 1),
            new Item(1, "Cute", "AYAYAYA", 17f, 1, 5),
            new Item(2, "Zoro", "Reboot Please", 1500f, 1, 8),
            new Item(9, "Adrenaline", "Make fighter stronk", 15f, 1, 10),
            new Item(10, "Bomb", "Fire for more dmg", 25f, 1, 10)

        };
    }


}
