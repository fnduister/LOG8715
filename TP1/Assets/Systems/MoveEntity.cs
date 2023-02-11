using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MoveEntity : ISystem
{
    public void UpdateSystem()
    {
        EntVitesse Speeds = (EntVitesse)EntityManager.components["Vitesse"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntSize Sizes = (EntSize)EntityManager.components["Size"];

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);



        for (uint i = 0; i < Speeds.values.Count; i++)
        {
            if (Positions.values[i].x + Sizes.values[i] / 2.0 > screenBounds.x || Positions.values[i].x - Sizes.values[i] / 2.0 < screenOrigo.x)
            {
                Speeds.values[i] = new Vector2(-Speeds.values[i].x, Speeds.values[i].y);
            }


            else if (Positions.values[i].y + Sizes.values[i] / 2.0 > screenBounds.y || Positions.values[i].y - Sizes.values[i] / 2.0 < screenOrigo.y)
            {
                Speeds.values[i] = new Vector2(Speeds.values[i].x, -Speeds.values[i].y);
            }
            // check if touching left wall

            Vector2 newPosition = Positions.values[i] + Time.fixedDeltaTime * Speeds.values[i];
            ECSManager.Instance.UpdateShapePosition(i, newPosition);
            Positions.values[i] = newPosition;



            for (uint j = i+1; j < Speeds.values.Count; j++)
            {
                if(j!= i)
                {
                    CollisionResult results = CollisionUtility.CalculateCollision(Positions.values[i], Speeds.values[i], Sizes.values[i], Positions.values[j],
                        Speeds.values[j], Sizes.values[j]);

                    if (results != null)
                    {
                        //Debug.Log(i);
                        Speeds.values[i] = results.velocity1;
                        Speeds.values[j] = results.velocity2;
                        ECSManager.Instance.UpdateShapePosition(i, results.position1);

                        ECSManager.Instance.UpdateShapePosition(j, results.position2);
                    }
                }
            }

        }

    }

    private string name = "MoveEntity";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
