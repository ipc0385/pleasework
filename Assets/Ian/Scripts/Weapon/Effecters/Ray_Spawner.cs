using UnityEngine;
using System.Collections;

public class Ray_Spawner : Effecter
{
	[SerializeField]
	float myRange;

	[SerializeField]
	float myOffset;

	[SerializeField]
	GameObject mySpawn;

	public override void Affect(params object[] argv)
	{
		RaycastHit hit;

		Ray ray = new Ray(this.transform.forward * this.myOffset + this.transform.position, this.transform.forward);

		if (Physics.Raycast(ray, out hit, this.myRange, Bitwise.Off(1, 8)))
		{
			Instantiate(this.mySpawn, hit.point, this.transform.rotation);
		}
		else
		{
			Instantiate(this.mySpawn, ray.origin + ray.direction * this.myRange, this.transform.rotation);
		}
	}
}
