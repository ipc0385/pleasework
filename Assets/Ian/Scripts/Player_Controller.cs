using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour 
{
	Rigidbody myRigidbody;

	[SerializeField]
	Vector3 mySpeed;

	[SerializeField]
	float myTorque;

	[SerializeField]
	float mySensitivity;

	[SerializeField]
	float myReverse;

	// Use this for initialization
	void Start () 
	{
		this.myRigidbody = this.GetComponent<Rigidbody>();
	}
	
	public enum Mode
	{
		Ian,
		James
	}

	[SerializeField]
	Mode myMode;

	Vector3 Ian_Controls()
	{
		Vector3 movement = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			movement += Vector3.up;
		}

		if (Input.GetKey(KeyCode.A))
		{
			movement += Vector3.left;
		}

		if (Input.GetKey(KeyCode.X))
		{
			movement += Vector3.down;
		}

		if (Input.GetKey(KeyCode.S))
		{
			movement += (Input.GetKey(KeyCode.LeftShift) ? Vector3.back : Vector3.forward);
		}

		if (Input.GetKey(KeyCode.D))
		{
			movement += Vector3.right;
		}
		
		return movement;
	}

	Vector3 James_Controls()
	{
		Vector3 movement = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			movement += Vector3.forward;
		}

		if (Input.GetKey(KeyCode.A))
		{
			movement += Vector3.left;
		}

		if (Input.GetKey(KeyCode.S))
		{
			movement += Vector3.back;
		}

		if (Input.GetKey(KeyCode.D))
		{
			movement += Vector3.right;
		}

		if (Input.GetKey(KeyCode.LeftShift))
		{
			movement = Quaternion.Euler(-90.0f, 0.0f, 0.0f) * movement;
		}

		return movement;
	}

	// Update is called once per frame
	void Update ()
	{
		Rigidbody rigidbody = this.myRigidbody;
		float torque_factor = this.myTorque;
		float sensitivity_factor = this.mySensitivity;
		float reverse_factor = this.myReverse;
		Vector3 speed_factors = this.mySpeed;

		if (null == rigidbody)
		{
			Debug.Log("Player_Controller is missing Rigidbody");
			return;
		}

		Vector3 movement = Vector3.zero;

		switch(this.myMode)
		{
			case Mode.Ian:
				movement = Ian_Controls();
				break;

			case Mode.James:
				movement = James_Controls();
				break;
		}

		movement = new Vector3(movement.x * speed_factors.x, movement.y * speed_factors.y, movement.z * speed_factors.z);

		if(movement.z < 0.0f)
		{
			movement.z *= reverse_factor;
		}

		rigidbody.AddRelativeForce(movement * Time.deltaTime);

		Vector3 torque = Vector3.zero;

		if (Input.GetKey(KeyCode.Q))
		{
			torque += Vector3.forward * torque_factor;
		}

		if (Input.GetKey(KeyCode.E))
		{
			torque += Vector3.back * torque_factor;
		}

		float x = Input.GetAxis("Mouse X") * torque_factor * sensitivity_factor;
		float y = Input.GetAxis("Mouse Y") * torque_factor * sensitivity_factor;

		torque += Vector3.up * x;

		torque += Vector3.left * y;

		rigidbody.AddRelativeTorque(torque * Time.deltaTime);
	}

}
