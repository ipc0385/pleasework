using UnityEngine;
using System.Collections;

//[VERIFICATION NEEDED]
public class Transition : MonoBehaviour 
{
	[SerializeField]
	State myState;

	public virtual void Activate(Machine input)
	{

	}

	public State state
	{
		get
		{
			return this.myState;
		}
	}
}
