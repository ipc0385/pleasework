using UnityEngine;
using System.Collections;

public class Automatic : Activator 
{
	[SerializeField]
	Effecter myEffecter;

	[SerializeField]
	float myDelay;

	float myWait;

	bool isActive;

	public override void Activate(params object[] input)
	{
		this.isActive = true;
	}

	public override void Deactivate(params object[] input)
	{
		this.isActive = false;
	}

	void Update()
	{
		if (this.myWait <= 0.0f && this.isActive && base.isReady)
		{
			this.myWait = this.myDelay;

			base.Act();
			this.myEffecter.Affect();
		}
		else
		{
			this.myWait -= Time.deltaTime;
		}
	}
}
