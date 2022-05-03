using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public float maxTimeOffGroundBeforeDeath = 2.0f;
   public float startTimeOffGroundBeforeDeath = 3.0f;
   public float minVelocityBeforeFailure = 1.0f;
   public float delayLoadVelocityFailure = 2.0f;
   public float time;
   public bool isPlayerOffGround = false;
   public bool isPlayerVulnarableToVelocity = false;
   public bool isPlayerMortal = true;
   public bool isLevelCompleted = false;
   public GameManager gameManager;
   public Rigidbody rb;

   void Start () {
      gameManager = FindObjectOfType <GameManager>();
      time = 0.0f;
      Debug.Log (transform.forward);
   }

   void OnCollisionExit (Collision collision) {
      if (collision.collider.tag == "Ground") {
         isPlayerOffGround = true;
         startTimeOffGroundBeforeDeath = time;
      }
   }

   void OnCollisionStay (Collision collision) {
      if (collision.collider.tag == "Ground")
         isPlayerOffGround = false;
   }


   void FixedUpdate () {

      // TODO: The game restart even when the player complete the level if he fall off the ground or lose speed. Solve it later

      // NOTE: Code on how the player can die

      if ( isPlayerMortal ) {
         if ( isPlayerOffGround ) {
            if (time - startTimeOffGroundBeforeDeath > maxTimeOffGroundBeforeDeath)
               gameManager.FailureLevel(0);
         }

         if ( rb.velocity.z < minVelocityBeforeFailure && isPlayerVulnarableToVelocity )
            gameManager.FailureLevel(delayLoadVelocityFailure);

         // To avoid restart at the start the game when the object is acceleration past `minVelocityBeforeFailure`
         if ( !isPlayerVulnarableToVelocity && rb.velocity.z > minVelocityBeforeFailure )
            isPlayerVulnarableToVelocity = true;

      }
      
      
   }

   void Update () {
      time += Time.deltaTime;
   }
}
