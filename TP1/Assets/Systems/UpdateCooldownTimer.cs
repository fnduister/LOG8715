using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCooldownTimer : ISystem
{
    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntType Types = (EntType)EntityManager.components["Type"];
        EntProtectionCooldown ProtectionCooldowns = (EntProtectionCooldown)EntityManager.components["ProtectionCooldown"];

        List<uint> ids = new List<uint>(ProtectionCooldowns.values.Keys);

        foreach (uint id in ids)
        {
            ProtectionCooldowns.values[id] -= Time.fixedDeltaTime;
        }
    }

    public string Name { get; } = "UpdateCooldownTimer";
}
