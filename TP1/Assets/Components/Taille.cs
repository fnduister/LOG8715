using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taille : IComponent
{
    public Dictionary<uint, int> data;
    public List<Savedsize> saved;
}
public struct Savedsize
{

    public Dictionary<uint, int> size;
    public float time;

    public Savedsize(Dictionary<uint, int> size, float time)
    {
        this.size = size;
        this.time = time;
    }
}

