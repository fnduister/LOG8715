using System;
using System.Collections.Generic;
using UnityEngine;

public class MultipleUpdate : ISystem
{
    public void UpdateSystem()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)EntityManager.components["UpdateLeft"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        List<uint> allIds = new List<uint>(entUpdateLeft.values.Keys);
        foreach(uint id in allIds)
        {
            Vector2 pos = Positions.values[id];
            if (pos.x < screenBounds.x/2)
            {
                entUpdateLeft.values[id]=4;
            } else
            {
                entUpdateLeft.values[id]=1;
            }
        }        

    }

    public string Name { get; } = "MultipleUpdate";
}
