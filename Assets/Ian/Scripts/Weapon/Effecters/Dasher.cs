using UnityEngine;
using System.Collections;

public class Dasher : Effecter {

	[SerializeField]
	Vector3 myForce;

	Rigidbody myRigidbody;

	void Start()
	{
		this.myRigidbody = GetComponent<Rigidbody>();

		if(null == this.myRigidbody)
		{
			Debug.Log("error: dasher couldn't find rigidbody on " + gameObject);

			Destroy(this);
		}
	}

	public override void Affect(params object[] argv)
	{
		this.myRigidbody.AddRelativeForce(this.myForce);
	}
}
