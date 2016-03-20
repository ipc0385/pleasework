using UnityEngine;
using System.Collections;

public class Double_Key_Initer : MonoBehaviour {

	[SerializeField]
	KeyCode myKey;

	[SerializeField]
	Activator myActivator;

	// Use this for initialization
	void Update () 
	{
		Double_Key.ourDoubleKeys[this.myKey].myMessengers.myDown.Subscribe(this.myActivator.Activate);
		
		Double_Key.ourDoubleKeys[this.myKey].myMessengers.myUp.Subscribe(this.myActivator.Deactivate);

		Destroy(this);
	}
}
