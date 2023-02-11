using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreState : ISystem
{
    
    public void UpdateSystem()
    {
        EntRestore entRestore = (EntRestore)EntityManager.components["Restore"];
        EntVitesse Speeds = (EntVitesse)EntityManager.components["Vitesse"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            

            if (!entRestore.activated && Speeds.saved.Count > 0)
            {
                entRestore.activated = true;
                entRestore.timer = Time.time;
                for (uint i = 0; i < Speeds.values.Count; i++)
                {
                
                    Speeds.values[i] = Speeds.saved[0].speed[i];
                
                    Sizes.values[i] = Sizes.saved[0].size[i];
                    Positions.values[i] = Positions.saved[0].position[i];
                    ECSManager.Instance.UpdateShapePosition(i, Positions.saved[0].position[i]);
                    ECSManager.Instance.UpdateShapeSize(i, Sizes.values[i]);
                
                }

                Speeds.values = new Dictionary<uint, Vector2>(Speeds.saved[0].speed);
                Positions.values = new Dictionary<uint, Vector2>(Positions.saved[0].position);
                Sizes.values = new Dictionary<uint, int>(Sizes.saved[0].size);

                //Debug.Log(i);
            }
            }
            else
            {
                Debug.Log("Restore Mode is not avaialable now");
            }
            if (Time.time - entRestore.timer > 3.0f)
            {
                entRestore.activated = false;
            }
    
    }
    private string name = "RestoreState";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
