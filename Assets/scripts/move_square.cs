using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_square : MonoBehaviour
{
     public float speed = 1;
   public float sum=0;
   public int i=0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //zmiana na 9.5 bo jesli plansza ma 10 jednostek i ma przebyc 10 to nie ma miejsca i spada 
          if(sum>=9.5)
          {
            transform.Rotate(new Vector3(0, -90, 0), Space.World);
            sum=0;
        

         }
        if(sum<=9.5)
        {
          transform.Translate(Vector3.right * speed * Time.deltaTime);
          sum=sum+speed*Time.deltaTime;
         
        }
       

    }
    }

