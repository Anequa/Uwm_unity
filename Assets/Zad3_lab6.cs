
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zad3_lab6 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    public List<Vector3> points = new List<Vector3>() ;
    public Vector3 startPosition;
    Vector3 target=new Vector3();
    private bool isRunning = false;
    public int count=0;
    private int tmp = 1;

   

    void Start()
    {
        startPosition = transform.position;
        points.Clear();
        points.Add(startPosition);
        Debug.Log(startPosition);
        Vector3 where1=new Vector3(0f,0f,20f);
        points.Add(where1);
        Vector3 where2=new Vector3(-20f,0f,20f);
        points.Add(where2);
        Vector3 where3=new Vector3(-20f,0f,0f);
        points.Add(where3);
        Vector3 where4=new Vector3(-8f,0f,0f);
        points.Add(where4);
        target=points[count];
    }

    void Update()
    {
        
        
        if (Equals(transform.position, target))
        {
          
            count+=tmp;
              if(count==(-1)){
                isRunning=false;
                Debug.Log("siema jestem w if -1");
                count+=1;
                target=points[count];
                tmp=1;
            } else{
                 target=points[count];
            }
           
        }
        
        
       if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, target,Time.deltaTime * elevatorSpeed);
        
        }
        if (count+2>points.Count){
                tmp = -1;
             
        }
       
    }

      private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
        }
    }
      
            
            
}