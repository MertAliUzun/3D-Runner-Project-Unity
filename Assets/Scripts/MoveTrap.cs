using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{

    Vector3 moveVector = new Vector3();
    public bool goBack;

    void Start()
    {
        goBack = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = transform.position;
        checkGoBack();
        moveTrap();
        transform.position = moveVector;

    }
    void checkGoBack()                    // Checks which side to go
    {
        if (transform.position.z <= -40)
        {
            goBack = false;
        }
        if (transform.position.z >= -35)
        {
            goBack = true;
        }
    }
    void moveTrap()                      // Moves Traps Vertically
    {
        if (!goBack)
        {
            moveVector.z += Time.deltaTime;
        }
        if (goBack)
        {
            moveVector.z -= Time.deltaTime;
        }
    }
}
