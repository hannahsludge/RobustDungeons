
using Content.Server.Map.Systems;
using Robust.Shared.ContentPack;
using Robust.Shared.Prototypes;

namespace Content.Server.Entry
{
    public sealed class EntryPoint : GameClient {

        [Dependency] private readonly IComponentFactory _componentFactory = default!;
        [Dependency] private readonly IPrototypeManager _protoManager = default!;
        [Dependency] private readonly MapGenSystem _mapgen = default!;
        [Dependency] IEntityManager entityManager = default!;

        public override void PreInit()
        {
            
            Dependencies.Register<MapGenSystem, MapGenSystem>();
        }
        public override void Init()
        {
            Dependencies.BuildGraph();
            Dependencies.InjectDependencies(this);
            _componentFactory.DoAutoRegistrations();  
            _componentFactory.GenerateNetIds(); 
        }
        static readonly EntProtoId testFloor = "TestFloor";
        public override void PostInit()
        {
            _mapgen.GenerateFloor(_protoManager.Index(testFloor));

        }
    }
}
