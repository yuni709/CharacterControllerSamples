using Unity.Entities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAuthoring : MonoBehaviour
{
    public GameObject Prefab = null;
    public float SpawnRadius = 2;
    public int SpawnCount = 10;
    public uint RandomSeed = 100;
    public float IntervalTime = 1;
    public int bLoop = 0;
    
    class Baker : Baker<SpawnAuthoring>
    {
        public override void Bake(SpawnAuthoring authoring)
        {
            var data = new SpawnConfigComponent()
            {
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                SpawnRadius = authoring.SpawnRadius,
                SpawnCount = authoring.SpawnCount,
                RandomSeed = authoring.RandomSeed,
                IntervalTime = authoring.IntervalTime,
                bLoop = authoring.bLoop,
                ElapsedTime = 0
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}