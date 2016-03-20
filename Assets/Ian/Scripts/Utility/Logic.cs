using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Logic<Type>
{
	public static bool Either(Type input, params Type[] argv)
	{
		foreach (var temp in argv)
		{
			if (EqualityComparer<Type>.Default.Equals(input, temp))
			{
				return true;
			}
		}

		return false;
	}
	public static bool Neither(Type input, params Type[] argv)
	{
		foreach (var temp in argv)
		{
			if (EqualityComparer<Type>.Default.Equals(input, temp))
			{
				return false;
			}
		}

		return true;
	}
}
