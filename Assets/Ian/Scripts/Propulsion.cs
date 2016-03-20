using UnityEngine;
using System.Collections;

public class Propulsion : MonoBehaviour {
	
	[SerializeField]
	float mySpeed;	

	Rigidbody myRigidbody;

	void Start()
	{
		this.myRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (this.myRigidbody)
		{
			this.myRigidbody.AddRelativeForce(Vector3.forward * this.mySpeed * Time.deltaTime);
		}
	}
}
