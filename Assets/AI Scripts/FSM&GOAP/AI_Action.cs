using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AI_Action : MonoBehaviour {

    private HashSet<KeyValuePair<string, object>> preconditions;
    private HashSet<KeyValuePair<string, object>> effects;

    public float cost = 1f;

    public GameObject target;

    private bool inRange;

    public void actionReset()
    {
        inRange = false;
        target = null;
        reset();
    }

    public abstract void reset();

    public AI_Action()
    {
        preconditions = new HashSet<KeyValuePair<string, object>>();
        effects = new HashSet<KeyValuePair<string, object>>();
    }

    public bool checkPreconditions(HashSet<KeyValuePair<string, object>> WorldPerception)
    {
        if (preconditions.IsSubsetOf(WorldPerception))
            return true;
        else
            return false;
    }

    public bool isInRange()
    {
        return inRange;
    }

    public void setInRange(bool isInRange)
    {
        this.inRange = isInRange;
    }

    public abstract bool isDone();

    public abstract bool checkProceduralPreconditions(GameObject agent);

    public abstract bool performAction (GameObject agent);

    public void addPrecondition(string Key, object value)
    {
        preconditions.Add(new KeyValuePair<string, object>(Key, value));
    }
    
    public void removePreconditions(string Key, object value)
    {
        foreach(KeyValuePair<string, object> kvp in preconditions)
        {
            if (kvp.Key == Key && kvp.Value == value)
                preconditions.Remove(kvp);
        }
    }

    public void addEffect(string key, object value)
    {
        effects.Add(new KeyValuePair<string, object>(key, value));
    }

    //Properties
    public HashSet<KeyValuePair<string, object>> Preconditions
    {
        get
        {
            return preconditions;
        }
    }

    public HashSet<KeyValuePair<string, object>> Effects
    {
        get
        {
            return effects;
        }
    }
   
}
