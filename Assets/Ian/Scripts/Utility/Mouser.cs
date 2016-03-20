using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Input_Messengers
{
	[SerializeField]
	public Messenger myDown, myUp;
}

public class Mouser : MonoBehaviour 
{
	static public Mouser singleton;

	[SerializeField]
	public Input_Messengers[] myClicks;

	void Awake()
	{
		if(Mouser.singleton)
		{
			Destroy(this);
		}	
		else
		{
			Mouser.singleton = this;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if(Pauser.isPaused)
		{
			return;
		}	
		
		for(int i = 0; i < 2; i++)
		{
			if (this.myClicks[i].myDown && Input.GetMouseButtonDown(i))
			{
				this.myClicks[i].myDown.Publish();
			}

			if (this.myClicks[i].myUp && Input.GetMouseButtonUp(i))
			{
				this.myClicks[i].myUp.Publish();
			}
		}
	}
}
