
using System.Numerics;
using JetBrains.Annotations;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Toolshed.Commands.Values;

namespace Content.Server.Map.Systems
{
    public sealed partial class MapGenSystem
    {
        [Dependency] IEntityManager entityManager = default!;
        [Dependency] IPrototypeManager protoManager = default!;
        public EntityUid GenerateFloor(EntityPrototype floorProto)
        {
            var floor = entityManager.SpawnEntity(floorProto.ID, MapCoordinates.Nullspace);
            return floor;
        }

    }
}