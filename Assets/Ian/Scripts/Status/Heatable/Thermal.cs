using UnityEngine;
using System.Collections;
using System;

public class Thermal : MonoBehaviour
{

	//returns how much input wasn't used
	public virtual double Heat(double input)
	{
		throw new NotImplementedException();
	}

	//returns how much input wasn't used
	public virtual double Cool(double input)
	{
		throw new NotImplementedException();
	}

	public virtual bool isHot
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public virtual bool isCold
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}

/*
public interface Heatable
{
	double Heat(double input);

	double Cool(double input);

	bool isHot();

	bool isCold();
}
*/