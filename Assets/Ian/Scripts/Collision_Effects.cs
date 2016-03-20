using UnityEngine;
using System.Collections;

public class Collision_Effects : MonoBehaviour 
{
	[SerializeField]
	bool destroy_script_on_hit = false;
	//Collision will be param 1

	[SerializeField]
	Effecter mOnEnterEffect;

	void OnCollisionEnter(Collision collision) 
	{
		if (this.mOnEnterEffect)
		{
			this.mOnEnterEffect.Affect(collision, collision.gameObject);
		}

		if (destroy_script_on_hit)
		{
			Destroy(this);
		}
	}

	[SerializeField]
	Effecter mOnStayffect;
	
	void OnCollisionStay(Collision collision)
	{
		if (this.mOnStayffect)
		{
			this.mOnStayffect.Affect(collision);
		}
	}

	[SerializeField]
	Effecter mOnExitEffect;

	void OnCollisionExit(Collision collision)
	{
		if (this.mOnExitEffect)
		{
			this.mOnExitEffect.Affect(collision);
		} 
	}

}
