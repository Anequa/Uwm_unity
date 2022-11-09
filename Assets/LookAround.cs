using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookAround : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
        public Transform player;

    public float sensitivity = 200f;
    float mouseXMove = 0f;
    float mouseYMove = 0f;

    void Start()
    {
    
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        mouseXMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseYMove = Math.Clamp(mouseYMove, -90f, 90f);
        transform.eulerAngles = new Vector3(mouseYMove, 0, 0);
}}