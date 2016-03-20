using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class State : MonoBehaviour{

    public IGOAP dataProvider;
    
    public AI_Planner planner;

    public virtual void UpdateState()
    {
        throw new NotImplementedException();
    }

    public virtual void ActivateTrigger(Collider other)
    {
        throw new NotImplementedException();
    }

    protected virtual void toMoveTo()
    {
        throw new NotImplementedException();
    }

    protected virtual void toDoAction()
    {
        throw new NotImplementedException();
    }

    protected virtual void toPlan()
    {
        throw new NotImplementedException();
    }
}
