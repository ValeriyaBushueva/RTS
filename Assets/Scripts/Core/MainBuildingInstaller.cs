using UnityEngine;
using Zenject;

public class MainBuildingInstaller : MonoInstaller
{
    [SerializeField] private FactionMemberParallelInfoUpdater _factionMemberParallelInfoUpdater;

    public override void InstallBindings()
    {
        Container.Bind<IFactionMember>().FromComponentInChildren();
        Container
            .Bind<ITickable>()
            .FromInstance(_factionMemberParallelInfoUpdater);
    }

}
