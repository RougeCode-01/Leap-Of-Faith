using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    //use the new inut system to move the player in all 4 directions and jump
    
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    
    //Movement function
    public void Move()
    {
        //Get the input from the new input system
        //Move the player in all 4 directions
    }
    
    //Jump function
    public void Jump()
    {
        //Get the input from the new input system
        //Jump the player
    }
}
