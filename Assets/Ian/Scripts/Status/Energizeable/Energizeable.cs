using UnityEngine;
using System.Collections;
using System;

public class Energizeable : MonoBehaviour
{
	//returns how much input wasn't used
	public virtual double Energize(double input)
	{
		throw new NotImplementedException();
	}

	//returns how much input wasn't used
	public virtual double Deenergize(double input)
	{
		throw new NotImplementedException();
	}

	public virtual bool hasEnergy
	{
		get
		{
			throw new NotImplementedException();
		}
	}
	
}

/*
public interface Energizeable
{
	//returns how much input wasn't used
	double Energize(double input);

	//returns how much input wasn't used
	double Deenergize(double input);

	bool hasEnergy
	{
		get;
	}
}
*/
