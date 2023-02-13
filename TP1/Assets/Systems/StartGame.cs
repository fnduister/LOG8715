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
            new EntityManager();
            Random.InitState(ECSManager.Instance.Config.seed);

            foreach (var tempShape in ECSManager.Instance.Config.circleInstancesToSpawn)
            {
                EntityManager.AddEntity(EntityManager.ids++, tempShape.initialPosition, tempShape.initialVelocity, tempShape.initialSize);   
            }
        }
    }

    private string name = "StartGame";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
