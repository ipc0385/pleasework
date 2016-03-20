using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour 
{
	[SerializeField]
	GameObject myTarget;

	// Update is called once per frame
	void Update () 
	{
		this.transform.forward = (this.myTarget.transform.position - this.transform.position).normalized;
	}
}
