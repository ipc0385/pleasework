using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Double_Key : MonoBehaviour 
{
	//every key a double_key can listen to is a singleton
	public static Dictionary<KeyCode, Double_Key> ourDoubleKeys = new Dictionary<KeyCode, Double_Key>();

	[SerializeField]
	KeyCode myKey;

	[SerializeField]
	public Input_Messengers myMessengers;

	void Start()
	{
		if(this.myKey == KeyCode.None)
		{
			Destroy(this);
		}
		
		if(Double_Key.ourDoubleKeys.ContainsKey(this.myKey))
		{
			Destroy(this);
		}
		else
		{
			Double_Key.ourDoubleKeys[this.myKey] = this;
		}
	}

	//time when first tap happened
	float myTime;

	//is true when held down by double tapping
	bool myHeld;

	void Update ()
	{
		if (Pauser.isPaused)
		{
			return;
		}

		//if key is pressed within the threshold fire an event
		if(this.myHeld)
		{
			//detect lifting

			if(Input.GetKeyUp(this.myKey))
			{
				this.myHeld = false;

				if (this.myMessengers.myUp)
				{
					this.myMessengers.myUp.Publish();
				}
			}
		}
		else
		{
			//detect double tapping
			
			if(Input.GetKeyDown(this.myKey))
			{
				if(Time.time - this.myTime < 0.5f)
				{
					this.myHeld = true;

					if(this.myMessengers.myDown)
					{
						this.myMessengers.myDown.Publish();
					}
				}

				this.myTime = Time.time;
			}
		}

	}
}
