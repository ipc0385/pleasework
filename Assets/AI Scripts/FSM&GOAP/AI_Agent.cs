using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_Agent : MonoBehaviour
{
    public State currentState;
    public PlanState planState;
    private HashSet<AI_Action> availableActions;
    private Queue<AI_Action> currentActions;

    private IGOAP dataProvider;

    private AI_Planner planner;

    private void Awake()
    {
        planState = new PlanState(this);
    }
    
    void Start()
    {
        
        availableActions = new HashSet<AI_Action>();
        currentActions = new Queue<AI_Action>();
        

    }

    public bool hasActionsReady()
    {
        return currentActions.Count > 0;
    }

    

}
