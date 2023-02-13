using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntCollision : IComponent
{
    public Dictionary<uint, bool> values;
    public List<SavedCollisions> saved;
}
public struct SavedCollisions
{

    public Dictionary<uint, bool> collision;
    public float time;

    public SavedCollisions(Dictionary<uint,bool> collision, float time)
    {
        this.collision = collision;
        this.time = time;
    }
}
