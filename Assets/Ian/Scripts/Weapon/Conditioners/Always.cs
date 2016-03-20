using UnityEngine;
using System.Collections;

public class Always : Conditioner
{
	public override bool value
	{
		get { return true; }
	}
}
