using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
   
   public float speed = 1;
   public float sum=0;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
         
    }
       void Update()
    {
          if(sum>=10)
        {
          if(sum>=20)
          {
            sum=0;
          }
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            sum=sum+speed*Time.deltaTime;

         }
        if(sum<=10)
        {
          transform.Translate(Vector3.right * speed * Time.deltaTime);
          sum=sum+speed*Time.deltaTime;
         
        }
        Debug.Log(sum);

    }
  
}
