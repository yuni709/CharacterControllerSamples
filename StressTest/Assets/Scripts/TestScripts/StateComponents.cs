using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct WalkState : IComponentData
{
    
}

public struct IdleState : IComponentData
{

}

public struct AttackState : IComponentData
{
    public float LastAttackElapsed;
    public float AttackInterval;
}