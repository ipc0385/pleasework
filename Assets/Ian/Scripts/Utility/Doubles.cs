using UnityEngine;
using System.Collections;

public class Doubles 
{
	public static double Max(params double[] argv)
	{
		double max = argv[0];

		for (int i = 1, n = argv.Length; i < n; ++i)
		{
			double temp = argv[i];

			if (temp > max)
			{
				max = temp;
			}
		}

		return max;
	}

	public static double Abs(double input)
	{
		return input < 0d ? -input : input;
	}

	public static double Min(params double[] argv)
	{
		double min = argv[0];

		for (int i = 1, n = argv.Length; i < n; ++i)
		{
			double temp = argv[i];

			if (temp < min)
			{
				min = temp;
			}
		}

		return min;
	}

	public static double Delta(ref double from, double to)
	{
		double delta = to - from;

		from = to;

		return delta;
	}
}
