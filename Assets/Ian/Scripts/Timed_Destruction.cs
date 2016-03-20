using UnityEngine;
using System.Collections;

public class Timed_Destruction : MonoBehaviour {
	
	[SerializeField]
	float myLifetime;

	// Update is called once per frame
	void Update () 
	{
		if(this.myLifetime <= 0.0f)
		{
			Destroy(gameObject);
		}
		else
		{
			this.myLifetime -= Time.deltaTime;
		}
	}
}
