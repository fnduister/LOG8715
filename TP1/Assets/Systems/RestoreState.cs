using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreState : ISystem
{

    public void UpdateSystem()
    {
        EntRestore entRestore = EntityManager.restore;
        EntSpeed Speeds = (EntSpeed)EntityManager.components["Speed"];
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntSize Sizes = (EntSize)EntityManager.components["Size"];

        if (Input.GetKeyDown(KeyCode.Space))
        {


            if (!entRestore.activated && Speeds.saved.Count > 0)
            {
                entRestore.activated = true;
                entRestore.timer = Time.time;
                // DestroyEntity all shapes
                List<uint> current_ids = new List<uint>(Sizes.values.Keys);
                
                foreach(uint id in current_ids)
                {
                    ECSManager.Instance.DestroyShape(id);
                    EntityManager.DestroyEntity(id);
                }
                
                List<uint> old_ids = new List<uint>(Sizes.saved[0].size.Keys);
                foreach (uint i in old_ids)
                {

                    Debug.Log(i);
                    Debug.Log(EntityManager.ids);
                    EntityManager.AddEntity(EntityManager.ids++, Positions.saved[0].position[i], Speeds.saved[0].speed[i], Sizes.saved[0].size[i]);
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

    }
    private string name = "RestoreState";

    public string Name   // property
    {
        get { return name; }   // get method
    }
}
