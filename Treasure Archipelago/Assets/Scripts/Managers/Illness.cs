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
    public bool unlocked;

    public Disease(string diseaseName, List<Effect> effects, string diseaseDesc, int duration)
    {
        daysActive = 0;
        this.diseaseDesc = diseaseDesc;
        this.diseaseName = diseaseName;
        this.effects = effects;
        this.duration = duration;
        unlocked = false;
    }
};

public class Illness
{
    static List<Effect> effectstemp;
    public static Disease Desyntery, Malaria, Typhoid, Typhus, Scurvy;

    public static void Initialize()
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
        desc = "Malaria is a mosquito-borne infectious disease. Causes symptoms that typically include fever, tiredness, vomiting, and headaches.";
        Malaria = new Disease("Malaria", effectstemp, desc, 30);

        //Typhoid
        effects = new List<Effect>();
        e = new Effect(Stat.MH, -3);
        effects.Add(e);

        effectstemp = effects;
        desc = "Often there is a gradual onset of a high fever, weakness, abdominal pain, constipation, headaches, and mild vomiting also commonly occur. It spreads, but not all suffer it's effects";
        Typhoid = new Disease("Typhoid", effectstemp, desc, 30);

        //Typhus
        effects = new List<Effect>();
        e = new Effect(Stat.PH, -1);
        effects.Add(e);

        effectstemp = effects;
        desc = "Common symptoms include fever, headache, and a rash. Usually spread by bugs";
        Typhus = new Disease("Typhus", effectstemp, desc, 30);

        //Scurvy
        effects = new List<Effect>();
        e = new Effect(Stat.PH, -2);
        effects.Add(e);

