using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private float movementSpeed;

    private Vector2 initialPosition;


    public GameObject leftTarget;
    public GameObject rightTarget;
    private Transform leftTargetPosition;
    private Transform rightTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise the left and right positions for movement
        leftTargetPosition = leftTarget.transform;
        rightTargetPosition = rightTarget.transform;
        Debug.Log("current position: " + transform.position);
        Debug.Log("left position: " + leftTargetPosition.position);
        Debug.Log("right position: " + rightTargetPosition.position);

        leftTargetPosition.position = transform.position - new Vector3(1.3f, 0, 0);
        rightTargetPosition.position = transform.position + new Vector3(1.3f, 0, 0);

        Debug.Log("current position: " + transform.position);
        Debug.Log("left position: " + leftTargetPosition.position);
        Debug.Log("right position: " + rightTargetPosition.position);

        //initial the movementSpeed
        movementSpeed = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            //get and store the initial position of the touch
            if (touch.phase ==  TouchPhase.Began)
            {
                initialPosition = touch.position;
                Debug.Log("touched screen");
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log("swiped screen");
                //get the direction of the touch swipe
                var direction = touch.position - initialPosition;

                //get the signed x direction, if (direction.x >= 0) then 1 else -1
                var signedDirection = Mathf.Sign(direction.x);

                //left swipe, update movement
                if (signedDirection == -1)
                {
                    MoveLeft();
                }

                //right swipe, update movement
                if (signedDirection == 1)
                {
                    MoveRight();
                }
            }
        }
    }

    void MoveLeft()
    {
        movementSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, leftTargetPosition.position, movementSpeed);
        Debug.Log("swiped screen left");
    }

    void MoveRight()
    {
        movementSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, rightTargetPosition.position, movementSpeed);
        Debug.Log("swiped screen right");
    }
}
