using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	[SerializeField]
	GameObject myTarget;

	public GameObject target
	{
		set
		{
			this.myTarget = value;
		}
	}

	Rigidbody myRigidbody;

	void Start()
	{
		this.myRigidbody = this.GetComponent<Rigidbody>();

		if(null == this.myRigidbody)
		{
			Destroy(this);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(Pauser.isPaused)
		{
			return;
		}

		//this.myRigidbody.MoveRotation();
		if(this.myTarget)
		{
			this.transform.forward = (this.myTarget.transform.position - this.transform.position).normalized;
		}
	}
}
