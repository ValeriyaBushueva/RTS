using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
{
    private readonly ScriptableObjectValueBase<TAwaited> _scriptableObjectValueBase;
    
    public NewValueNotifier(ScriptableObjectValueBase<TAwaited> scriptableObjectValueBase)
    {
        _scriptableObjectValueBase = scriptableObjectValueBase;
        _scriptableObjectValueBase.OnNewValue += onNewValue;
    }
    
    private void onNewValue(TAwaited obj)
    {
        _scriptableObjectValueBase.OnNewValue -= onNewValue;
        OnWaitFinish(obj);
    }
}


