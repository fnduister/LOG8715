using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClick : ISystem
{
    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntType Types = (EntType)EntityManager.components["Type"];
        EntSpeed Speeds = (EntSpeed)EntityManager.components["Speed"];

        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];

        if (ECSManager.Instance.getInputStatus())
        { // if left button pressed...
            ECSManager.Instance.UpdateInputStatus();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            foreach (KeyValuePair<uint, Vector2> entry in Positions.values)
            {
                if (Types.values[entry.Key] == EntityType.Dynamic)
                {

                    if (Vector2.Distance(entry.Value, ray.origin) < Sizes.values[entry.Key])
                    {
                        Types.values[entry.Key] = EntityType.Clicked;

                        if (Sizes.values[entry.Key] > 2)
                        {
                            Vector2 Translation = Speeds.values[entry.Key].normalized * Sizes.values[entry.Key] / 2;
                            uint firstBall = EntityManager.ids++;
                            uint secondBall = EntityManager.ids++;

                            EntityManager.AddEntity(firstBall, Positions.values[entry.Key] + Translation, Speeds.values[entry.Key], Sizes.values[entry.Key] / 2);
                            EntityManager.AddEntity(secondBall, Positions.values[entry.Key] - Translation, -Speeds.values[entry.Key], Sizes.values[entry.Key] / 2);

                            Types.values[firstBall] = EntityType.Clicked;
                            Types.values[secondBall] = EntityType.Clicked;

                            ECSManager.Instance.DestroyShape(entry.Key);
                            EntityManager.DestroyEntity(entry.Key);
                        }
                        break;
                    }
                }
            }
        }
    }

    public string Name { get; } = "HandleClick";
}
