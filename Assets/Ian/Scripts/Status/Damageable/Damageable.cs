using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//interfaces can be combined, components can't be
public abstract class Damageable : MonoBehaviour
{
	//returns how much damage was left over from intake, if =0 then totally used, if =input then unused
	public virtual double Damage(double input)
	{
		throw new NotImplementedException();
	}

	//returns how much input was left over from repairs, if =0 then totally used, if =input then none of it
	public virtual double Repair(double input)
	{
		throw new NotImplementedException();
	}

	public virtual bool isDamaged
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public virtual bool isUndamaged
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}

/*
 
public interface Damageable
{
	//retusn how much damage was left over from intake, if =0 then totally used, if =input then unused
	double Damage(double input);

	//returns how much input was left over from repairs, if =0 then totally used, if =input then none of it
	double Repair(double input);

	bool isDamaged
	{
		get;
	}

	bool isUndamaged
	{
		get;
	}
}

 */
