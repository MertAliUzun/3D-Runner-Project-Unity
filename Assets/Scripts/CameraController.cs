using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    public Vector3 targetVector;

    private void FixedUpdate()
    {
        targetVector = new Vector3(transform.position.x, target.position.y, target.position.z);   // So Camera Does not follow on x axis
        transform.position = Vector3.Lerp(transform.position, targetVector + distance, Time.fixedDeltaTime * 10); //Makes Camera movement smoother
    }
}
