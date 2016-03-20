using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_Planner : MonoBehaviour {


    /*1. Decouple goals and actions
            What is a goal? Goal is formualted and taken from a graph we formulate from a worldstate
     *      What is an action in this plan? Action are nodes that are made in the graph
    2.*/
    public Queue<AI_Action> plan(GameObject agent,
                        HashSet<AI_Action> availableActions,
                        HashSet<KeyValuePair<string, object>> worldState,
                        HashSet<KeyValuePair<string, object>> goal)
    {
        //Retrieves and stores availableActions into chosen actions, which then 
        //can be used for the planner to decide what to do
        HashSet<AI_Action> chosenActions = new HashSet<AI_Action>();
        foreach (AI_Action A in availableActions)
        {
            if (A.checkProceduralPreconditions(agent))
                chosenActions.Add(A);
        }


        //list of leaves, which will either point from action to action, or null
        List<Node> leaves = new List<Node>();

        Node start = new Node(null, 0, worldState, null);
        bool success = buildGraph(start, leaves, chosenActions, goal);

        if(success == false)
        {
            Debug.Log("No Plan");
            return null;
        }

        //Find the cheapest node currently available
        Node cheapest = null;
        foreach(Node leaf in leaves)
        {
            if (cheapest == null)
                cheapest = leaf;
            else
            {
                if (leaf.costSoFar < cheapest.costSoFar)
                    cheapest = leaf;
            }
        }

        List<AI_Action> result = new List<AI_Action>();
        Node n = cheapest;
        while(n != null)
        {
            if(n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        //take the actions
        Queue<AI_Action> queue = new Queue<AI_Action>();
        foreach(AI_Action a in result)
        {
            queue.Enqueue(a);
        }
        //return the plan
        Debug.Log(queue);
        return queue;
    }
    HashSet<KeyValuePair<string, object>> WorldKnowledge;

    //builds graph of possible plans with actions
    public bool buildGraph (Node parent, List<Node> leaves, HashSet<AI_Action> chosenActions, 
    HashSet<KeyValuePair<string, object>> goal)
    {
     bool foundSuccess = false;
        foreach(AI_Action action in chosenActions)
        {
        //order the actions into a tree graph, make each Plan have a correct order of actions
            if(inState(action.Preconditions , parent.state))
            {
                HashSet<KeyValuePair<string, object>> currentState = populateState(parent.state, action.Effects);
                //Debug.Log(AI_Agent.prettyprint(currentState));
                //THIS is where the node takes in account for the actions' cost
                Node node = new Node(parent, parent.costSoFar + action.cost, currentState, action);

                if(inState(goal, currentState))
                {
                    leaves.Add(node);
                    foundSuccess = true;
                }

                else
                {
                    HashSet<AI_Action> subset = actionSubset(chosenActions, action);
                    bool found = buildGraph(node, leaves, subset, goal);
                    if (found)
                        foundSuccess = true;
                }
            }
            
        }
        return foundSuccess;
    }

    //purpose of this is to apply the statechange to currentstate
    //what is statechange in current context?
    //what is currentstate in current context?
    private HashSet<KeyValuePair<string, object>> populateState(HashSet<KeyValuePair<string, object>> currentState,
        HashSet<KeyValuePair<string, object>> stateChange)
    {
        //state will hold all availalbe KVPs (which are actions)
        HashSet<KeyValuePair<string, object>> state = new HashSet<KeyValuePair<string,object>>();

        foreach(KeyValuePair<string, object> s in currentState)
            {
                state.Add(new KeyValuePair<string, object>(s.Key, s.Value));
            }
        //checks against KVPs in stateChange from state, if they are equivalent, then the state KVP(key, value) are updated
        foreach (KeyValuePair<string, object> change in stateChange)
        {
            bool exists = false;
            foreach(KeyValuePair<string, object> s in state)
            {
                if (s.Equals(change))
                    exists = true;
                break;
            }
   
            //if pair that does exists, removes it from the possibility of being posted in the graph, or repeated(?) check again
            if(exists == true)
            {
                state.RemoveWhere((KeyValuePair<string, object> kvp) => {return kvp.Key.Equals(change.Key) ;} );
                KeyValuePair<string, object> updated = new KeyValuePair<string, object>(change.Key, change.Value);
                state.Add(updated);
            }
        }
            return state;
    }

    //checks if the test action is in the state action
    public bool inState(HashSet<KeyValuePair<string,object>> test, HashSet<KeyValuePair<string,object>> state)
    {
        bool allMatch = true;
        foreach(KeyValuePair<string,object> t in test)
        {
            bool match = false;
            foreach(KeyValuePair<string, object> s in state)
            {
                if(s.Equals(t))
                {
                    match = true;
                    break;
                }
            }
            if(!match)
            allMatch = false;
        }
        return allMatch;
    }

    //RTA = RemoveThisAction
    //creates a subset of actions that excludes the RTA from the set
    public HashSet<AI_Action> actionSubset(HashSet<AI_Action> actions, AI_Action RTA)
    {
        HashSet<AI_Action> subset = new HashSet<AI_Action>();
        foreach(AI_Action a in actions)
        {
            if(a.Equals(RTA))
            {
                subset.Add(a);
            }
        }
        return subset;
    }
}

//Node class, each node represents an action, will build a graph out of nodes
public class Node
{
    public Node parent;
    public float costSoFar;
    public HashSet<KeyValuePair<string, object>> state;
    public AI_Action action;

    public Node(Node parent, float costSoFar, HashSet<KeyValuePair<string, object>> state, AI_Action action)
    {
        this.parent = parent;
        this.costSoFar = costSoFar;
        this.state = state;
        this.action = action;
    }
}
