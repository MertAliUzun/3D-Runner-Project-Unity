using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrapSideways : MonoBehaviour
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
        MoveTrapSide();
        transform.position = moveVector;
    }

    void MoveTrapSide()   // Moves Traps Horizontally
    {
        if (!goBack)
        {
            moveVector.x += Time.deltaTime;
        }
        if (goBack)
        {
            moveVector.x -= Time.deltaTime;
        }
    }
    void checkGoBack()  // Checks which side to go
    {
        if (transform.position.x <= -1)
        {
            goBack = false;
        }
        if (transform.position.x >= 1)
        {
            goBack = true;
        }
    }
}
