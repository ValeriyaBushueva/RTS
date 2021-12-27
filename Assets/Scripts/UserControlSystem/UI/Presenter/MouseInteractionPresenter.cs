using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using QuickOutline.Scripts;
using UserControlSystem;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;
    
    private Plane _groundPlane;
    
    private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        if (Input.GetMouseButtonUp(0))
        {
            if (weHit<ISelectable>(hits, out var selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        }
        else
        {
            if (weHit<IAttackable>(hits, out var attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }
    }

    private bool weHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }    
        result = hits
            .Select(hit => hit.collider.GetComponentInParent<T>())
            .Where(c => c != null)
            .FirstOrDefault();
        return result != default;
    }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     var hits = Physics.RaycastAll(ray);
        //     if (hits.Length == 0)
        //     {
        //         return;
        //     }
        //     var selectable = hits
        //         .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
        //         .FirstOrDefault(c => c != null);
        //     _selectedObject.SetValue(selectable);
        //     
        //     var outline = hits
        //         .Select(hit => hit.collider.GetComponentInParent<Outline>())
        //         .FirstOrDefault(c => c != null);
        //     outline.enabled = true;
        // }
        // else
        // {
        //     if (_groundPlane.Raycast(ray, out var enter))
        //     {
        //         _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
        //     }
        // }
    }


