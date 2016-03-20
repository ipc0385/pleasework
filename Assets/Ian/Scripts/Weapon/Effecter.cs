using UnityEngine;
using System.Collections;

public abstract class Effecter : MonoBehaviour 
{
	public abstract void Affect(params object[] argv);
}
