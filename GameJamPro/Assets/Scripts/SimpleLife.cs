using UnityEngine;
using UnityEngine.UI;
public class SimpleLife : MonoBehaviour
{
    public Sprite[] damageSprites;
    public Image damageImage;
    public float health=20f;
    private float MaxHealth;
    private float tenPercent,damageCounter;
    private int damIm=0;
    public AudioSource GameOverAudio;
    private AudioSource[] allAudioSources;
    public GameObject LoseCanvas;
 
    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }
    private void Awake() {
        MaxHealth=health;
        tenPercent=MaxHealth/10f;
    }
    public void TakeDamage(float amount){
        health-=amount;
        damageCounter++;    
        if (health<=0f){
            Time.timeScale=0.0f;
            StopAllAudio();
            GameOverAudio.Play();
            LoseCanvas.SetActive(true);
        }
        if(damageCounter>=tenPercent){
            damageCounter=0;
            damIm++;
            damageImage.sprite = damageSprites[damIm];
        }
    }
}
