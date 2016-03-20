using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public abstract HashSet<KeyValuePair<string, object>> createGoalState();

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal);

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

    }
}
