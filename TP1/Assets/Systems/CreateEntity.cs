using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct EntPosition: IComponent
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

public class CreateEntity : ISystem
{
    public static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();
    public void UpdateSystem()
    {
        if (once)
        {
            once = false;

            EntPosition entPosition = new EntPosition();
            EntVitesse entVitesse = new EntVitesse();
            EntSize entSize = new EntSize();

            entPosition.values = new Dictionary<uint, Vector2>();
            entVitesse.values = new Dictionary<uint, Vector2>();
            entSize.values = new Dictionary<uint, int>();

            uint id = 0;
            components.Add("Position", entPosition);
            components.Add("Vitesse", entVitesse);
            components.Add("Size", entSize);


            foreach (var tempShape in ECSManager.Instance.Config.circleInstancesToSpawn)
            {
                entPosition.values.Add(id, tempShape.initialPosition);
                entVitesse.values.Add(id, tempShape.initialVelocity);
                entSize.values.Add(id, tempShape.initialSize);
                ECSManager.Instance.CreateShape(id, tempShape.initialSize);
                id++;
            }

        }
    }

    private bool once = true;

    private string name = "CreateEntity";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
