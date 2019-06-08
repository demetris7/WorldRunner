using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private Vector3 position;
    private bool left,right;
    private int step, jump;
    private float vJump = 0.004f, vMove = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        step = 0; // 0 : center, -1 : left, 1 : right
        jump = 0;
        left = false;
        right = false;
        transform.position = new Vector3(0, 0.45f, -0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        //Get position cube
        position = transform.position;

        //Movement jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && position.y<=0.46f)
        {
            jump = 1;
        }
        if (jump != 0)
        {
            if(jump == 1)
            {
                position.y += vJump;
                if (position.y > 0.55f)
                    jump = 2;
            }
            else
            {
                position.y -= vJump;
                if (position.y < 0.45f)
                    jump = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow) && position.x>-0.05f && !right)
        {
            left = true;
            step--;
        }
        if (left)
        {
            position.x -= vMove;
            if(step == 0) {
                if (position.x <= 0)
                    left = false;
            }
            else if (position.x < -0.05f)
                    left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && position.x<0.05f && !left)
        {
            right = true;
            step++;
        }
        if (right)
        {
            position.x += vMove;
            if(step == 0)
            {
                if (position.x >= 0)
                    right = false;
            }
            else if(position.x > 0.05f)
                right = false;
        }

        transform.position = position;
    }
}
