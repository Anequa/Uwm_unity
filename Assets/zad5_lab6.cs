using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5_lab6 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kolizja"))
        {
            Debug.Log("wjechałeś na przeszkode");
        }
    }
}
