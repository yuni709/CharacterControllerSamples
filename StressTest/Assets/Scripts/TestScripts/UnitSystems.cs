using Unity.Burst;
using Unity.Jobs;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using JetBrains.Annotations;



public partial struct UnitSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var deltaTime = SystemAPI.Time.DeltaTime;

        

        /*
        var job = new SpinUnitJob()
        {
            DeltaTime = SystemAPI.Time.DeltaTime
        };
        job.ScheduleParallel();
    }

    [BurstCompile]
    public partial struct  SpinUnitJob : IJobEntity
    {

        public float DeltaTime;
        
        public void Execute(Entity entity, in UnitComponent unitComponent, ref LocalTransform xform)
        {
            var rotation = quaternion.RotateY(10 * DeltaTime);
            xform.Rotation = rotation;
        }

    */
    }
}
