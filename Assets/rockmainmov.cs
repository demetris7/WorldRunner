using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockmainmov : MonoBehaviour
{
    void Start()
    {
        Vector3 ori = new Vector3(Random.Range(-90, 30), -90, -90);
        if (transform.position.x > 0)
        {
            ori.x += 180;
        }
        transform.Rotate(ori);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), MainScript.m_speed * Time.deltaTime);
        if (transform.position.y <= -0.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
