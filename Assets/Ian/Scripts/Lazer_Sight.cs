using UnityEngine;
using System.Collections;

public class Lazer_Sight : MonoBehaviour {

	[SerializeField]
	float offset, range = 0f;

	[SerializeField]
	int mask;

	void Update () {

		RaycastHit hit = new RaycastHit();

		Vector3 direction = this.transform.forward;

		Vector3 position = this.transform.parent.position + direction * this.offset;

		float z = offset + range * 0.5f;

		float d = range;

		if (Physics.Raycast(new Ray(position, direction), out hit, this.range))
		{
			z = hit.distance * 0.5f + offset;

			d = hit.distance;
		}

		if(this.transform.localPosition.z != z)
		{
			this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, z);
		}

		if(this.transform.localScale.z != d)
		{
			this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, d);
		}

	}
}
