using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Vector3 SizeOfGrid;
    public Vector3 originToStart;
    public int totalObjects;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<totalObjects;i++)
        {
            for(int j=0;j<i;j++)
            {
                Instantiate(prefab,originToStart,Quaternion.identity);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
