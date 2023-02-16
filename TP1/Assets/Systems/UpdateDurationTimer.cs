using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDurationTimer : ISystem
{
    public void UpdateSystem()
    {
        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];
        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)EntityManager.components["UpdateLeft"];


        List<uint> ids = new List<uint>(ProtectionDurations.values.Keys);

        foreach (uint id in ids)
        {
            int maxUpdate = entUpdateLeft.values[id];
            if (!ECSManager.Instance.Config.SystemsEnabled["MultipleUpdate"])
            {
                maxUpdate=1;
            }
            for (int kUpdate=0; kUpdate<maxUpdate; kUpdate++)
            {
                ProtectionDurations.values[id] -= Time.fixedDeltaTime;
            }
        }
    }

    public string Name { get; } = "UpdateDurationTimer";
}
