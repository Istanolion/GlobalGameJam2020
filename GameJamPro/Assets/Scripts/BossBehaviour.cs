using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int hp;
    private float rMayor, rMinor;
    private float speed;
    private float fireRate;
    private float reloadRate;
    public int bullets;
    public bool st1, st2, st3;
    public bool ida, vuelta, shoot, reload;
    private float timeFire;
    private float timeReload;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        st1 = true;
        ida = true;
        bullets = 20;
        hp = 30;
        rMayor = 30.0f;
        rMinor = 20.0f;
        speed = 5.0f;
        fireRate = 0.5f;
        reloadRate = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        actualizarEstado();
        movBoss();

        if (Input.GetKeyDown(KeyCode.A))
        {
            hp -= 1;
        }
    }

    private void movBoss()
    {
        this.transform.LookAt(target.transform);
        if (st1)
        {
            if (ida)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) <= 10.0f)
                {
                    ida = false;
                    shoot = true;
                }
            }
            if (shoot)
            {
                this.transform.Translate(new Vector2(speed * Time.deltaTime, 0.0f));
                if (bullets == 0)
                {
                    vuelta = true;
                    shoot = false;
                }
                else
                {
                    if (Time.time > timeFire)
                    {
                        Shoot();
                    }
                }
            }
            if (reload)
            {
                if (bullets == 20)
                {
                    ida = true;
                    reload = false;
                }
                else
                {
                    timeReload = Time.time + reloadRate;
                    //if (Time.time > timeReload)
                    //{
                       Reload();
                    //}
                }
            }
            if (vuelta)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) >= 20.0f)
                {
                    vuelta = false;
                    reload = true;
                }
            }
        }
        if (st2)
        {
            if (ida)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) <= 10.0f)
                {
                    ida = false;
                    shoot = true;
                }
            }
            if (shoot)
            {
                this.transform.Translate(new Vector2(speed * Time.deltaTime, 0.0f));
                if (bullets == 0)
                {
                    vuelta = true;
                    shoot = false;
                }
                else
                {
                    if (Time.time > timeFire)
                    {
                        Shoot();
                    }
                }
            }
            if (reload)
            {
                if (bullets == 20)
                {
                    ida = true;
                    reload = false;
                }
                else
                {
                    //if (Time.time > timeReload)
                    //{
                       Reload();
                    //}
                }
            }
            if (vuelta)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) >= 20.0f)
                {
                    vuelta = false;
                    reload = true;
                }
            }
        }
        if (st3)
        {
            if (ida)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) <= 10.0f)
                {
                    ida = false;
                    shoot = true;
                }
            }
            if (shoot)
            {
                this.transform.Translate(new Vector2(speed * Time.deltaTime, 0.0f));
                if (bullets == 0)
                {
                    vuelta = true;
                    shoot = false;
                }
                else
                {
                    if (Time.time > timeFire)
                    {
                        Shoot();
                    }
                }
            }
            if (reload)
            {
                if (bullets == 20)
                {
                    ida = true;
                    reload = false;
                }
                else
                {
                    if (Time.time > timeReload)
                    {
                        Reload();
                    }
                }
            }
            if (vuelta)
            {
                this.transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
                if (Vector3.Distance(this.transform.position, target.transform.position) >= 20.0f)
                {
                    vuelta = false;
                    reload = true;
                }
            }
        }
    }

    private void actualizarEstado()
    {
        if (st1)
        {
            fireRate = 2.0f;
            speed = 3.0f;
            if(hp <= 15)
            {
                st2 = true;
                st1 = false;
            }
        }
        if (st2)
        {
            fireRate = 0.5f;
            speed = 7.0f;
            if (hp <= 7)
            {
                st3 = true;
                st2 = false;
            }
        }
        if (st3)
        {
            fireRate = 0.80f;
            speed = 10.0f;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot!");
        timeFire = Time.time + fireRate;
        bullets -= 1;
    }

    private void Reload()
    {
        Debug.Log("Reload!");
        bullets = 20;
    }
}
