using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float velocidad=5f;
    public LayerMask playerMask;
    // Update is called once per frame
    void Update()
    {
        Vector3 box=new Vector3 (1f,0f,3f);
        transform.position = transform.position + transform.forward* velocidad * Time.deltaTime;   //Se asigna a una nueva posición en la dirección anterior y se multiplica por la velocidad 
        if(Physics.CheckBox(transform.position,box,transform.rotation,playerMask)){
            Destroy(gameObject);
        }
    }
}
