using UnityEngine;
using System.Collections;

public class End_Game : Destructible
{
	public override void Destruct()
	{
		Application.LoadLevel(0);
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
