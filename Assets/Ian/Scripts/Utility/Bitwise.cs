using UnityEngine;
using System.Collections;

public class Bitwise 
{
	public static bool isOff(int bits, int index)
	{
		return 0 == (bits & (1 << index));
	}

	public static bool isOn(int bits, int index)
	{
		return !Bitwise.isOff(bits, index);
	}

	public static int On(params int[] indices)
	{
		int bits = 0;

		foreach(int index in indices)
		{
			bits |= (1 << index);
		} 

		return bits;
	}

	public static int Off(params int[] indices)
	{
		return ~Bitwise.On(indices);
	}
}
