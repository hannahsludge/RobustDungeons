
using System.Numerics;
using JetBrains.Annotations;
using Robust.Server.GameObjects;
using Robust.Shared.ContentPack;
using Robust.Shared.Map;
using Robust.Shared.Map.Components;
using Robust.Shared.Prototypes;
using Robust.Shared.Toolshed.Commands.Values;

namespace Content.Server.Map.Systems
{
    public sealed partial class MapGenSystem : EntitySystem
    {
        private bool firstFloorGenned = false; 
        [Dependency] IEntityManager entityManager = default!;
        [Dependency] IPrototypeManager protoManager = default!;
        [Dependency] ITileDefinitionManager tileDefinitionManager = default!;
        
        private SharedMapSystem mapSystem => entityManager.System<SharedMapSystem>();
        public EntityUid GenerateFloor(EntityPrototype floorProto)
        {
            var floor = entityManager.SpawnEntity(floorProto.ID, MapCoordinates.Nullspace);
            
            mapSystem.SetTile(entityManager.GetEntityQuery<MapGridComponent>().Get(floor), new EntityCoordinates(floor, Vector2.Zero), new Tile(tileDefinitionManager["TestFloor"].TileId));
            return floor;
        }
        static readonly EntProtoId firstFloor = "TestDungeonFloor";
        public override void Update(float frameTime)
        {
            if (!firstFloorGenned)
            {
                GenerateFloor(protoManager.Index(protoManager.Index(firstFloor)));
                firstFloorGenned = true;
            }
        }

    }
}