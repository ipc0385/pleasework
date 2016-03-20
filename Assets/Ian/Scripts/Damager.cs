using UnityEngine;
using System.Collections;

public class Damager : Effecter
{
	[SerializeField]
	float myDamage;

	public override void Affect(params object[] argv)
	{
		foreach (var arg in argv)
		{
			if(null == arg)
			{
				return;
			}
			
			if (arg.GetType() == typeof(GameObject))
			{
				GameObject other = arg as GameObject;

				Damageable damageable = other.GetComponent<Damageable>();
				//Damageable damageable = Interface_Table<Damageable>.Find(other);

				if (damageable)
				{
					damageable.Damage(this.myDamage);
				}

				break;
			}
		}
	}
}
