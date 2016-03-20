using UnityEngine;
using System.Collections;

public class Main_Weapon_Init : MonoBehaviour {
	
	[SerializeField]
	int myButton;
	
	// Use this for initialization
	void Start () 
	{
		foreach(Activator activator in GetComponents<Activator>())
		{
			Mouser.singleton.myClicks[this.myButton].myDown.Subscribe(activator.Activate);

			Mouser.singleton.myClicks[this.myButton].myUp.Subscribe(activator.Deactivate);
		}

		Destroy(this);
	}
}
