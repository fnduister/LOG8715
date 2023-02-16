using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum EntityType
{
    Static,
    Protected,
    Dynamic,
    Clicked
}

public class EntityManager
{
    public static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();
    public static EntRestore restore = new EntRestore();
    public EntityManager()
    {
        EntPosition entPosition = new EntPosition();
        EntSpeed Speeds = new EntSpeed();
        EntSize Sizes = new EntSize();
        EntMaxSize MaxSizes = new EntMaxSize();
        EntType Types = new EntType();
        EntProtectionDuration ProtectionDurations = new EntProtectionDuration();
        EntProtectionCooldown ProtectionCooldowns = new EntProtectionCooldown();
        EntCollision Collisions = new EntCollision();

        EntUpdateLeft entUpdateLeft = new EntUpdateLeft();


        entPosition.values = new Dictionary<uint, Vector2>();
        entPosition.saved = new List<SavedPositions>();
        Speeds.values = new Dictionary<uint, Vector2>();
        Speeds.saved = new List<Savedspeeds>();
        Sizes.values = new Dictionary<uint, int>();
        Sizes.saved = new List<Savedsize>();
        MaxSizes.values = new Dictionary<uint, int>();
        Types.values = new Dictionary<uint, EntityType>();
        ProtectionDurations.values = new Dictionary<uint, float>();
        ProtectionCooldowns.values = new Dictionary<uint, float>();
        Collisions.values = new Dictionary<uint, bool>();
        entUpdateLeft.values = new Dictionary<uint, int>();

        components.Add("Position", entPosition);
        components.Add("Speed", Speeds);
        components.Add("Size", Sizes);
        components.Add("MaxSize", MaxSizes);
        components.Add("Type", Types);
        components.Add("ProtectionDuration", ProtectionDurations);
        components.Add("ProtectionCooldown", ProtectionCooldowns);
        components.Add("Collision", Collisions);

        components.Add("Restore", restore);

        components.Add("UpdateLeft", entUpdateLeft);


    }

    public static uint ids { get; set; } = 0;

    public static List<uint> DestroyedIds { get; set; } = new List<uint>();

    public static void DestroyEntity(uint id)
    {
        EntSpeed Speeds = (EntSpeed)components["Speed"];
        Speeds.values.Remove(id);
        
        EntPosition Positions = (EntPosition)components["Position"];
        Positions.values.Remove(id);
        
        EntSize Sizes = (EntSize)components["Size"];
        Sizes.values.Remove(id);
        
        EntType Types = (EntType)components["Type"];
        Types.values.Remove(id);

        EntMaxSize MaxSizes = (EntMaxSize)components["MaxSize"];
        Sizes.values.Remove(id);
        
        EntCollision Collisions = (EntCollision)components["Collision"];
        Collisions.values.Remove(id);
       
        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];
        ProtectionDurations.values.Remove(id);
        
        EntProtectionCooldown ProtectionCooldowns = (EntProtectionCooldown)EntityManager.components["ProtectionCooldown"];
        ProtectionCooldowns.values.Remove(id);

        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)EntityManager.components["UpdateLeft"];
        entUpdateLeft.values.Remove(id);

        DestroyedIds.Add(id);
    }

    public static void AddEntity(uint id, Vector2 Position, Vector2 Speed, int Size)
    {
        EntSpeed Speeds = (EntSpeed)components["Speed"];
        EntPosition Positions = (EntPosition)components["Position"];
        EntSize Sizes = (EntSize)components["Size"];
        EntType Types = (EntType)components["Type"];
        EntCollision Collisions = (EntCollision)components["Collision"];
        EntMaxSize MaxSizes = (EntMaxSize)components["MaxSize"];
        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)components["UpdateLeft"];

        Collisions.values.Add(id, false);
        Positions.values.Add(id, Position);
        Speeds.values.Add(id, Speed);
        entUpdateLeft.values.Add(id, 1);

        if (Speed.x == 0 && Speed.y == 0)
        {
            Types.values.Add(id, EntityType.Static);
        }
        else
        {
            Types.values.Add(id, EntityType.Dynamic);
        }

        Sizes.values.Add(id, Size);
        MaxSizes.values.Add(id, Size);
        ECSManager.Instance.CreateShape(id, Size);
    }

    public static List<uint> IdsToUpdate()
    {
        EntUpdateLeft entUpdateLeft = (EntUpdateLeft)EntityManager.components["UpdateLeft"];
        return (entUpdateLeft.values).Where(counter => counter.Value > 0).Select(entry => entry.Key).ToList();
    }
}
