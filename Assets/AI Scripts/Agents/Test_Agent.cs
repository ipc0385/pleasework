using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Test_Agent : MonoBehaviour, IGOAP {

    public float moveSpeed = 1;

    void Start()
    {

    }

    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("isMoving", false));

        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState()
    {
       throw new NotImplementedException();
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        throw new NotImplementedException();
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<AI_Action> actions)
    {
        Debug.Log("--------Plan Found---------");
    }

    public void actionsFinished()
    {
        Debug.Log("--/--Actions Finished--/--");
    }

    public void planAborted(AI_Action aborter)
    {
        Debug.Log("PLAN ABORTED PLAN ABORTED PLAN ABORTED");
    }

    public bool moveAgent(AI_Action nextAction)
    {
        return false;
    }
}
