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

            EntPosition Positions = (EntPosition)EntityManager.components["Position"];
            EntSpeed Speeds = (EntSpeed)EntityManager.components["Speed"];
            EntType Types = (EntType)EntityManager.components["Type"];
            EntSize Sizes = (EntSize)EntityManager.components["Size"];
            EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];
            EntProtectionCooldown ProtectionCooldowns = (EntProtectionCooldown)EntityManager.components["ProtectionCooldown"];

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
