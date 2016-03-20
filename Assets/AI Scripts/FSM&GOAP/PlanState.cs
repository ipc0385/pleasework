using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanState : State{

    private AI_Agent agent;

    private Queue<AI_Action> plan;
    private Queue<AI_Action> currentActions;

    private HashSet<KeyValuePair<string, object>> worldState;
    private HashSet<KeyValuePair<string, object>> goal;

    private HashSet<AI_Action> availableActions;
    
    public PlanState(AI_Agent inputAgent)
    {
        agent = inputAgent;

        availableActions = new HashSet<AI_Action>();
        currentActions = new Queue<AI_Action>();

        worldState = dataProvider.getWorldState();
        goal = dataProvider.createGoalState();
       
        Queue<AI_Action> plan = planner.plan(gameObject, availableActions, worldState, goal);
    }

    public void UpdateState()
    {
        performPlanState();
    }

    public void performPlanState()
    {
        if(plan != null)
        {
            Debug.Log("PlanState: Successful Plan");
            plan = currentActions;
            dataProvider.planFound(goal, plan);
            toDoAction();
        }
        else
        {
            Debug.Log("PlanState: Failed Plan");
            toPlan();
        }
    }

    public void toDoAction()
    {
        agent.currentState = agent.doAction;
    }

}

