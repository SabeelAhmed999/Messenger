using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabGrid : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int gridX,gridZ;
    public float gridSpacingOffset=1;
    public Vector3 gridOrigin =Vector3.zero;
    public Vector3 positionRandomization;



    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for(int x=0; x<gridX;x++)
        {
            for(int z=0;z<gridZ;z++)
            {
                Vector3 spawnPosition=new Vector3(x*gridSpacingOffset,0,z*gridSpacingOffset*gridSpacingOffset)+gridOrigin;
                PickAndSpawn(RandomizedPosition(spawnPosition),Quaternion.identity);
            }
        }
    }

    Vector3 RandomizedPosition(Vector3 position)
    {
        Vector3 randomizedPosition= new Vector3(Random.Range(-positionRandomization.x,positionRandomization.x),
        Random.Range(-positionRandomization.y,positionRandomization.y),Random.Range(10,positionRandomization.z))+position;
        return randomizedPosition;
    }
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex=Random.Range(0,objectsToSpawn.Length);
        GameObject clone= Instantiate(objectsToSpawn[randomIndex],positionToSpawn,rotationToSpawn);
    }

}
