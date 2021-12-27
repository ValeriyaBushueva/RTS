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
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackableClicksRMB, _selectables);

    }
}