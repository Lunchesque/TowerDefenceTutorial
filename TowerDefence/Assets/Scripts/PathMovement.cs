using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] private Path path;
    [SerializeField] private float speed = 1.0f;
    
    private int nextPointIndex = 1;
    private float currentTime = 0.0f;

    private void Update()
    {
        if (nextPointIndex >= path.GetPointCount())
            return;
        
        Vector3 currentPoint = path[nextPointIndex - 1];
        Vector3 nextPoint = path[nextPointIndex];

        float distance = Vector3.Distance(currentPoint, nextPoint);
        currentTime += Time.deltaTime;

        transform.position = Vector3.Lerp(currentPoint, nextPoint, speed / distance * currentTime);

        if (speed * currentTime >= distance)
        {
            nextPointIndex++;
            currentTime = 0.0f;

            //if (nextPointIndex < path.GetPointCount())
            //{
            //    Quaternion delta = Quaternion.FromToRotation(transform.forward, nextPoint - currentPoint);
            //    transform.rotation *= delta;
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
