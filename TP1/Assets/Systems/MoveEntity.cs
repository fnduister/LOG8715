using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEntity : ISystem
{
    public void UpdateSystem()
    {
        EntVitesse Speeds = (EntVitesse)CreateEntity.components["Vitesse"];
        EntPosition Positions = (EntPosition)CreateEntity.components["Position"];
        EntSize Sizes = (EntSize)CreateEntity.components["Size"];

        foreach (KeyValuePair<uint, Vector2> entry in Speeds.values)
        {
            // check if touching left wall
            if (Positions.values[entry.Key].x - Sizes.values[entry.Key] < 0)
            {
                Speeds.values[entry.Key] = new Vector2(entry.Value.x, -entry.Value.y);
            }

            // check if touching top wall
            if (Positions.values[entry.Key].y - Sizes.values[entry.Key] < 0)
            {
                Speeds.values[entry.Key] = new Vector2(-entry.Value.x, entry.Value.y);
            }

            Vector2 newPosition = Positions.values[entry.Key] + Time.fixedDeltaTime * entry.Value;
            ECSManager.Instance.UpdateShapePosition(entry.Key, newPosition);
            Positions.values[entry.Key] = newPosition;
        }
    }

    private string name = "MoveEntity";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
