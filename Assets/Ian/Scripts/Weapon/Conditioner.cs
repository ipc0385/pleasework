using UnityEngine;
using System.Collections;

public abstract class Conditioner : MonoBehaviour 
{
	public abstract bool value
	{
		get;
	}
	
	public virtual void Register()
	{
		//basically a callback for activating so that i don't need to make a million messengers for
	}

}
