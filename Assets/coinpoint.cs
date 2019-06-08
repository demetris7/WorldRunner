using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpoint : MonoBehaviour
{
    public int point = 1;
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, new Vector3(1, 0, 0), MainScript.m_speed * Time.deltaTime);
        if (transform.position.y <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainScript.score += point;
            MainScript.m_speed -= point / 100;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
