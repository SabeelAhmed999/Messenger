using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {

        }
    }

    void OnCollider()
    {
        this.gameObject.GetComponent<Collider>().isTrigger=false;
    }
    void OffCollider()
    {
        this.gameObject.GetComponent<Collider>().isTrigger=true;
    }
}
