using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MoveEntity : ISystem
{
    public void UpdateSystem()
    {
        EntSpeed Speeds = (EntSpeed)EntityManager.components["Speed"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntType Types = (EntType)EntityManager.components["Type"];

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        List<uint> ids = new List<uint>(Speeds.values.Keys);

        for (int i = 0; i < Speeds.values.Count; i++)
        {
            uint firstKey = ids[i];

            if (Positions.values[firstKey].x + Sizes.values[firstKey] / 2.0 > screenBounds.x || Positions.values[firstKey].x - Sizes.values[firstKey] / 2.0 < screenOrigo.x)
            {
                Speeds.values[firstKey] = new Vector2(-Speeds.values[firstKey].x, Speeds.values[firstKey].y);
            }


            else if (Positions.values[firstKey].y + Sizes.values[firstKey] / 2.0 > screenBounds.y || Positions.values[firstKey].y - Sizes.values[firstKey] / 2.0 < screenOrigo.y)
            {
                Speeds.values[firstKey] = new Vector2(Speeds.values[firstKey].x, -Speeds.values[firstKey].y);
            }
            // check if touching left wall



            for (int j = i + 1; j < Speeds.values.Count; j++)
            {
                uint secondKey = ids[j];

                CollisionResult results = CollisionUtility.CalculateCollision(Positions.values[firstKey], Speeds.values[firstKey], Sizes.values[firstKey], Positions.values[secondKey],
                    Speeds.values[secondKey], Sizes.values[secondKey]);

                if (results != null)
                {
                    Speeds.values[firstKey] = results.velocity1;
                    Speeds.values[secondKey] = results.velocity2;

                    ECSManager.Instance.UpdateShapePosition(firstKey, results.position1);
                    ECSManager.Instance.UpdateShapePosition(secondKey, results.position2);

                    if (Types.values[firstKey] != EntityType.Static &&
                        Types.values[secondKey] != EntityType.Static)
                    {

                        if (Sizes.values[firstKey] < Sizes.values[secondKey])
                        {
                            if (Types.values[firstKey] != EntityType.Protected)
                            {
                                Sizes.values[firstKey] += 1;
                                ECSManager.Instance.UpdateShapeSize(firstKey, Sizes.values[firstKey]);
                            }

                            if (Types.values[secondKey] != EntityType.Protected)
                            {
                                Sizes.values[secondKey] -= 1;
                                ECSManager.Instance.UpdateShapeSize(secondKey, Sizes.values[secondKey]);
                            }
                        }
                        else if (Sizes.values[firstKey] > Sizes.values[secondKey])
                        {
                            if (Types.values[firstKey] != EntityType.Protected)
                            {
                                Sizes.values[firstKey] -= 1;
                                ECSManager.Instance.UpdateShapeSize(firstKey, Sizes.values[firstKey]);
                            }

                            if (Types.values[secondKey] != EntityType.Protected && Types.values[firstKey] != EntityType.Protected)
                            {
                                Sizes.values[secondKey] += 1;
                                ECSManager.Instance.UpdateShapeSize(secondKey, Sizes.values[secondKey]);
                            }
                        }
                    }
                }

            }

            Vector2 newPosition = Positions.values[firstKey] + Time.fixedDeltaTime * Speeds.values[firstKey];
            ECSManager.Instance.UpdateShapePosition(firstKey, newPosition);
            Positions.values[firstKey] = newPosition;
        }

    }

    public string Name { get; } = "MoveEntity";

}
