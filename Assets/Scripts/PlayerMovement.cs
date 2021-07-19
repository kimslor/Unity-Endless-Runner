using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    private Vector2 initialPosition;
    private int currentLane; //0-left, 1-center, 2-right

    public GameObject leftTarget;
    public GameObject rightTarget;
    public GameObject centerTarget;
    private Transform leftTargetPosition;
    private Transform rightTargetPosition;
    private Transform centerTargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set player position to center on start
        currentLane = 1;

        //Initialise the left and right positions for movement
        leftTargetPosition = leftTarget.transform;
        rightTargetPosition = rightTarget.transform;
        centerTargetPosition = centerTarget.transform;
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
            }
            
            else if (touch.phase == TouchPhase.Ended)
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
        //movementSpeed = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, leftTargetPosition.position, movementSpeed);
        if (currentLane == 2)
        {
            transform.position = centerTargetPosition.position;
            currentLane = 1;
        }
        else
        {
            transform.position = leftTargetPosition.position;
            currentLane = 0;
        }
    }

    void MoveRight()
    {
        //movementSpeed = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, rightTargetPosition.position, movementSpeed);
        if (currentLane == 0)
        {
            transform.position = centerTargetPosition.position;
            currentLane = 1;
        }
        else
        {
            transform.position = rightTargetPosition.position;
            currentLane = 2;
        }
    }
}
