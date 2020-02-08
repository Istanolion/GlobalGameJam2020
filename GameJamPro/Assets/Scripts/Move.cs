using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int maxLeft;
    public int maxRight;
    public int maxUp;
    public int maxDown;


    private float posX;
    private float posY;
    private bool x = true;
    private bool y = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (x == true && y == true){
            posX += 0.1f;
            posY += 0.1f;
            if (posX > maxRight)
                x = false;
            if (posY > maxUp)
                y = false;
        }
        else if (x == true && y == false)
        {
            posX += 0.1f;
            posY -= 0.1f;
            if (posX > maxRight)
                x = false;
            if (posY < maxDown)
                y = true;
        }
        else if (x == false && y == true)
        {
            posX -= 0.1f;
            posY += 0.1f;
            if (posX < maxLeft)
                x = true;
            if (posY > maxUp)
                y = false;
        }
        else
        {
            posX -= 0.1f;
            posY -= 0.1f;
            if (posX < maxLeft)
                x = true;
            if (posY < maxDown)
                y = true;
        }

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
