using Unity.Entities;
using UnityEngine;

public struct SpawnConfigComponent : IComponentData
{
    public Entity Prefab;
    public float SpawnRadius;
    public int SpawnCount;
    public uint RandomSeed;
    public float IntervalTime;
    public float ElapsedTime;
    public int bLoop;
}
