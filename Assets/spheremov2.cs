using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spheremov2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { }

    void Update()
    {
        transform.Rotate(Vector3.left * MainScript.m_speed * Time.deltaTime);
    }

}
