using UnityEngine;
using System.Collections;
using System;

public class Electrical : MonoBehaviour
{
	//returns how much input wasn't used
	public virtual double Negate(double input)
	{
		throw new NotImplementedException();
	}

	//returns how much input wasn't used
	public virtual double Posate(double input)
	{
		throw new NotImplementedException();
	}

	//returns how much input wasn't used
	public virtual double Neutralize(double input)
	{
		throw new NotImplementedException();
	}

	public virtual bool isPositive
	{
		get	
		{
			throw new NotImplementedException();
		}
	}

	public virtual bool isNegative
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}

/*
public interface Chargeable
{
	double Negate(double input);

	double Posate(double input);

	double Neutralize(double input);

	bool isPositive();

	bool isNegative();
}
*/

