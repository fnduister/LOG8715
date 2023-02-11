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
            EntRestore entRestore = new EntRestore();

            entPosition.values = new Dictionary<uint, Vector2>();
            entPosition.saved = new List<SavedPositions>();
            entVitesse.values = new Dictionary<uint, Vector2>();
            entVitesse.saved = new List<Savedspeeds>();
            entSize.values = new Dictionary<uint, int>();
            entSize.saved = new List<Savedsize>();
            entType.values = new Dictionary<uint, EntityType>();
            entRestore.activated = false;
            entRestore.timer = 0;

            uint id = 0;
            EntityManager.components.Add("Position", entPosition);
            EntityManager.components.Add("Vitesse", entVitesse);
            EntityManager.components.Add("Size", entSize);
            EntityManager.components.Add("Type", entType);
            EntityManager.components.Add("Restore", entRestore);


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
