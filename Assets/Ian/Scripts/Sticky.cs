using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		//ignore projectiles
		switch(other.gameObject.layer)
		{
			case 8: return;
			case 9: return;
		}

		this.transform.parent = other.transform;

		Rigidbody rigidbody = this.GetComponent<Rigidbody>();

		Destroy(rigidbody);

		Destroy(this);
	}

	void OnCollisionEnter(Collision other)
	{
		//ignore projectiles
		switch (other.gameObject.layer)
		{
			case 8: return;
			case 9: return;
		}

		this.transform.parent = other.transform;

		Rigidbody rigidbody = this.GetComponent<Rigidbody>();

		Destroy(rigidbody);

		Destroy(this);
	}
}
