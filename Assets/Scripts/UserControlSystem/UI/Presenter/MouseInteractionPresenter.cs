using System.Linq;
using Abstractions;
using UnityEngine;
using UserControlSystem;
using QuickOutline.Scripts;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    private Outline _outline;

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
        {
            return;
        }
        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);
        _selectedObject.SetValue(selectable);
        
        _outline = hits.Select(hit => hit.collider.GetComponentInParent<Outline>()).FirstOrDefault(c => c != null);
        _outline.enabled = true;
       
       
       
    }
}