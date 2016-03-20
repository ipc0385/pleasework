using UnityEngine;
using System.Collections;

public class Single : Activator 
{

	[SerializeField]
	Effecter myEffecter;

	public override void Activate(params object[] input)
	{
		if(base.isReady)
		{
			base.Act();
			
			this.myEffecter.Affect();
		}

		this.Deactivate();
	}

	public override void Deactivate(params object[] input)
	{
		
	}

}
