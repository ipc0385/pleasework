using UnityEngine;
using System.Collections;

public class Lock_On : Activator
{
	
	[SerializeField]
	float myRange;

	[SerializeField]
	Effecter myEffecter;

	Collider myTarget;

	bool isActive;

	public override void Activate(params object[] input)
	{
		this.isActive = true;
	}

	public override void Deactivate(params object[] input)
	{
		this.isActive = false;

		if(base.isReady)
		{
			base.Act();

			this.myEffecter.Affect(this.myTarget);
		}
	}

	//beaver beer
	//cunt cocktails
	//g-spot spirits
	//womb wiskey
	//vaginal vodka
	//crotch scotch
	//slit sake
	
	//cervix cider
	//fanny fruitwine
	//hymen 
	//labia lager
	 
	//ovarian absinthe
	//placenta 
	//snatch 
	//uterus tequila

	void Update()
	{
		if (this.isActive && base.isReady)
		{
			Ray ray = new Ray(this.transform.position, this.transform.forward);

			RaycastHit hit;

			//raycast first
			if (Physics.Raycast(ray, out hit, this.myRange, Bitwise.Off(1, 8)))
			{
				this.myTarget = hit.collider;
			}
			else
			{
				this.myTarget = null;

				float closest = float.MaxValue;
				
				foreach(var collider in UnityEngine.Object.FindObjectsOfType<Collider>())
				{
					if(Logic<int>.Neither(collider.gameObject.layer, 1, 8))
					{
						float distance = Linear_Algebra.Distance_To_Collider(ray, collider, closest);

						if (distance < closest)
						{
							closest = distance;
							this.myTarget = collider;
						}
					}
				}
			}
		}
	}

}
