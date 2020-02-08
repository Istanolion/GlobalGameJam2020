
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource GunShot;
    public float damage=10f;
    public float range=100f;
    public Camera fpsCam;
    public ParticleSystem flash;
    private float nextTimeToFire=0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0){
            Touch touch =Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began && Time.time>=nextTimeToFire){
                nextTimeToFire=Time.time+1f;
                Shoot();
            }
        }
    }

    void Shoot(){
        GunShot.Play();
        flash.Play();
        RaycastHit hit;
       if( Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)){
           Debug.Log(hit.transform.name);
           
           Enemy enemy= hit.transform.GetComponent<Enemy>();
           if(enemy!=null){
               enemy.TakeDamage(damage);
           }
       }
    }
}
