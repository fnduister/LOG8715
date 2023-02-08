using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : ISystem
{
    private string name = "ColorManager";


    public void UpdateSystem()
    {
        EntType entTypes = (EntType)EntityManager.components["Type"];
        foreach (KeyValuePair<uint, EntityType> entry in entTypes.values)
        {
            switch (entry.Value)
            {
                case EntityType.Dynamic:
                    ECSManager.Instance.UpdateShapeColor(entry.Key, Color.blue);
                    break;
                case EntityType.Static:
                    ECSManager.Instance.UpdateShapeColor(entry.Key, Color.red);
                    break;
            }
        }
    }

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
