using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEntity : ISystem
{

    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        List<uint> ids = new List<uint>(Sizes.values.Keys);

        foreach (uint id in ids)
        {
            if (Sizes.values[id] <= 0)
            {
                ECSManager.Instance.DestroyShape(id);
                EntityManager.DestroyEntity(id);
            }
        }

    }

    public string Name { get; } = "DestroyEntity";
}
