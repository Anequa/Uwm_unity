using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad1 : MonoBehaviour
{

    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int number=10;
    // obiekt do generowania
     public UnityEngine.Object[]materials;
    public GameObject block;
     Vector3 pozycja;
     Vector3 rozmiar;
     

    void Start()
    {
       
        pozycja= gameObject.transform.position;
        rozmiar=gameObject.GetComponent<Renderer>().bounds.size;
      
        
        materials = Resources.LoadAll("Kolory", typeof(Material)); 
        Debug.Log(materials.Length);

       

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)(pozycja.x-(rozmiar.x)/2)+1, number).OrderBy(x => Guid.NewGuid()));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)(pozycja.z-(rozmiar.z)/2)+1, number).OrderBy(x => Guid.NewGuid()));
       
        
        for(int i=0; i<number; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
           
        }
        foreach(Vector3 elem in positions){
            //renderer bounds
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Material material = (Material)materials[UnityEngine.Random.Range(0, materials.Length)];
            this.block.GetComponent<Renderer>().material = material;
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}