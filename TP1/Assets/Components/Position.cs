using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : IComponent
{
    public Dictionary<uint, Vector2> data;
    public List<SavedPositions> saved;
}
public struct SavedPositions
{
    
    public Dictionary<uint, Vector2> position;
    public float time;

    public SavedPositions(Dictionary<uint, Vector2> position, float time)
    {
        this.position = position;
        this.time = time;
    }
}
