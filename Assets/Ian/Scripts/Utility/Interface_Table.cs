using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interface_Table<type>
{
	static Dictionary<GameObject, type> table = new Dictionary<GameObject,type>();

	public static void Register(GameObject gameObject, type input)
	{
		table[gameObject] = input;
	}

	public static void Deregister(GameObject input)
	{
		table.Remove(input);
	}

	public static type Find(GameObject input)
	{
		if (table.ContainsKey(input))
			return table[input];
		else return default(type);
	}
}
