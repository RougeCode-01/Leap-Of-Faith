using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : MonoBehaviour
{
    //use the new input system to move the int the air have it roll left and right and dive and stop diving
    
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _rollSpeed = 5.0f;
    [SerializeField] private float _diveSpeed = 5.0f;
    
    //Roll function
    public void Roll()
    {
        //Get the input from the new input system
        //Roll the player left and right
    }
    
    //Dive function
    public void Dive()
    {
        //Get the input from the new input system
        //Dive the player
    }
}
