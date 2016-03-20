using UnityEngine;
using System.Collections;

public class Guard_Script : Damageable
{
	[SerializeField]
	Energizeable myEnergizeable;

	public Energizeable energizeable
	{
		set
		{
			this.myEnergizeable = value;
		}
	}

	void Energy_Check()
	{
		if (null == this.myEnergizeable ? true : !this.myEnergizeable.hasEnergy)
		{
			Destructible destructible = this.GetComponent<Destructible>();

			if (destructible)
			{
				destructible.Destruct();
			}
		}
	}

	public override double Damage(double input)
	{
		double result;
		
		if (null == this.myEnergizeable)
		{
			result = input;
		}
		else
		{
			result = this.myEnergizeable.Deenergize(input);
		}

		Energy_Check();
		return result;
	}

	public override double Repair(double input)
	{
		return input;
	}

	public override bool isDamaged
	{
		get
		{
			return false;
		}
	}

	public override bool isUndamaged
	{
		get
		{
			return true;
		}
	}
}


/*
 
public class Guard_Script : MonoBehaviour, Damageable, Destructible
{
	[SerializeField]
	Energizeable myEnergizeable;

	public Energizeable energizeable
	{
		set
		{
			this.myEnergizeable = value;
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

	public void Destruct()
	{
		Destroy(this.gameObject);
	}

	public bool isDestructed
	{
		get
		{
			return null == this.myEnergizeable ? true : !this.myEnergizeable.hasEnergy;
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
		double result;
		
		if (null == this.myEnergizeable)
		{
			result = input;
		}
		else
		{
			result = this.myEnergizeable.Deenergize(input);
		}

		Health_Check();
		return result;
	}

	public double Repair(double input)
	{
		return input;
	}

	public bool isDamaged
	{
		get
		{
			return false;
		}
	}

	public bool isUndamaged
	{
		get
		{
			return true;
		}
	}
}

 */
