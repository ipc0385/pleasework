using UnityEngine;
using System.Collections;

public abstract class Activator : MonoBehaviour 
{
	[SerializeField]
	Conditioner myConditioner;

	public bool isCapable 
	{
		get
		{
			return this.myConditioner;
		}
	}

	protected void Act()
	{
		this.myConditioner.Register();
	}

	public bool isReady
	{
		get
		{
			return this.isCapable && this.myConditioner.value;
		}
	}

	public abstract void Activate(params object[] input);

	public abstract void Deactivate(params object[] input);

}
