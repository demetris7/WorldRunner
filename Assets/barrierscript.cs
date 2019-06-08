using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierscript : MonoBehaviour
{
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), MainScript.m_speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           //Destroy(this.gameObject);
            MainScript.gameOver();
        }
    }
}
