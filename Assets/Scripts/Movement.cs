using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CameraController camController;
    private CharacterController controller;
    private Animator anim;
    private Vector3 direction;
    private Vector3 movementVector;
    public float movementSpeed = 1f;
    public float jumpPower = .001f;
    public float gravity = -1f;
    public int scoreValue =10;
    public bool isGameOver;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        camController = GetComponent<CameraController>();

    }

    void Update()
    {
        HandleAnimations();
        //Debug.Log(ReplayButtonScript.victory);
        Debug.Log("movevec: " + movementVector.x);
        Debug.Log("direction: " + direction.x);
        Debug.Log("pos: " + transform.position.x);
    }
    void FixedUpdate()
    {
        HandleGravity();  //Sets Gravity
        moveVec();
        if (Input.GetMouseButton(0) && !ReplayButtonScript.gameOverScreenActive) // If button is pressed can control character
        {
            controller.Move(movementVector * Time.fixedDeltaTime / 3);
            anim.SetBool("isRunning", true);
            Flip();
            Move();
            direction.z = movementSpeed;
        }
        else                        // If button is not pressed reset velocity in x,z axis
        {
            controller.Move(Vector3.zero);
            direction.z = 0;
            direction.x = 0;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isRunning", false);
        }

    }
    void moveVec()
    {
        if (transform.position.x > 0f && direction.x > 0f)
        {
            if (direction.x < transform.position.x)
            {
                direction.x = direction.x - transform.position.x;

            }
            if (direction.x == transform.position.x)
            {
                direction.x = 0f;
            }
        }
        if (transform.position.x < 0f && direction.x < 0f)
        {
            if (direction.x > transform.position.x)
            {
                direction.x = direction.x - transform.position.x;

            }
            if (direction.x == transform.position.x)
            {
                direction.x = 0f;
            }
        }
        else if ((transform.position.x < 0f && direction.x > 0f) || (transform.position.x > 0f && direction.x < 0f))
        {
            if (direction.x > 0f)
            {
                direction.x = Mathf.Abs(direction.x) + Mathf.Abs(transform.position.x);
            }
            if (direction.x < 0f)
            {
                direction.x = -1f * (Mathf.Abs(direction.x) + Mathf.Abs(transform.position.x));
            }

        }


        movementVector = direction;
        movementVector.x *= 4f;
    } //Makes the movement in complience with character instead of camera
    void HandleAnimations()
    {
        if (ReplayButtonScript.isGameOver)
        {
            anim.SetBool("gameOverScreenDefeated",!ReplayButtonScript.victory); // Play Defeated Animation
            anim.SetBool("gameOverScreenVictory", ReplayButtonScript.victory);  // Play Victory Animation
        }
    }
    void Move()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        mousePosition.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 hitvec = hit.point;                                        //Gets Mouse Position
            hitvec.y = transform.position.y;
            hitvec.z = transform.position.z;   
            direction = Vector3.Lerp(transform.position, hitvec , 2f);  //Handles Left and Right Movement
            anim.SetBool("isRunning", true);
        }
    }
    void Flip()   // Face Running Direction
    {
        if(!(transform.position.x > 0 && direction.x > 0))
        {
            if (transform.position.x < direction.x - .5f)
            {
                transform.rotation = Quaternion.Euler(0, direction.x * 40f, 0);
            }
            else if (transform.position.x > direction.x + .5f)
            {
                transform.rotation = Quaternion.Euler(0, direction.x * 40f, 0);
            }
            else if (transform.position.x > direction.x - .2f || transform.position.x < direction.x + .2f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if(transform.position.x > 0.4f || transform.position.x < -0.8f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        

       
    }
    void HandleGravity()
    {
        if (!controller.isGrounded)
        {
            direction.y = gravity;
        }
        if (controller.isGrounded)
        {
            direction.y = 0;
        }
    }
    private void OnTriggerEnter(Collider other)      // Detect Collision
    {

        if (other.gameObject.CompareTag("GoodFood")) // Increase Points
        {
            ScoreManager.scoreManager.ChangeScore(scoreValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BadFood"))  // Decrease Points
        {
            ScoreManager.scoreManager.ChangeScore(-scoreValue);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Traps"))    // Gameover
        {
            ReplayButtonScript.hitTrap = true;
            ReplayButtonScript.isGameOver = true;
        }
        if (other.gameObject.CompareTag("Ending"))    // Gameover
        {
            ReplayButtonScript.hitTrap = false;
            if(ScoreManager.score >= 70)
            {
                ReplayButtonScript.victory = true;
            }
            else
            {
                ReplayButtonScript.victory = false;
            }
            ReplayButtonScript.isGameOver = true;
        }

    }

}
