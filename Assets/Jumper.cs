using UnityEngine;

public class Jumper : MonoBehaviour
{
   public Transform jumpTarget;
   public PlayerMovement playerMovement;
   public Transform playerTransform;
   public PlayerManager playerManager;
   public float forwardThrust;
   public float sideThrust;
   public bool isJumperEnabled;

   void OnTriggerEnter (Collider collider) {
      if ( collider.tag == "Player" ) {
         Debug.Log ("Jumper Activated");
         isJumperEnabled = true;
         playerTransform = collider.gameObject.transform;
         playerMovement = collider.gameObject.GetComponent <PlayerMovement>();
         forwardThrust = playerMovement.forwardThrust;
         sideThrust = playerMovement.sideThrust;
         playerMovement.forwardThrust = 0;
         playerMovement.sideThrust = 0;
         playerManager = collider.gameObject.GetComponent <PlayerManager>();
         playerManager.isPlayerMortal = false;
         playerManager.isPlayerVulnarableToVelocity = false;
         playerMovement.enabled = false;
      }
   }

   void FixedUpdate () {
      if ( !isJumperEnabled )
         return;

      playerTransform.position = Vector3.MoveTowards (playerTransform.position, jumpTarget.position, 30f * Time.fixedDeltaTime);
      if ( Vector3.Distance (playerTransform.position, jumpTarget.position) < .1f ) {
         Debug.Log ("Jumper disabled");
         isJumperEnabled = false;
         playerMovement.forwardThrust = forwardThrust;
         playerMovement.sideThrust = sideThrust;
         playerMovement.enabled = true;
         playerManager.isPlayerMortal = true;
      }
   }
}
