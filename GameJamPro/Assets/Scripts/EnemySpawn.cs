using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float radius = 10.0f;
    public int MaxEnem=20;
    private float timeSpawn;
    public float rateSpawn = 2.0f;
    public GameObject refEnemy;
    private int limitEnemys;
    public AudioSource WinMusic;
    public GameObject WinCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        limitEnemys = 0;
    }
void StopAllAudio() {
        AudioSource[] allAudioSources;
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        int n = 0;
        if (limitEnemys < MaxEnem)
        {
            if (Time.time > timeSpawn)
            {
                n = Random.Range(0, 12);
                InstantiateEnemys(n);
            }            
        }
        else{
            GameObject[] enemies=GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length==0)
            {
                StopAllAudio();
                WinMusic.Play();
                WinCanvas.SetActive(true);
            }
        }
    }

    private void InstantiateEnemys(int n)
    {
        Instantiate(refEnemy, new Vector3(Mathf.Cos(n * 30) * radius, refEnemy.transform.position.y, Mathf.Sin(n * 30) * radius), refEnemy.transform.rotation);
        limitEnemys += 1;
        timeSpawn = Time.time + rateSpawn;
    }
}
