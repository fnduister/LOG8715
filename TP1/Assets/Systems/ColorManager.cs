using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : ISystem
{
    private string name = "ColorManager";


    public void UpdateSystem()
    {
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        EntType entTypes = (EntType)EntityManager.components["Type"];
        EntCollision Collisions = (EntCollision)EntityManager.components["Collision"];
        EntMaxSize MaxSizes = (EntMaxSize)EntityManager.components["MaxSize"];

        foreach (KeyValuePair<uint, EntityType> entry in entTypes.values)
        {
            switch (entry.Value)
            {
                case EntityType.Dynamic:
                    if (Sizes.values[entry.Key] == MaxSizes.values[entry.Key] - 1)
                    {
                        ECSManager.Instance.UpdateShapeColor(entry.Key, new Color(159, 0, 104));
                    }
                    else
                    {
                        if (Sizes.values[entry.Key] > MaxSizes.values[entry.Key])
                        {
                            MaxSizes.values[entry.Key] = Sizes.values[entry.Key];
                        }

                        if (Collisions.values[entry.Key])
                        {
                            ECSManager.Instance.UpdateShapeColor(entry.Key, Color.green);
                        }
                        else
                        {
                            ECSManager.Instance.UpdateShapeColor(entry.Key, Color.blue);
                        }
                    }
                    break;
                case EntityType.Static:
                    ECSManager.Instance.UpdateShapeColor(entry.Key, Color.red);
                    break;
                case EntityType.Protected:
                    ECSManager.Instance.UpdateShapeColor(entry.Key, Color.yellow);
                    break;
            }
        }
    }

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
