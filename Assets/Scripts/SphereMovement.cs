using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    
   
    void Start()
    {}

    void Update()
    {
        transform.Rotate(Vector3.forward * MainScript.m_speed * Time.deltaTime);
    }
}
