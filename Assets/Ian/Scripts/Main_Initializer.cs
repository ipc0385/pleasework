using UnityEngine;
using System.Collections;

public class Main_Initializer : MonoBehaviour 
{
	[SerializeField]
	Messenger myLeftClicker;

	[SerializeField]
	Messenger myRightClicker;

	[SerializeField]
	Activator myLeftWeapon;

	[SerializeField]
	Activator myRightWeapon;

	// Use this for initialization
	void Start ()
	{
		if (this.myLeftClicker && this.myLeftWeapon)
		{
			this.myLeftClicker.Subscribe(this.myLeftWeapon.Activate);
		}

		if (this.myRightClicker && this.myRightWeapon)
		{
			this.myRightClicker.Subscribe(this.myRightWeapon.Activate);
		}

		Destroy(this);
	}

}
