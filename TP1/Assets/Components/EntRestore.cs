using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntRestore : IComponent
{
    public bool activated;
    public float timer;

    public EntRestore()
    {
        this.activated = false;
        this.timer = 0;
    }
}
