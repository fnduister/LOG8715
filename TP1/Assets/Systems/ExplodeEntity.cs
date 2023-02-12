using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEntity : ISystem
{

    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntSpeed Speeds = (EntSpeed)EntityManager.components["Speed"];
        EntType Types = (EntType)EntityManager.components["Type"];

        List<uint> ids = new List<uint>(Sizes.values.Keys);

        foreach (uint id in ids)
        {
            if (Sizes.values[id] == ECSManager.Instance.Config.explosionSize)
            {
                Vector2 Translation = Speeds.values[id].normalized * Sizes.values[id] / 2;

                EntityManager.AddEntity(EntityManager.ids++, Positions.values[id] + Translation, Speeds.values[id], Sizes.values[id] / 2);
                EntityManager.AddEntity(EntityManager.ids++, Positions.values[id] - Translation, -Speeds.values[id], Sizes.values[id] / 2);

                ECSManager.Instance.DestroyShape(id);
                EntityManager.DestroyEntity(id);
            }
        }

    }

    public string Name { get; } = "ExplodeEntity";
}
