using UnityEngine;
using System.Collections;

public class Reshielder : MonoBehaviour 
{
	[SerializeField]
	GameObject myPrefab, myInstance;

	[SerializeField]
	Energizeable myEnergizeable;

	void Update()
	{
		if(null == this.myPrefab)
		{
			return;
		}

		if (myEnergizeable.hasEnergy && null == this.myInstance)
		{
			//instance died, reshield
			this.myInstance = Instantiate(this.myPrefab, this.transform.position, this.transform.rotation) as GameObject;
			this.myInstance.transform.parent = this.transform;

			Collider otherCollider = this.myInstance.GetComponent<Collider>();
			Collider thisCollider = this.gameObject.GetComponent<Collider>();

			if (null == otherCollider)
			{
				return;
			}

			if (null == thisCollider)
			{
				return;
			}

			Guard_Script guard = this.myInstance.GetComponent<Guard_Script>();

			if (guard)
			{
				guard.energizeable = myEnergizeable;
			}

			Physics.IgnoreCollision(thisCollider, otherCollider);
		}
	}
}
