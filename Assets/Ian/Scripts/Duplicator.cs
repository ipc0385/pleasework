using UnityEngine;
using System.Collections;

public class Duplicator : MonoBehaviour 
{
	float wait;

	[SerializeField]
	float duration;

	void Awake()
	{
		this.wait = this.duration;
	}

	void Update()
	{
		if (this.wait <= 0f)
		{
			this.wait = this.duration;

			Instantiate(this.gameObject, this.transform.position + this.transform.forward, this.transform.rotation);
		}
		else
		{
			wait -= Time.deltaTime;
		}
	}
}
