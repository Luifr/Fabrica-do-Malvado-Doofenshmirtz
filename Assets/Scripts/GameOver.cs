using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void TryAgain()
   {
       Villain.rageLevel = 0;
       SceneManager.LoadScene("Level1");
   }

   public void Exit()
   {
       Application.Quit();
   }
}
