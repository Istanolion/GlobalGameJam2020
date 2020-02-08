using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        damageReceive();
    }

    private void damageReceive()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(lives > 0)
            {
                lives -= 1;
            }
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
