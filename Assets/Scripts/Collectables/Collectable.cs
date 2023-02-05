using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    A,B,C,D,AB,AC,BC,DA,DB,DC
}
public abstract class Collectable:MonoBehaviour
{
    public Sprite icon;
    public CollectableType type;
}
