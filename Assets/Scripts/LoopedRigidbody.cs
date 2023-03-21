using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LoopedRigidbody : MonoBehaviour
{
    //world x-coordinate on the left side of the screen where the position should wrap around to and from the other side
    [SerializeField]
    private float leftWrapAroundBound;

    //same as leftBound, just for the right side
    [SerializeField]
    private float rightWrapAroundBound;

    private void FixedUpdate()
    {
        float loopedAreaWidth = rightWrapAroundBound - leftWrapAroundBound;

        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
        //get current position of the rigidbody
        Vector2 currentPosition = rigidBody2D.position;

        //move rigidbody into screen from the left bound if it is left of the left wrap around bound
        if(currentPosition.x < leftWrapAroundBound)
        {
            //add whole looped areaWidth so it reappears on the right side
            currentPosition.x += loopedAreaWidth;
        }

        //same as for left bound, just mirrored for the right bound
        if(currentPosition.x > rightWrapAroundBound)
        {
            currentPosition.x -= loopedAreaWidth;
        }

        //write back modified position
        rigidBody2D.position = currentPosition;
    }
}
