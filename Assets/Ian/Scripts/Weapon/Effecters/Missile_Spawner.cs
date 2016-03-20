using UnityEngine;
using System.Collections;

public class Missile_Spawner : Effecter
{
	[SerializeField]
	float myOffset;

	[SerializeField]
	GameObject mySpawn;

	Collider myCollider;

	void Start()
	{
		this.myCollider = this.GetComponent<Collider>();
	}


	public override void Affect(params object[] argv)
	{
		if(null == argv[0])
		{
			return;
		}

		if(argv[0].GetType().BaseType == typeof(Collider))
		{
			Collider collider = argv[0] as Collider;
			
			GameObject gameObject = Instantiate(this.mySpawn, this.transform.forward * myOffset + this.transform.position, this.transform.rotation) as GameObject;

			Target target = gameObject.AddComponent<Target>();

			target.target = collider.gameObject;

			Collider missile_collider = gameObject.GetComponent<Collider>();

			if (this.myCollider && missile_collider)
			{
				Physics.IgnoreCollision(this.myCollider, missile_collider);
			}
		}
	}
	
}
