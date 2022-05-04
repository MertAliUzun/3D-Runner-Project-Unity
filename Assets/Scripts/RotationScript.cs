using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationRateY = 0;
    public float rotationRatex = 0;

    void Update() // Rotates Objects
    {
        if(transform.gameObject.tag == "Traps") { rotationRatex = -90f; }
        if(rotationRateY >= 360)
        {
            rotationRateY = 0;
        }
        rotationRateY += Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationRatex,rotationRateY * 40,0);
    }
}
