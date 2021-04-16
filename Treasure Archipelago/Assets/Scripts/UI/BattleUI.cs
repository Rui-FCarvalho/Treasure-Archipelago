using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum Stats
{
    efp,
    esp,
    psp,
    pfp,
    plp,
    elp,
    stage
}
public class BattleUI : MonoBehaviour
{
    TextMeshProUGUI textmeshPro;
    public BattleScript bs;
    public Stats tittymilk;

    // Use this for initialization
    void Start()
    {
        textmeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        bs=GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
            switch(tittymilk) 
            {
                case Stats.efp:
                    textmeshPro.text =  "Enemy has: " + bs.efp.ToString() + " Fight Points";
                    break;
                case Stats.esp:
                    textmeshPro.text = "Enemy has: " + bs.esp.ToString() + " Sail Points";
                    break;
                case Stats.psp:
                    textmeshPro.text = "You have: " + bs.psp.ToString() + " Sail Points";
                    break;
                case Stats.pfp:
                    textmeshPro.text = "You have: " +  bs.pfp.ToString() + " Fight Points";
                    break;
                case Stats.plp:
                    textmeshPro.text = "Your ship has: " + bs.manager.HullPoint.ToString() + " HitPoints Left";
                    break;
                case Stats.elp:
                    textmeshPro.text = "Enemy ship has: " + bs.elp.ToString() + " HitPoints Left";
                    break;
                case Stats.stage:
                    switch(bs.currentstage)
                    {
                        case stage.fire:
                            textmeshPro.text = bs.currentstage.ToString() + " stage" + "\n In this stage you can trade cannon fire with your enemy while the sailors try to manouver the ships out of harms way.\n Alternativelly you can try so sail away from this battle.";
                            break;
                        case stage.sword:
                            textmeshPro.text = bs.currentstage.ToString() + " stage" + "\n In this stage In this stage your fighters will fight the enemy crew and try to board their ship to do heavy damage.\n You can order your sailors to fight too but be careful: untrained people do not make good fighters and may not be able to handle the stress of fighting.\n If you don't think that fighting is a good idea you can try to disengage the enemy ship and move to a safe distance";
                            break;
                    }
                    //textmeshPro.text = bs.currentstage.ToString();
                    break;
            }
    }
}
