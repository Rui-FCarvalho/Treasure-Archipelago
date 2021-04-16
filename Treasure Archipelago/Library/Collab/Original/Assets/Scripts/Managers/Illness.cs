using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease
{
    public string diseaseName;
    public List<Effect> effects; //Stat + Int
    public string diseaseDesc;
    public int duration;
    public int daysActive;

    public Disease(string diseaseName, List<Effect> effects, string diseaseDesc, int duration)
    {
        daysActive = 0;
        this.diseaseDesc = diseaseDesc;
        this.diseaseName = diseaseName;
        this.effects = effects;
        this.duration = duration;
    }
};

public class Illness
{
    static List<Effect> effectstemp;
    public static Disease Desyntery, Malaria, Typhoid, Typhus, Scurvy;
    static bool one = true;

    static void Initialize()
    {
        List<Effect> effects;
        string desc;
        Effect e, e2;
        

        //Dysentery
        effects = new List<Effect>();
        e = new Effect(Stat.Water, -5);
        effects.Add(e);
        e2 = new Effect(Stat.cleanliness, -5);
        effects.Add(e2);

        effectstemp = effects;
        desc = "An inflammatory disease of the intestine, especially of the colon, which always results in severe diarrhea and abdominal pains. Other symptoms may include fever and a feeling of incomplete defecation.";
        Desyntery = new Disease("Desyntery", effectstemp, desc, 7);

        //Malaria
        effects = new List<Effect>();
        e = new Effect(Stat.cleanliness, -2);
        effects.Add(e);
        e2 = new Effect(Stat.MH, -2);
        effects.Add(e2);

        effectstemp = effects;
        desc = "Malaria causes symptoms that typically include fever, tiredness, vomiting, and headaches.";
        Malaria = new Disease("Malaria", effectstemp, desc, 30);

        //Typhoid
        effects = new List<Effect>();
        e = new Effect(Stat.MH, -3);
        effects.Add(e);

        effectstemp = effects;
        desc = "Often there is a gradual onset of a high fever, weakness, abdominal pain, constipation, headaches, and mild vomiting also commonly occur. Other people may carry the bacterium without being affected, however, they are still able to spread the disease to others.";
        Typhoid = new Disease("Typhoid", effectstemp, desc, 30);

        //Typhus
        effects = new List<Effect>();
        e = new Effect(Stat.PH, -1);
        effects.Add(e);

        effectstemp = effects;
        desc = "Common symptoms include fever, headache, and a rash.The diseases are caused by specific types of bacterial infection. Epidemic typhus is spread by body lice, scrub typhus is spread by chiggers, and murine typhus is spread by fleas.";
        Typhus = new Disease("Typhus", effectstemp, desc, 30);

        //Scurvy
        effects = new List<Effect>();
        e = new Effect(Stat.PH, -2);
        effects.Add(e);

        effectstemp = effects;
        desc = "A disease resulting from a lack of vitamin C (ascorbic acid). Early symptoms include weakness, feeling tired, and sore arms and legs. Without treatment, decreased red blood cells, gum disease, changes to hair, and bleeding from the skin may occur.";
        Scurvy = new Disease("Scurvy", effectstemp, desc, 14);
    }

    public static void TurnDisease(List <pirate> ps) //USE THIS BILBO
    {
        Debug.Log("Disease logic...");

        if(one)
        {
            Initialize();
            Debug.Log("Initialized diseases...");
            one = false;
        }
        DiseaseChance(ps);

        Debug.Log("Effecting diseases...");

        //Apply disease effects
        foreach (pirate p in ps)
        {
            List<Disease> bcsunityD = new List<Disease>();
            foreach (Disease d in p.diseases)//MAKE A BCS UNITY
            {
                d.daysActive++;
                applyDiseaseEffects(d, p, bcsunityD);
            }

            foreach(Disease d in bcsunityD)//removing diseases, kill live?
            {
                p.diseases.Remove(d);
            }
        }
    }

