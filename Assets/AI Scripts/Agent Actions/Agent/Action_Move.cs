using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action_Move : AI_Action
{
    public GameObject EnemyTarget;

    public bool moved = false;


    public Action_Move()
    {
        addPrecondition("objectExists", true);
        addEffect("isMoving", true);
    }

    public override bool checkProceduralPreconditions(GameObject agent)
    {
        throw new System.NotImplementedException();
    }

    public override bool performAction(GameObject agent)
    {
        Debug.Log("In perform action");
        return true;
    }

    public override bool isDone()
    {
        throw new System.NotImplementedException();
    }

    public override void reset()
    {
        throw new System.NotImplementedException();
    }
}
