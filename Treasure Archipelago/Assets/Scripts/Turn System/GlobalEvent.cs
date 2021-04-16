using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceGlobal
{
    Food = 0,
    Water = 1,
    MH = 2,
    PH = 3,
    Fruit = 4,
    cleanliness = 5,
    temperature = 6,
    Booze = 7,
    wind = 8,
    FP = 9,
    Coin = 10
}

[System.Serializable]
public class RequirementGlobal
{
    public ResourceGlobal requirementType;
    public int requirement;
    public bool bigger;
}

[System.Serializable]
public class EffectGlobal
{
    public ResourceGlobal effectType;
    public int effect;
}

[System.Serializable]
public class GlobalEvent
{
    public string Name;
    public string Description;

    public List<RequirementGlobal> requirements;
    public List<EffectGlobal> effects;

    public int chance;
}