using UnityEngine;
using System.Collections;

//[VERIFICATION NEEDED]
public class Machine : MonoBehaviour 
{
	[SerializeField]
	Ian_FSM.State myState;
	
	public void Switch(Transition input)
	{
		if(this.myState.isValid(input))
		{
			this.myState.Exit(this);

			input.Activate(this);

			this.myState = input.state;

			this.myState.Entry(this);
		}
	}

	void Update()
	{
		if(this.myState)
		{
			this.myState.Loop(this);
		}
	}
}
