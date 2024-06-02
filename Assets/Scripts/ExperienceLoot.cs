using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLoot : Loot
{
    [SerializeField] private int _experienceValue;
    public override void Take(Collector collector)
    {
        base.Take(collector);
        collector.TakeExperience(_experienceValue);
    }
}
