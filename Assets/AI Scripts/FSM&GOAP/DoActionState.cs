using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoActionState : State{
    private AI_Agent agent;

    private Queue<AI_Action> plan;
    private Queue<AI_Action> currentActions;

    private HashSet<KeyValuePair<string, object>> worldState;
    private HashSet<KeyValuePair<string, object>> goal;

    private HashSet<AI_Action> availableActions;

    public DoActionState(AI_Agent inputAgent)
    {

    }

    public void performDoAction()
    {
        if(checkForActionQueue() != null)
        {

        }
    }

    private bool checkForActionQueue()
    {
        return currentActions.Count > 0;
    }

}