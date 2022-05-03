using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinished : MonoBehaviour
{
   public GameObject levelCompleteDisplay;

   void OnTriggerEnter (Collider collider) {
      Debug.Log ("Level Complete");
      levelCompleteDisplay.SetActive (true);
   }
}
