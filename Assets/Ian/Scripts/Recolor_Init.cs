using UnityEngine;
using System.Collections;

public class Recolor_Init : MonoBehaviour {
	
	[SerializeField]
	Color myColor;

	// Use this for initialization
	void Start()
	{
		Renderer renderer = this.gameObject.GetComponent<Renderer>();

		if (null != renderer)
		{
			renderer.material.color = this.myColor;
		}

		Destroy(this);
	}

}
