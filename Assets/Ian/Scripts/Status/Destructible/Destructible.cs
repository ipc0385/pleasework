using UnityEngine;
using System.Collections;
using System;

public class Destructible : MonoBehaviour
{
	public virtual void Destruct()
	{
		throw new NotImplementedException();
	}

	public virtual bool isDestructed
	{
		get
		{
			throw new NotImplementedException();
		}
	}
}

/*
 
public interface Destructible
{
	void Destruct();

	bool isDestructed
	{
		get;
	}
}

 */
