using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad4_lab6 : MonoBehaviour
{ private Vector3 playerVelocity;
    private float jumpHeight = 3f;
    private float gravityValue = -9.81f;
    private GameObject player;
    private CharacterController controller;
    private bool groundedPlayer;
    private int changeState;
    void Start()
    {
        changeState = 0;
        Debug.Log(playerVelocity.y);
    }

    void Update()
    {
      
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y > 9)
        {
            changeState = 0;
            playerVelocity.y = 0f;
        }

        if (changeState == 1)
        {
            if (groundedPlayer)
            {
               playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeState = 1;
        }
    }
}