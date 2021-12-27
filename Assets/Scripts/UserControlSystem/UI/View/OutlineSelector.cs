using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public sealed class OutlineSelector : MonoBehaviour
{
    [SerializeField] private Outline[] _outlineComponents;

    private bool _isSelectedCache;

    private void Start()
    {
        _outlineComponents = GetComponentsInChildren<Outline>();
        DisableOutline();
    }

    public void SetSelected(bool isSelected)
    {
        if (isSelected == _isSelectedCache)
        {
            return;
        }

        if (isSelected)
        {
            EnableOutline();
        }
        else
        {
            DisableOutline();
        }
        
        _isSelectedCache = isSelected;
    }

    private void DisableOutline()
    {
        for (int i = 0; i < _outlineComponents.Length; i++)
        {
            _outlineComponents[i].enabled = false;
        }
    }

    private void EnableOutline()
    {
        for (int i = 0; i < _outlineComponents.Length; i++)
        {
            _outlineComponents[i].enabled = true;
        }
    }
}
