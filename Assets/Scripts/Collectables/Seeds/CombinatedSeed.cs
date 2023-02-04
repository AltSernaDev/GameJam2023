using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatedSeed : Seed
{
    public enum SeedType: int
    {
        AB = 1,
        BC,
        AC,
        DA,
        DB,
        DC
    }
    public SeedType seedType;

    public void SpecialEffect()
    {

    }
}
