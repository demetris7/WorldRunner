using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    void Start(){

        transform.Rotate(180, 0, 90);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), MainScript.m_speed * Time.deltaTime);
        if (transform.position.y <= -0.2f)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            MainScript.gameOver();
        }
    }
}
