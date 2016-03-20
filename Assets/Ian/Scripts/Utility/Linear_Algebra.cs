using UnityEngine;
using System.Collections;

public class Linear_Algebra {

	public static float Distance_To_Line(Ray ray, Vector3 point)
	{
		return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
	}

	public static float Distance_To_Line_Along_Ray(Ray ray, Vector3 point)
	{
		float h = Vector3.Distance(ray.origin, point);
		float d = Distance_To_Line(ray, point);

		return Mathf.Sqrt(h * h + d * d);
	}

	public static float Distance_To_Collider(Ray ray, Collider collider, float distance)
	{
		Vector3 target = collider.transform.position;

		float distance_to_line = Linear_Algebra.Distance_To_Line(ray, target);

		if (distance_to_line < 0.0f)
		{
			return float.MaxValue;
		}

		float hypotneuse = Vector3.Distance(ray.origin, target);

		Vector3 closest = ray.origin + ray.direction * Mathf.Sqrt(hypotneuse * hypotneuse + distance_to_line * distance_to_line);

		RaycastHit hit;

		Vector3 direction = (target - closest).normalized;

		direction.Normalize();

		if (!direction.Equals(Vector3.zero) && collider.Raycast(new Ray(closest, direction), out hit, distance_to_line))
		{
			return hit.distance;
		}

		return float.MaxValue;
	}

}
