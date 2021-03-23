using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersController : MonoBehaviour
{
    bool ValueChange = true;
    public GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (ValueChange)
        {
            gameManager.triggerNo += 1;
            ValueChange = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        gameManager.CubeTriggers[gameManager.triggerNo].transform.GetChild(0).gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        ValueChange = true;
        gameManager.CubeTriggers[gameManager.triggerNo-2].SetActive(false);
    }
    private void Update()
    {

    }
}
