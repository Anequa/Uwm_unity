using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
     public GameObject myPrefab;
     public Vector3[] positionsList;
    List<Vector3> positions = new List<Vector3>();
     public int numberOfObjects = 10;
     

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i=0;i<numberOfObjects;i++)
        {
            
            var position = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
            
            
        if (!positions.Contains(position))
        {
            Instantiate(myPrefab, position, Quaternion.identity);
            positions.Add(position);

            
        }else
        {
            numberOfObjects+=1;
        }
           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
