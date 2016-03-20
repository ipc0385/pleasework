using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathnoder : MonoBehaviour {

	public static HashSet<Pathnoder> allNodes = new HashSet<Pathnoder>();

	Dictionary<Pathnoder, float> myEdges = new Dictionary<Pathnoder,float>();

	//Collider myCollider;

	bool isMoving;
	Vector3 lastPosition;

	void Update_Edges()
	{
		Vector3 position = this.transform.position;

		foreach(var node in allNodes)
		{
			if(this != node)
			{
				if(Physics.Linecast(position, node.transform.position, 1))
				{
					//blocked, kill edges
					myEdges.Remove(node);
					node.myEdges.Remove(this);
				}
				else
				{
					//free, build edge
					myEdges[node] = 1.0f;
					node.myEdges[this] = 1.0f;
				}
			}
		}
	}

	void Awake()
	{
		allNodes.Add(this);
		this.Update_Edges();

		//this.myCollider = this.GetComponent<Collider>();
	}

	void OnTriggerEnter(Collider collider)
	{
		Pathfinder finder = collider.GetComponent<Pathfinder>();
		if(null != finder)
		{
			finder.Triggered_Node(this);
		}
	}

	// Use this for initialization
	void Start ()
	{
		this.Update_Edges();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 position = this.transform.position;
		if(lastPosition != position)
		{
			this.Update_Edges();
			lastPosition = position;
		}
	}

	float Cost(Pathnoder node)
	{
		float distance = (node.transform.position - this.transform.position).magnitude;

		if(this.myEdges.ContainsKey(node))
		{
			return this.myEdges[node] * distance;
		}
 		else
		{
			return distance;
		}
	}

	public static Queue<Pathnoder> Pathfind(Pathnoder goal, Pathnoder start)
	{
		Associative_Heap<float, Pathnoder> heap = new Associative_Heap<float,Pathnoder>(1);

		Dictionary<Pathnoder, KeyValuePair<Pathnoder, float>> map = new Dictionary<Pathnoder, KeyValuePair<Pathnoder, float>>();

		map[start] = new KeyValuePair<Pathnoder, float>(null, 0f);

		heap.Add(new KeyValuePair<float, Pathnoder>(0f, start));

		while (!heap.IsEmpty)
		{
			Pathnoder current = heap.Peak.Value;

			heap.Pop();

			if(goal == current)
			{
				Queue<Pathnoder> path = new Queue<Pathnoder>();
				path.Enqueue(goal);
				Pathnoder node = map[goal].Key;
				for (; node != null; )
				{
					path.Enqueue(node);

					node = map[node].Key;
				}

				return path;
			}

			float cost = map[current].Value;

			foreach(Pathnoder next in current.myEdges.Keys)
			{
				float new_cost = cost + current.Cost(next);

				//if next not in cost_so_far or new_cost < cost_so_far[next]:
				if(!map.ContainsKey(next) || new_cost < map[next].Value)
				{
					//	 cost_so_far[next] = new_cost
					//	 came_from[next] = current
					map[next] = new KeyValuePair<Pathnoder, float>(current, new_cost);

					//	 priority = new_cost + heuristic(goal, next)
					float priority = new_cost + goal.Cost(next);

					//	 frontier.put(next, priority)
					heap.Add(new KeyValuePair<float, Pathnoder>(priority, next));
				}
			}
		}

		return null;
	}
}
