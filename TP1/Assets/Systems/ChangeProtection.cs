using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProtection : ISystem
{
    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntType Types = (EntType)EntityManager.components["Type"];
        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];
        EntProtectionCooldown ProtectionCooldowns = (EntProtectionCooldown)EntityManager.components["ProtectionCooldown"];
        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)EntityManager.components["UpdateLeft"];

        List<uint> ids = new List<uint>(Sizes.values.Keys);

        foreach (uint id in ids)
        {
            int maxUpdate = entUpdateLeft.values[id];
            if (!ECSManager.Instance.Config.SystemsEnabled["MultipleUpdate"])
            {
                maxUpdate=1;
            }
            for (int kUpdate=0; kUpdate<maxUpdate; kUpdate++)            
            {
                float rd = Random.Range(0f, 100f);

                if (ProtectionDurations.values.ContainsKey(id))
                {
                    if (ProtectionDurations.values[id] <= 0)
                    {
                        ProtectionDurations.values.Remove(id);
                        ProtectionCooldowns.values.Add(id, ECSManager.Instance.Config.protectionCooldown);
                        Types.values[id] = EntityType.Dynamic;
                    }
                }
                else
                {
                    bool canUpdate = true;

                    // We want to make sure that we stop the protection when the cooldown time is not over and remove the id once it's done
                    if (ProtectionCooldowns.values.ContainsKey(id))
                    {
                        if (ProtectionCooldowns.values[id] <= 0)
                        {
                            ProtectionCooldowns.values.Remove(id);
                        }
                        else
                        {
                            canUpdate = false;
                        }
                    }

                    if (Sizes.values[id] <= ECSManager.Instance.Config.explosionSize
                        && Types.values[id] == EntityType.Dynamic
                        && canUpdate)
                    {
                        if (rd < ECSManager.Instance.Config.protectionProbability * 100f)
                        {
                            Types.values[id] = EntityType.Protected;
                            ProtectionDurations.values.Add(id, ECSManager.Instance.Config.protectionDuration);
                        }
                    }
                }
            }
        }
    }

    public string Name { get; } = "ChangeProtection";
}
