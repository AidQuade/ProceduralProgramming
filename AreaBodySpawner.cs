using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBodySpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public float xSpread = 10;
    public float ySpread = 0;
    public float zSpread = 10;
    public int num;

  
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            SpreadItems();
        }
       
    }
//Simple random item spreader
    void SpreadItems()
    {
        Vector3 randPos = new Vector3(Random.Range(-xSpread,xSpread), Random.Range(-ySpread,ySpread), Random.Range(-zSpread,zSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, randPos, Random.rotation);
    }
    
}
