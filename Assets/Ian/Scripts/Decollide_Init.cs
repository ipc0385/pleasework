using UnityEngine;
using System.Collections;

public class Decollide_Init : MonoBehaviour
{
	[SerializeField]
	GameObject myOther;

	void Couple()
	{
		if (this.myOther)
		{
			Collider otherCollider = this.myOther.GetComponent<Collider>();
			Collider thisCollider = this.gameObject.GetComponent<Collider>();

			if (null == otherCollider)
			{
				return;
			}

			if (null == thisCollider)
			{
				return;
			}

			Physics.IgnoreCollision(otherCollider, thisCollider);
		}

		Destroy(this);
	}

	// Use this for initialization
	void Start () 
	{
		this.Couple();
	}
	
}
