using UnityEngine;

public class Boss : MonoBehaviour
{

    public float fireRate=20f;
    private float nextTimeToFire=0f;
    [Range(0.0f,1.0f)]
    public float AttackProbability=0.5f;
    public float DamagePoints=1;
    bool enemy=false;
    public Vector3 extBox;
    public float health=10f;
    private float maxLHealth;
    public LayerMask playerMask;
    private SimpleLife m_Player;
    int ShootFired=0;
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
        if(Physics.CheckBox(transform.position,extBox,Quaternion.identity,playerMask)){
            if ( Time.time>=nextTimeToFire*10){
                nextTimeToFire=Time.time+1f/fireRate;
                float random= Random.Range(0.0f,1.0f);
                if (random>(1.0f-AttackProbability)){
                    m_Player.TakeDamage(DamagePoints);
                    ShootFired++;
                    Debug.Log(ShootFired);
                }
            }
        }
        else{
            transform.Translate(Vector3.forward* Time.deltaTime );
        }
    }
}