        effectstemp = effects;
        desc = "Caused by the lack of Vitamin C. Early symptoms include weakness, feeling tired, and sore arms and legs. Without treatment, decreased red blood cells, gum disease, changes to hair, and bleeding from the skin may occur.";
        Scurvy = new Disease("Scurvy", effectstemp, desc, 14);
    }

    public static void TurnDisease(List<pirate> ps) //USE THIS BILBO
    {
        //Debug.Log("Disease logic...");
        DiseaseChance(ps);

        //Debug.Log("Effecting diseases...");
        //Apply disease effects
        foreach (pirate p in ps)
        {
            List<Disease> bcsunityD = new List<Disease>();
            foreach (Disease d in p.diseases)//MAKE A BCS UNITY done
            {
                d.daysActive++;
                applyDiseaseEffects(d, p, bcsunityD);
            }

            foreach (Disease d in bcsunityD)//removing diseases, kill live?
            {
                d.daysActive = 0;
                p.diseases.Remove(d);
                Debug.Log(p.name + " cured of " + d.diseaseName);
            }
        }
    }

    public static void applyDiseaseEffects(Disease d, pirate p, List<Disease> bcsunity)
    {
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

    public static void DiseaseChance(List<pirate> ps)
    {
        PopupSpawner popups = GameObject.FindGameObjectWithTag("popup manager").GetComponent<PopupSpawner>();
        //Debug.Log("Chancing diseases...");

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
        float chance = Mathf.Clamp((100 * resources.dirtiness) / 50 + 5 * dnum, 0, 20); //between 0-80, colleages can spread
        foreach (pirate p in ps)
        {
            bool repeat = false;
            foreach (Disease d in p.diseases)
            {
                if (d.diseaseName == Desyntery.diseaseName)
                {
                    repeat = true;
                }
            }
            if (!repeat)
            {
                int r = RollNumber(0, 100);
                if (r < chance)//gets disease
                {
                    //Debug.Log(r + "number ->" + p.name + " got " + Desyntery.diseaseName + " chance: " + chance);

                    popups.PopEvent(p.name + " got " + Desyntery.diseaseName + "!", Desyntery.diseaseDesc);

                    p.diseases.Add(Desyntery);
                    Desyntery.unlocked = true;
                }
            }
            else
            {
                Debug.Log("prevented repeated disease");
            }
        }

        //Malaria
        chance = 0;
        if (MapManager.places[MapManager.places.Count - 1].p == Place.Island)
        {
            chance = 2;
            chance += ((5 * resources.dirtiness) / 50 * 100) / 50; //adds 5% of dirtiness
        }

        foreach (pirate p in ps)
        {
            bool repeat = false;
            foreach (Disease d in p.diseases)
            {
                if (d.diseaseName == Malaria.diseaseName)
                {
                    repeat = true;
                }
            }
            if (!repeat)
            {
                int r = RollNumber(0, 100);
                if (r < chance)//gets disease
                {
                    //Debug.Log(r + "number ->" + p.name + " got " + Malaria.diseaseName + " chance: " + chance);
                    popups.PopEvent(p.name + " got " + Malaria.diseaseName + "!", Malaria.diseaseDesc);
                    p.diseases.Add(Malaria);
                    Malaria.unlocked = true;
                }
            }
            else
            {
                Debug.Log("prevented repeated disease");
            }
        }

        //Typhoid
        chance = Mathf.Clamp((3 * resources.dirtiness) / 50, 0, 3) + 1 * tnum; //direct dirtiness + spreading factor max 10%
        foreach (pirate p in ps)
        {
            bool repeat = false;
            foreach (Disease d in p.diseases)
            {
                if (d.diseaseName == Typhoid.diseaseName)
                {
                    repeat = true;
                }
            }
            if (!repeat)
            {
                int r = RollNumber(0, 100);
                if (r < chance)//gets disease
                {
                    popups.PopEvent(p.name + " got " + Typhoid.diseaseName + "!", Typhoid.diseaseDesc);
                    //Debug.Log(r + "number ->" + p.name + " got " + Typhoid.diseaseName + " chance: " + chance);
                    p.diseases.Add(Typhoid);
                    Typhoid.unlocked = true;
                }
            }
            else
            {
                Debug.Log("prevented repeated disease");
            }
        }

        //Typhus
        chance = Mathf.Clamp(3 * resources.dirtiness / 50, 0, 3); //direct dirtiness factor scaled to 3%
        foreach (pirate p in ps)
        {
            bool repeat = false;
            foreach (Disease d in p.diseases)
            {
                if (d.diseaseName == Typhus.diseaseName)
                {
                    repeat = true;
                }
            }
            if (!repeat)
            {
                int r = RollNumber(0, 100);
                if (r < chance)//gets disease
                {
                    popups.PopEvent(p.name + " got " + Typhus.diseaseName + "!", Typhus.diseaseDesc);
                    //Debug.Log(r + "number ->" + p.name + " got " + Typhus.diseaseName + " chance: " + chance);
                    p.diseases.Add(Typhus);
                    Typhus.unlocked = true;
                }
            }
            else
            {
                Debug.Log("prevented repeated disease");
            }
        }

        //Scurvy
        foreach (pirate p in ps)
        {
            bool repeat = false;
            foreach (Disease d in p.diseases)
            {
                if (d.diseaseName == Scurvy.diseaseName)
                {
                    repeat = true;
                }
            }
            if (!repeat)
            {
                chance = Mathf.Clamp(10 * (50 - p.vc) / 50, 0, 10); //invert vitC max 10%

                int r = RollNumber(0, 100);
                if (r < chance)//gets disease
                {
                    popups.PopEvent(p.name + " got " + Scurvy.diseaseName + "!", Scurvy.diseaseDesc);
                    //Debug.Log(r + "number ->" + p.name + " got " + Scurvy.diseaseName + " chance: " + chance);
                    p.diseases.Add(Scurvy);
                    Scurvy.unlocked = true;
                }
            }
            else
            {
                Debug.Log("prevented repeated disease");
            }
        }
    }

    public static int RollNumber(int min, int max)
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        return Random.Range(min, max);
    }
}