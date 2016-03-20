using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour 
{
	//dykstra
	[SerializeField]
	Pathnoder myStart;

	[SerializeField]
	Pathnoder myGoal;

	Queue<Pathnoder> myQueue = new Queue<Pathnoder>();

	[SerializeField]
	float mySpeed;

	Rigidbody myRigidbody;

	void Awake()
	{
		this.myRigidbody = this.GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.myQueue = Pathnoder.Pathfind(this.myStart, this.myGoal);

			Debug.Log(this.myQueue);
		}

		if (null != this.myQueue && this.myQueue.Count > 0)
		{
			Pathnoder node = this.myQueue.Peek();

			Vector3 difference = node.transform.position - this.transform.position - this.myRigidbody.velocity;

			this.myRigidbody.AddForce(difference.normalized * this.mySpeed * Time.deltaTime);
		}
	}

	public void Triggered_Node (Pathnoder node)
	{
		if(this.myQueue.Peek() == node)
		{
			this.myQueue.Dequeue();
		}
	}
}
