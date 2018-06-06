using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour 
{	
	[SerializeField]private float speed;
	private Transform[] points;
	private int nextPointIndex = 2;
	private float currentTime = 0.0f;


	private void Awake()
	{
		GameObject path =  GameObject.Find("Path");
		points = path.GetComponentsInChildren<Transform>();
	}

	private void Update()
	{
		if (nextPointIndex >= points.Length)
			return;

		currentTime += Time.deltaTime;
		float distance = Vector3.Distance(points[nextPointIndex - 1].position, points[nextPointIndex].position);
		transform.position = Vector3.Lerp(points[nextPointIndex - 1].position, points[nextPointIndex].position,  speed/distance * currentTime);

		if (speed * currentTime >= distance)
		{
			nextPointIndex++;
			currentTime = 0.0f;
			if (nextPointIndex < points.Length)
			{
				Quaternion delta = Quaternion.FromToRotation(transform.forward, points[nextPointIndex].position - points[nextPointIndex - 1].position);
				transform.rotation *= delta;	
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Base")
		{
			Destroy(gameObject);
		}
	}
}
