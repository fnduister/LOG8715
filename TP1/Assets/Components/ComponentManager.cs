using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager
{
    public static ComponentManager Instance { get; private set; }
    public Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

}

