using UnityEngine;
using System.Collections;

public class Destroyer : Destructible
{
	public override void Destruct()
	{
		Destroy(this.gameObject);
	}

	public override bool isDestructed
	{
		get
		{
			//if the object were alive to call this function, it wouldn't be able to return true
			return false;
		}
	}
}
