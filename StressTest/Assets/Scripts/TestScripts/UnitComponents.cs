using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct UnitComponent : IComponentData
{
    public float Health;
}

public struct MovementComponent : IComponentData
{
    public float Speed;
}

public struct WalkerComponent : IComponentData
{
    public float3 Destination;
    
}

public struct InputComponent : IComponentData
{
    public float3 Destination;
}