using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public partial class Stage : MonoBehaviour

{
  public void gogame(){
    nextFallTime = 1;
    stop.SetActive(false);
  }
  public void restartgame(){
    SceneManager.LoadScene(0);;
   }
   public void gomenu(){
    SceneManager.LoadScene("New Scene");
   }
}
