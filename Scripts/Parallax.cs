using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float paralaxSpeed;
    public Transform target;

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = target.position;
    }

    void Update()
    {
        transform.Translate((target.position.x - previousPosition.x) / paralaxSpeed, (target.position.y - previousPosition.y) / paralaxSpeed, 0);
        previousPosition = target.position;
    }
}
