using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Static,
    Protected,
    Dynamic
}

public struct EntType : IComponent
{
    public Dictionary<uint, EntityType> values;
}

public struct EntPosition : IComponent
{
    public List<SavedPositions> saved;
    public Dictionary<uint, Vector2> values;
}

public struct EntVitesse : IComponent
{
    public Dictionary<uint, Vector2> values;
    public List<Savedspeeds> saved;
}

public struct EntSize : IComponent
{
    public Dictionary<uint, int> values;
    public List<Savedsize> saved;
}

public struct EntTimers : IComponent
{
    public Dictionary<uint, int> values;
}
public struct EntRestore : IComponent
{
    public bool activated;
    public float timer;

    
}

public class EntityManager
{
    public static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

    private string name = "CreateEntity";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
