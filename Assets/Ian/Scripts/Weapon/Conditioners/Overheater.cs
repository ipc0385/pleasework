using UnityEngine;
using System.Collections;

public class Overheater : Conditioner 
{
	[SerializeField]
	//weapon unable to fire past this heat
	float myMaxTemperature;

	[SerializeField]
	//when firing, what temperature is gained
	float myActivationHeat;

	[SerializeField]
	//when cooling, what temperature is lost
	float myCoolingTerm;

	[SerializeField]
	//time between the last shot and cooling begins
	float myDuration = 2.0f;

	//time left waiting to cool
	float myWait = 0.0f;

	//heat in gun
	float myTemperature = 0.0f;

	public override void Register()
	{
		this.myWait = this.myDuration;

		this.myTemperature += this.myActivationHeat;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.myWait > 0.0f)
		{
			this.myWait -= Time.deltaTime;
		}
		else
		{ 
			this.myTemperature = Mathf.Max(this.myTemperature - this.myCoolingTerm, 0.0f);
		}
	}
	
	public override bool value
	{
		get 
		{ 
			return this.myTemperature < this.myMaxTemperature; 
		}
	}
}
