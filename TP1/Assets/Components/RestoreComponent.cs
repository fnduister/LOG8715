using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreComponent : IComponent
{
    public bool activated;
    public float timer;

    public RestoreComponent()
    {
        this.activated = false;
        this.timer = 0;
    }
}
