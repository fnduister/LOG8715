using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitesse : IComponent
{
    public Dictionary<uint, Vector2> data;
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


