using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultipleFramesUpdate : MonoBehaviour {

    private void FixedUpdate()
    {   
        for(int i = 0; i<3;i++){
            foreach (var system in ECSManager.Instance.AllSystems.Where(system => ECSManager.Instance.Config.SystemsEnabled[system.Name])) {
            system.UpdateSystem();
            }
        }       
    }

}