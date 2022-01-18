using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "GlobalScopeInstaller", menuName = "Installers/GlobalScopeInstaller")]
public class GlobalScopeInstaller : ScriptableObjectInstaller<GlobalScopeInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;


    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo(_legacyContext.GetType()).FromInstance(_legacyContext);
        Container.BindInterfacesAndSelfTo(_groundClicksRMB.GetType()).FromInstance(_groundClicksRMB);
        Container.BindInterfacesAndSelfTo(_attackableClicksRMB.GetType()).FromInstance(_attackableClicksRMB);
        Container.BindInterfacesAndSelfTo(_selectables.GetType()).FromInstance(_selectables);
    }
}