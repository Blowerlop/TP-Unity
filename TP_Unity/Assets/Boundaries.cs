using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;
    
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }


    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            BoxCollider colliderIns = gameObject.AddComponent<BoxCollider>();
            colliderIns.size = _boxCollider.size;
            colliderIns.center = _boxCollider.center;
            colliderIns.center = new Vector3(colliderIns.center.x + 2 * colliderIns.size.x % 4, colliderIns.center.y, colliderIns.center.z);

        }
    }
}
