using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Messenger : MonoBehaviour
{
	[SerializeField]
	string myName;

	[SerializeField]
	bool myLog = false;
	
	public delegate void Subscription(params object[] argv);

	HashSet<Subscription> mySubscriptions = new HashSet<Subscription>();

	//returns input for ian's janky coding
	//unsubscribe with subscription
	public Subscription Subscribe(Subscription input)
	{
		this.mySubscriptions.Add(input);

		return input;
	}

	public void Unsubscribe(Subscription input)
	{
		this.mySubscriptions.Remove(input);
	}

	public void Publish(params object[] argv)
	{
		if(myLog && null != this.myName)
		{
			Debug.Log(this.myName + " published: " + argv);
		}

		foreach(var sub in this.mySubscriptions)
		{
			sub(argv);
		}
	}

}
