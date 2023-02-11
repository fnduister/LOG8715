using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : ISystem
{

    public void UpdateSystem()
    {
        EntPosition Positions = (EntPosition)EntityManager.components["Position"];
        EntVitesse Speeds = (EntVitesse)EntityManager.components["Vitesse"];
        EntSize Sizes = (EntSize)EntityManager.components["Size"];
        
        float current_time = Time.time;
        float delta_time = 3.0f;
        
        Positions.saved.Add(new SavedPositions(new Dictionary<uint, Vector2>( Positions.values), current_time));
        Speeds.saved.Add(new Savedspeeds(new Dictionary<uint, Vector2>(Speeds.values), current_time));
        Sizes.saved.Add(new Savedsize(new Dictionary<uint, int>(Sizes.values), current_time));

        Positions.saved.RemoveAll((SavedPositions spositions) => { return current_time - spositions.time > delta_time; });
        Speeds.saved.RemoveAll((Savedspeeds sspeeds) => { return current_time - sspeeds.time > delta_time; });
        Sizes.saved.RemoveAll((Savedsize ssizes) => { return current_time - ssizes.time > delta_time; });
    }

    private string name = "Save State";
    public string Name
    {
        get
        {
            return name;
        }
    }
}
