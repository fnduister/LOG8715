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
    public Dictionary<uint, Vector2> values;
}

public struct EntVitesse : IComponent
{
    public Dictionary<uint, Vector2> values;
}

public struct EntSize : IComponent
{
    public Dictionary<uint, int> values;
}

public struct EntTimers : IComponent
{
    public Dictionary<uint, int> values;
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
