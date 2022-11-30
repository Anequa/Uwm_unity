using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float rightPosition;
    private float leftPosition;
     private Transform oldParent;

    void Start()
    {
        rightPosition = transform.position.x + distance;
        leftPosition = transform.position.x;
    }

    void Update()
    {
        if (isRunningUp && transform.position.x >= rightPosition)
        {
            isRunningDown = true;
            isRunningUp = false;
            elevatorSpeed = -elevatorSpeed;
            isRunning=true;
        }
           else if (isRunningDown && transform.position.x <= leftPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
           
            if (transform.position.x >= rightPosition)
            {
                isRunningDown = true;
                isRunningUp = false;
                elevatorSpeed = -elevatorSpeed;
                isRunning=true;
            }
            else if (transform.position.x <= leftPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
            
        }
    }
}