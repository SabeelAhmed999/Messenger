using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{

    public Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = target.position.y;
        transform.LookAt(targetPosition);
    }
}
