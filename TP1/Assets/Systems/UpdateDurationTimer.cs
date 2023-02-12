using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDurationTimer : ISystem
{
    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntType Types = (EntType)EntityManager.components["Type"];
        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];

        List<uint> ids = new List<uint>(ProtectionDurations.values.Keys);

        foreach (uint id in ids)
        {
            ProtectionDurations.values[id] -= Time.fixedDeltaTime;
        }
    }

    public string Name { get; } = "UpdateDurationTimer";
}
