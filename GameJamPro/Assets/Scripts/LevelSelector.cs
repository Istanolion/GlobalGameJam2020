using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    public void GotoGame(int LevelIndex){
       SceneManager.LoadScene(LevelIndex,LoadSceneMode.Single);
   }
}
