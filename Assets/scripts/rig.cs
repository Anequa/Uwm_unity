using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rig : MonoBehaviour
{
 
     public Transform target;
     public float yTarget = 5;
     public float smoothTime = 1f;
     private float yVelocity = 0.5F;
       public float minimum = -1.0F;
    public float maximum =  1.0F;

    // starting value for the Lerp
    static float t = 0.0f;
 
 
     void Update()
     {
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 2.5f, 0);
         t += 0.5f * Time.deltaTime;
           if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
        //  float newPosition = Mathf.SmoothDamp(transform.position.y, yTarget, ref yVelocity, smoothTime);
        //  transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
     }
 }