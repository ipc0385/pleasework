using UnityEngine;
using System.Collections;

public class Health_Script : Damageable
{
	[SerializeField]
	double myCapacity, myDamage;

	double health
	{
		get
		{
			return this.myCapacity - this.myDamage;
		}
	}

	void Health_Check()
	{
		if (this.health <= 0d)
		{
			Destructible destructible = this.GetComponent<Destructible>();

			if(destructible)
			{
				destructible.Destruct();
			}
		}
	}

	public override double Damage(double input)
	{
		double remains = this.health;
		double result;

		if (input < remains)
		{
			//doesn't empty out
			this.myDamage += input;
			result = input;
		}
		else
		{
			//emptyies out
			result = input - remains;
			this.myDamage = this.myCapacity;
		}

		this.Health_Check();
		return result;
	}

	//returns how much input wasn't used
	public override double Repair(double input)
	{
		if (input < 0d)
		{
			return input;
		}

		if (input < this.myDamage)
		{
			//doesn't fill it up
			this.myDamage -= input;
			return 0d;
		}
		else
		{
			//filled up
			double result = input - this.myDamage;
			myDamage = 0d;
			return result;
		}
	}

	public override bool isDamaged
	{
		get
		{
			return this.myDamage > 0d;
		}
	}

	public override bool isUndamaged
	{
		get
		{
			return this.myDamage == 0d;
		}
	}

}

/*
public class Health_Script : MonoBehaviour, Damageable, Destructible
{
	[SerializeField]
	double myCapacity, myDamage;

	double health
	{
		get
		{
			return this.myCapacity - this.myDamage;
		}
	}

	public void Destruct()
	{
		Destroy(this.gameObject);
	}

	public bool isDestructed
	{
		get
		{
			return this.myDamage >= this.myCapacity;
		}
	}

	void Health_Check()
	{
		if (this.isDestructed)
		{
			this.Destruct();
		}
	}

	public double Damage(double input)
	{
		double remains = this.health;
		if (input < remains)
		{
			//doesn't empty out
			this.myDamage += input;
			Health_Check();
			return input;
		}
		else
		{
			//emptyies out
			double result = input - remains;
			this.myDamage = this.myCapacity;
			Health_Check();
			return result;
		}
	}

	//returns how much input wasn't used
	public double Repair(double input)
	{
		if(input < 0d)
		{
			return input;
		}

		if (input < this.myDamage)
		{
			//doesn't fill it up
			this.myDamage -= input;
			return 0d;
		}
		else
		{
			//filled up
			double result = input - this.myDamage;
			myDamage = 0d;
			return result;
		}
	}

	public bool isDamaged
	{
		get
		{
			return this.myDamage > 0d;
		}
	}

	public bool isUndamaged
	{
		get
		{
			return this.myDamage == 0d;
		}
	}

	void Start()
	{
		Interface_Table<Damageable>.Register(this.gameObject, this);
		Interface_Table<Destructible>.Register(this.gameObject, this);
	}

	void OnDestroy()
	{
		Interface_Table<Damageable>.Deregister(this.gameObject);
		Interface_Table<Destructible>.Deregister(this.gameObject);
	}

}
*/

