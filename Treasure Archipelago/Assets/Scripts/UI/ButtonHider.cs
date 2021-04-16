using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHider : MonoBehaviour
{
    public List<GameObject> gs;

    static List<Button> bs;

    // Start is called before the first frame update
    void Start()
    {
        bs = new List<Button>();
        foreach (GameObject g in gs)
        {
            bs.Add(g.GetComponent<Button>());
        }
    }

    public static void HideAllBut(Button br)
    {
        foreach (Button b in bs)
        {
            if (br.name != b.name)
            {
                b.gameObject.SetActive(false);
            }
        }
    }

    public static void ShowAll()
    {
        foreach (Button b in bs)
        {
            b.gameObject.SetActive(true);
        }
    }
}