using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeed : Seed
{
    public enum SeedType : int
    {
        A=1,
        B=2,
        C=3,
        D=5
    }
    public SeedType seedType;
}
