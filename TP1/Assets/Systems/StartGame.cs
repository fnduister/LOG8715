using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : ISystem
{
    private bool once = true;

    public void UpdateSystem()
    {
        if (once)
        {
            once = false;

            EntPosition entPosition = new EntPosition();
            EntVitesse entVitesse = new EntVitesse();
            EntSize entSize = new EntSize();
            EntType entType = new EntType();

            entPosition.values = new Dictionary<uint, Vector2>();
            entVitesse.values = new Dictionary<uint, Vector2>();
            entSize.values = new Dictionary<uint, int>();
            entType.values = new Dictionary<uint, EntityType>();

            uint id = 0;
            EntityManager.components.Add("Position", entPosition);
            EntityManager.components.Add("Vitesse", entVitesse);
            EntityManager.components.Add("Size", entSize);
            EntityManager.components.Add("Type", entType);


            foreach (var tempShape in ECSManager.Instance.Config.circleInstancesToSpawn)
            {
                entPosition.values.Add(id, tempShape.initialPosition);
                entVitesse.values.Add(id, tempShape.initialVelocity);
                if(tempShape.initialVelocity.x == 0 && tempShape.initialVelocity.y == 0)
                {
                    entType.values.Add(id, EntityType.Static);
                }else
                {
                    entType.values.Add(id, EntityType.Dynamic);
                }
                entSize.values.Add(id, tempShape.initialSize);
                ECSManager.Instance.CreateShape(id, tempShape.initialSize);
                id++;
            }
        }
    }

    private string name = "StartGame";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
