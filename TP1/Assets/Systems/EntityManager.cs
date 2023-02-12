using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Static,
    Protected,
    Dynamic
}

public class EntityManager
{
    public static Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

    public EntityManager()
    {
        EntPosition entPosition = new EntPosition();
        EntSpeed Speeds = new EntSpeed();
        EntSize Sizes = new EntSize();
        EntType Types = new EntType();
        EntProtectionDuration ProtectionDurations = new EntProtectionDuration();
        EntProtectionCooldown ProtectionCooldowns = new EntProtectionCooldown();

        entPosition.values = new Dictionary<uint, Vector2>();
        Speeds.values = new Dictionary<uint, Vector2>();
        Sizes.values = new Dictionary<uint, int>();
        Types.values = new Dictionary<uint, EntityType>();
        ProtectionDurations.values = new Dictionary<uint, float>();
        ProtectionCooldowns.values = new Dictionary<uint, float>();

        components.Add("Position", entPosition);
        components.Add("Speed", Speeds);
        components.Add("Size", Sizes);
        components.Add("Type", Types);
        components.Add("ProtectionDuration", ProtectionDurations);
        components.Add("ProtectionCooldown", ProtectionCooldowns);
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
        EntProtectionDuration ProtectionDurations = (EntProtectionDuration)EntityManager.components["ProtectionDuration"];
        ProtectionDurations.values.Remove(id);
        EntProtectionCooldown ProtectionCooldowns = (EntProtectionCooldown)EntityManager.components["ProtectionCooldown"];
        ProtectionCooldowns.values.Remove(id);

        DestroyedIds.Add(id);
    }

    public static void AddEntity(uint id, Vector2 Position, Vector2 Speed, int Size)
    {
        EntSpeed Speeds = (EntSpeed)components["Speed"];
        EntPosition Positions = (EntPosition)components["Position"];
        EntSize Sizes = (EntSize)components["Size"];
        EntType Types = (EntType)components["Type"];
        Positions.values.Add(id, Position);
        Speeds.values.Add(id, Speed);
        if (Speed.x == 0 && Speed.y == 0)
        {
            Types.values.Add(id, EntityType.Static);
        }
        else
        {
            Types.values.Add(id, EntityType.Dynamic);
        }
        Sizes.values.Add(id, Size);
        ECSManager.Instance.CreateShape(id, Size);
    }
}
