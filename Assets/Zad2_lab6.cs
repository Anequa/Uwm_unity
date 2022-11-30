using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad2_lab6 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 2f;
    private bool opensDoor = true;
    private bool closingDoor = false;
    private float downPosition;
    private float upPosition;
    private bool closeDoor = false;

    void Start()
    {
        upPosition = transform.position.z + distance;
        downPosition = transform.position.z;
    }

    void Update()
    {
        if (opensDoor && transform.position.z >= upPosition)
        {
            
            if (closeDoor)
            {
                elevatorSpeed = -elevatorSpeed;
                closingDoor = true;
                opensDoor = false;
                isRunning = true;
            }
            else 
            {
                isRunning = false;
            }
            
        }
        else if (closingDoor && transform.position.z <= downPosition)
        {
            closeDoor = false;
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z >= upPosition)
            {
                closingDoor = true;
                opensDoor = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= downPosition)
            {
                opensDoor = true;
                closingDoor = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            closeDoor = true;
    }
}