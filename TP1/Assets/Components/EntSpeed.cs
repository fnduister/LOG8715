using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EntSpeed : IComponent
{
    public Dictionary<uint, Vector2> values;
    public List<Savedspeeds> saved;
}
public struct Savedspeeds
{

    public Dictionary<uint, Vector2> speed;
    public float time;

    public Savedspeeds(Dictionary<uint, Vector2> speed, float time)
    {
        this.speed = speed;
        this.time = time;
    }
}


