using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public float maxLeft;
    public float maxRight;
    public float maxUp;
    public float maxDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    if (transform.position.x > maxLeft && transform.position.x < maxRight 
                     && transform.position.y > maxDown && transform.position.y < maxUp)
                        transform.position = new Vector3(transform.position.x + (direction.x * 0.001f),
                                                     transform.position.y + (direction.y * 0.001f),
                                                     transform.position.z); 
                    break;

                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }

        if (transform.position.x < maxLeft)
            transform.position = new Vector3(maxLeft + 0.1f, transform.position.y, transform.position.z);
        if (transform.position.x > maxRight)
            transform.position = new Vector3(maxRight - 0.1f, transform.position.y, transform.position.z);
        if (transform.position.y < maxDown)
            transform.position = new Vector3(transform.position.x, maxDown + 0.1f, transform.position.z);
        if (transform.position.y > maxUp)
            transform.position = new Vector3(transform.position.x, maxUp - 0.1f, transform.position.z);

        if (directionChosen)
        {

        }

    }
}
