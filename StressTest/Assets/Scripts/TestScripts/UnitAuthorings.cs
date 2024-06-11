using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics.Authoring;
using UnityEngine;
using Unity.Physics;
using UnityEngine.Serialization;

// Prefab can reconize only MonoBehaviour inherited classes
public class UnitAuthoring : MonoBehaviour
{
    public class Baker : Baker<UnitAuthoring>
    {
        public override void Bake(UnitAuthoring unitAuth)
        {
            var data = new UnitComponent()
            {
                Health = 100
            };
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, data);
        }
    }
}