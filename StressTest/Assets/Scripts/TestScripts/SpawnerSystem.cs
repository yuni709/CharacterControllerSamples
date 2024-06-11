using TMPro;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


// [UpdateInGroup(typeof(InitializationSystemGroup))]
[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    => state.RequireForUpdate<SpawnConfigComponent>();

    // [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var spawnConfig = SystemAPI.GetSingletonRW<SpawnConfigComponent>();

        var deltaTime = SystemAPI.Time.DeltaTime;

        if (spawnConfig.ValueRW.ElapsedTime > spawnConfig.ValueRW.IntervalTime)
        {
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);
            int counter = 0;
            for (int i = 0; counter < spawnConfig.ValueRW.SpawnCount; i++)
            {
                // Spawn entity.
                Entity spawnedCharacter = ecb.Instantiate(spawnConfig.ValueRW.Prefab);
                ecb.SetComponent(spawnedCharacter, new UnitComponent
                { 
                    Health = 200 
                });

                float3 spawnPos = new float3
                (
                    UnityEngine.Random.Range(-spawnConfig.ValueRW.SpawnRadius, spawnConfig.ValueRW.SpawnRadius),
                    0, 
                    UnityEngine.Random.Range(-spawnConfig.ValueRW.SpawnRadius, spawnConfig.ValueRW.SpawnRadius)
                );
                counter++;

                ecb.SetComponent(spawnedCharacter, new LocalTransform { Position = spawnPos });
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
            state.Enabled = false; // spawnConfig.ValueRW.bLoop == 1 ? true : false;
            // spawnConfig.ValueRW.ElapsedTime = 0;
        }
        else
        {
            spawnConfig.ValueRW.ElapsedTime += deltaTime;
        }



    }
}
