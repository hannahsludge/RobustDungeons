
using Content.Server.Map.Systems;
using Robust.Server.Player;
using Robust.Shared.ContentPack;
using Robust.Shared.Prototypes;

namespace Content.Server.Entry
{
    public sealed class EntryPoint : GameClient {

        [Dependency] private readonly IComponentFactory componentFactory = default!;
        [Dependency] private readonly MapGenSystem mapgen = default!;
        [Dependency] IEntityManager entityManager = default!;
        public override void PreInit()
        {
            
            Dependencies.Register<MapGenSystem, MapGenSystem>();
        }
        public override void Init()
        {
            Dependencies.BuildGraph();
            Dependencies.InjectDependencies(this);
            componentFactory.DoAutoRegistrations();  
            componentFactory.GenerateNetIds(); 
        }
        public override void PostInit()
        {
            
            
        }

    }
}
