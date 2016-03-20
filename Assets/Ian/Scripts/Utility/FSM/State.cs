using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[VERIFICATION NEEDED]
public class State : MonoBehaviour 
{
	HashSet<Transition> myTransitions = null;
	
	public bool isValid(Transition input)
	{
		return this.myTransitions.Contains(input);
	}
	
	//Machine is used as the input in the case that this state is being shared among many machines and the state acts on data unique to the machine
	public virtual void Entry(Machine input)
	{
		
	}

	public virtual void Loop(Machine input)
	{
		
	}

	public virtual void Exit(Machine input)
	{
		
	}
}