    public static void applyDiseaseEffects(Disease d, pirate p,List<Disease>bcsunity)
    {
        d.daysActive++;
        if (d.daysActive < d.duration)
        {
            foreach (Effect effect in d.effects)
            {
                if (effect.effectType == Stat.Food)
                {
                    p.hunger += effect.effect;
                }
                else if (effect.effectType == Stat.Water)
                {
                    p.thirst += effect.effect;
                }
                else if (effect.effectType == Stat.MH)
                {
                    p.mhp += effect.effect;
                }
                else if (effect.effectType == Stat.PH)
                {
                    p.php += effect.effect;
                }
            }
        }
        else
        { 
            bcsunity.Add(d);
        }
    }

    public static void DiseaseChance(List <pirate> ps)
    {
        PopupSpawner popups=GameObject.FindGameObjectWithTag("popup manager").GetComponent<PopupSpawner>();
        Debug.Log("Chancing diseases...");

        Random.InitState(System.DateTime.Now.Millisecond);

        int dnum = 0, tnum = 0;
        foreach (pirate p in ps)
        {
            if (p.diseases.Contains(Desyntery))
            {
                dnum++;
            }
            if (p.diseases.Contains(Typhoid))
            {
                tnum++;
            }
        }

        //Desyntery
        float chance = Mathf.Clamp((100 * resources.dirtiness) / 50 + 5 * dnum, 0, 80); //between 0-80, colleages can spread
        foreach (pirate p in ps)
        {
            if (!p.diseases.Contains(Desyntery))
            {
                int r = Random.Range(0, 100);
                if (r < chance)//gets disease
                {
                    
                    Debug.Log(r + "number ->" + p.name + " got " + Desyntery.diseaseName + " chance: " + chance);

                    popups.PopEvent(p.name + " got " + Desyntery.diseaseName + "!", Desyntery.diseaseDesc);
                    
                    p.diseases.Add(Desyntery);
                }
            }
        }

        //Malaria
        chance = 0;
        if(MapManager.places[MapManager.places.Count -1].p == Place.Island)
        {
            chance = 30;
        }

        chance += ((100 * resources.dirtiness) / 50 * 100) / 10; //adds 10% of dirtiness

        foreach(pirate p in ps)
        {
            if (!p.diseases.Contains(Malaria))
            {
                int r = Random.Range(0, 100);
                if (r < chance)//gets disease
                {
                    Debug.Log(r + "number ->" + p.name + " got " + Malaria.diseaseName + " chance: " + chance);
                    popups.PopEvent(p.name + " got " + Malaria.diseaseName + "!", Malaria.diseaseDesc);
                    p.diseases.Add(Malaria);
                }
            }
        }

        //Typhoid
        chance = Mathf.Clamp((100 * resources.dirtiness) / 50 + 5 * tnum, 0, 80); //direct dirtiness + spreading factor max 80%
        foreach (pirate p in ps)
        {
            int r = Random.Range(0, 100);
            if (r < chance)//gets disease
            {
                popups.PopEvent(p.name + " got " + Typhoid.diseaseName + "!", Typhoid.diseaseDesc);
                Debug.Log(r + "number ->" + p.name + " got " + Typhoid.diseaseName + " chance: " + chance);
                p.diseases.Add(Typhoid);
            }
        }

        //Typhus
        chance = 80 * resources.dirtiness / 50; //direct dirtiness factor scaled to 80%
        foreach (pirate p in ps)
        {
            if (!p.diseases.Contains(Typhus))
            {
                int r = Random.Range(0, 100);
                if (r < chance)//gets disease
                {
                    popups.PopEvent(p.name + " got " + Typhus.diseaseName + "!", Typhus.diseaseDesc);
                    Debug.Log(r + "number ->" + p.name + " got " + Typhus.diseaseName + " chance: " + chance);
                    p.diseases.Add(Typhus);
                }
            }
        }

        //Scurvy
        foreach(pirate p in ps)
        {
            if (p.diseases.Contains(Scurvy)==false)
            {
                chance = 100 * (50 - p.vc) / 50; //invert vitC
                Debug.Log(p.vc);

                int r = Random.Range(0, 100);
                if (r < chance)//gets disease
                {
                    popups.PopEvent(p.name + " got " + Scurvy.diseaseName + "!", Scurvy.diseaseDesc);
                    Debug.Log(r + "number ->" + p.name + " got " + Scurvy.diseaseName + " chance: " + chance);
                    p.diseases.Add(Scurvy);
                }
            }
        }
    }
}