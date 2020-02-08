using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private GameObject m_camera;
    public LayerMask m_enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        m_camera= GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            RaycastHit hit;
            if(Physics.Raycast(m_camera.transform.position,m_camera.transform.forward,out hit,10.0f,m_enemyLayer)){
                Debug.Log("Make Damage");
            }
        }
    }
}
