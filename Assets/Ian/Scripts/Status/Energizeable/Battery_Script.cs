using UnityEngine;
using System.Collections;

public class Battery_Script : Energizeable
{
	[SerializeField]
	double myCapacity, myDrained, myRate, myWait;

	double myIter;

	public double energy
	{
		get
		{
			return this.myCapacity - this.myDrained;
		}
	}

	//returns how much input was used
	public override double Energize(double input)
	{
		if (input < this.myDrained)
		{
			//doesn't fill it up
			this.myDrained = Doubles.Max(this.myDrained - input, 0d);
			return 0d;
		}
		else
		{
			//filled up
			double result = input - this.myDrained;
			this.myDrained = 0d;
			return result;
		}
	}

	public override double Deenergize(double input)
	{
		this.myIter = this.myWait;

		double remains = this.energy;
		if (input < remains)
		{
			//doesn't empty out
			this.myDrained += input;
			return input;
		}
		else
		{
			//emptyies out
			double result = input - remains;
			this.myDrained = this.myCapacity;
			return result;
		}
	}

	public override bool hasEnergy
	{
		get
		{
			return this.energy > 0d;
		}
	}

	void Update()
	{
		if (this.myIter > 0d)
		{
			this.myIter -= Time.deltaTime;
		}
		else
		{
			this.Energize(this.myRate * Time.deltaTime);
		}
	}
}

/*
public class Battery_Script : MonoBehaviour, Energizeable
{
	[SerializeField]
	double myCapacity, myDrained, myRate, myWait;

	double myIter;

	void Start()
	{
		Interface_Table<Energizeable>.Register(this.gameObject, this);
	}

	void OnDestroy()
	{
		Interface_Table<Energizeable>.Deregister(this.gameObject);
	}

	double energy
	{
		get
		{
			return this.myCapacity - this.myDrained;
		}
	}

	//returns how much input was used
	public double Energize(double input)
	{
		if(input < this.myDrained)
		{
			//doesn't fill it up
			this.myDrained = Doubles.Max(this.myDrained - input, 0d);
			return 0d;
		}
		else
		{
			//filled up
			double result = input - this.myDrained;
			this.myDrained = 0d;
			return result;
		}
	}

	public double Deenergize(double input)
	{
		this.myIter = this.myWait;

		double remains = this.energy;
		if (input < remains)
		{
			//doesn't empty out
			this.myDrained += input;
			return input;
		}
		else
		{
			//emptyies out
			double result = input - remains;
			this.myDrained = this.myCapacity;
			return result;
		}
	}

	public bool hasEnergy
	{
		get
		{
			return this.energy > 0d;
		}
	}

	void Update()
	{
		if(this.myIter > 0d)
		{
			this.myIter -= Time.deltaTime;
		}
		else
		{
			this.Energize(this.myRate * Time.deltaTime);
		}
	}
}
*/
