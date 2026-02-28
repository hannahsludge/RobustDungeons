
using Robust.Shared.ContentPack;
using Robust.Shared.Map.Components;

namespace Content.Client.Entry
{ 
    public sealed class EntryPoint : GameClient {

        [Dependency] private readonly IComponentFactory _componentFactory = default!;
        public override void Init()
        {
            Dependencies.BuildGraph();
            Dependencies.InjectDependencies(this);
            _componentFactory.DoAutoRegistrations();  
            _componentFactory.GenerateNetIds(); 
            
        }
        public override void PostInit()
        {
            base.PostInit();
        }
    }

}