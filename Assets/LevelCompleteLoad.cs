using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteLoad : MonoBehaviour
{  
    public int countdown = 3;
    public Text countdownText;
    public void LoadNextLevel () {
        
        // FindObjectOfType <GameManager>().NextLevel ();
        StartCoroutine ("LevelCompleteCoroutine");
    }

    IEnumerator LevelCompleteCoroutine () {
        for (int i=0; i < countdown; i++) {
            countdownText.text = (countdown - i).ToString();
            yield return new WaitForSeconds(1.0f);

        }
        
        FindObjectOfType <GameManager>().NextLevel ();
        // Debug.Log ("Level Loaded succesfully");
    }
}
