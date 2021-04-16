using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Food = 0,
    Water = 1,
    MH = 2,
    PH = 3,
    VC = 4,
    cleanliness = 5,
    temperature = 6,
    weather = 7,
    wind = 8,
    FP = 9
}

[System.Serializable]
public class Requirement
{
    public Stat requirementType;
    public int requirement;
    public bool bigger;

    public Requirement(Stat requirementType, int requirement, bool bigger)
    {
        this.requirement = requirement;
        this.requirementType = requirementType;
        this.bigger = bigger;
    }

    public Requirement()
    {

    }
}

[System.Serializable]
public class Effect
{
    public Stat effectType;
    public int effect;

    public Effect(Stat effectType, int effect)
    {
        this.effectType = effectType;
        this.effect = effect;
    }

    public Effect()
    {

    }
}

[System.Serializable]
public class Event
{
    public string Name;
    public string Description;

    public List<Requirement> requirements;
    public List<Effect> effects;

    public int chance;

    public Event(string Name, string Description, List<Requirement> requirements, int chance)
    {
        this.Name = Name;
        this.Description = Description;
        this.requirements = requirements;
        this.chance = chance;
    }

    public Event()
    {

    }
}