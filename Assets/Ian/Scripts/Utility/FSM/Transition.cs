using UnityEngine;
using System.Collections;

//[VERIFICATION NEEDED]
public class Transition : MonoBehaviour 
{
	[SerializeField]
	Ian_FSM.State myState;

	public virtual void Activate(Machine input)
	{

	}

	public Ian_FSM.State state
	{
		get
		{
			return this.myState;
		}
	}
}
