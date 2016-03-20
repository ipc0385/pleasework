using UnityEngine;
using System.Collections;

public class Forced_Spawner : Effecter
{
	[SerializeField]
	float myForce;

	[SerializeField]
	float myOffset;

	[SerializeField]
	GameObject mySpawn;

	Collider myCollider;

	void Start()
	{
		this.myCollider = this.GetComponent<Collider>();
	}

	public override void Affect(params object[] argv)
	{
		GameObject gameObject = Instantiate(this.mySpawn, this.transform.forward * myOffset + this.transform.position, this.transform.rotation) as GameObject;

		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
		
		rigidbody.AddForce(this.transform.forward * this.myForce);

		Collider collider = gameObject.GetComponent<Collider>();

		if(this.myCollider && collider)
		{
			Physics.IgnoreCollision(this.myCollider, collider);
		}
	}

}
