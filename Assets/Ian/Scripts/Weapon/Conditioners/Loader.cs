using UnityEngine;
using System.Collections;

public class Loader : Conditioner
{
	[SerializeField]
	int myLoad;

	public override bool value
	{
		get
		{
			return this.myLoad > 0;
		}
	}

	public override void Register()
	{
		if (this.value)
		{
			this.myLoad--;
		}
	}
}
