using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    
   public GameObject CreditCanvas,MainCanvas;
   public AudioSource[] audios;
   public void TurnUpCredits(){
       CreditCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        audios[0].Stop();
        audios[1].Play();
   }
   public void TurnDownCredits(){
       CreditCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        audios[1].Stop();
        audios[0].Play();
   }
   public void GotoGame(){
       SceneManager.LoadScene(1,LoadSceneMode.Single);
   }
}
