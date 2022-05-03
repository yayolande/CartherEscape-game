using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public bool isGameEnded = false;
   public bool  isGamePaused = false;
   public Scene currentScene;
   public Text levelNameDisplay;
   public FollowPlayer cameraFollowPlayer;
   public GameObject pauseMenu;

   public void FailureLevel (float delay) {
      if ( isGameEnded )
         return;

      GameObject.FindWithTag ("Player").GetComponent <PlayerMovement>().enabled = false;
      isGameEnded = true;
      Invoke ("RestartLevel", delay);
   }

   void RestartLevel () {
      SceneManager.LoadScene (currentScene.buildIndex);
   }

   public void NextLevel () {
      SceneManager.LoadScene (currentScene.buildIndex + 1);
   }

   public void MainMenuLevel () {
      SceneManager.LoadScene (0);
   }

   public void QuitGame () {
      Application.Quit ();
   }

   public void AdjustCamera (Transform groundTransform) {
      cameraFollowPlayer.CameraRelocation (groundTransform);
   }

   public void PauseGame () {
      isGamePaused = ! isGamePaused;

      pauseMenu.SetActive (isGamePaused);
      Time.timeScale = ( isGamePaused ) ? 0 : 1;
      Debug.Log ("You actived the pause menu");
   }

   void Start () {
      currentScene = SceneManager.GetActiveScene();
      levelNameDisplay.text = currentScene.name;
      Time.timeScale = 1;
      Debug.Log ("New Scene, buildindex" + currentScene.buildIndex);
   }

   void Update () {
      if ( Input.GetKeyDown (KeyCode.Escape) ) {
         PauseGame ();
      }
   }
}
