using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2f;

    private bool hasArrived = false;

    public Dialogue typewriter;

    void Update()
    {
        if (!hasArrived && Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (!hasArrived)
        {
            hasArrived = true;
            typewriter.StartTypewriter();
        }
    }
}
