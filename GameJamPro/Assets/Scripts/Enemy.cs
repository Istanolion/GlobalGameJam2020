using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject refGun;
    public float fireRate=20f;
    private float nextTimeToFire=0f;
    [Range(0.0f,1.0f)]
    public float AttackProbability=0.5f;
    public float DamagePoints=1;
    bool enemy=false;
    public Vector3 extBox;
    public float health=5f;
    private float maxLHealth;
    public LayerMask playerMask;
    private SimpleLife m_Player;
    private void Awake() {
        maxLHealth=health;
        m_Player=GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleLife>();
    }
    public void TakeDamage(float amount){
        health-=amount;
        if (health<=0f){
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        if(Physics.CheckBox(transform.position,extBox,transform.rotation,playerMask)){
            if ( Time.time>=nextTimeToFire){
                nextTimeToFire=Time.time+1f/fireRate;
                float random= Random.Range(0.0f,1.0f);
                if (random>(1.0f-AttackProbability)){
                    Instantiate(refGun,transform.position,transform.rotation);
                    m_Player.TakeDamage(DamagePoints);
                }
            }
        }
        else{
            transform.Translate(Vector3.forward* Time.deltaTime );
        }
    }
}
