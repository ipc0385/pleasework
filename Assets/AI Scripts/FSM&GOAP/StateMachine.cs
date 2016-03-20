using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour{

    public IGOAP dataProvider;
    
    public AI_Planner planner;

    void UpdateState();

    void ActivateTrigger(Collider other);

    protected void toMoveTo();

    protected void toDoAction();

    protected void toPlan();
}
