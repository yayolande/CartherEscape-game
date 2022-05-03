using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public Vector3 offset;
   public float offsetUp = 2f;
   public float offsetForward = -5f;
   public Transform playerTransform;
   public Vector3 playerForward;
   public Vector3 playerUp;

   void Start () {
      playerTransform = GameObject.FindWithTag ("Player").GetComponent <Transform>();

      transform.rotation = Quaternion.FromToRotation (transform.forward, playerTransform.forward);
      playerUp = playerTransform.up;
      playerForward = playerTransform.forward;

      transform.Translate (playerUp * offsetUp);
      transform.Translate (playerForward * offsetForward);
   }

   void FixedUpdate () {
      transform.position = playerTransform.position;
      Debug.DrawLine (transform.position, transform.position + playerUp * offsetUp, Color.yellow, 0);

      //transform.rotation = Quaternion.identity;
      transform.Translate (playerUp * offsetUp, Space.World);
      Debug.DrawLine (transform.position, transform.position + playerForward * offsetForward, Color.yellow, 0);

      transform.Translate (playerForward * offsetForward, Space.World);
      //transform.rotation = Quaternion.FromToRotation (transform.forward, playerForward);
      //Debug.Log ("Player forward : " + playerForward);
   }

  public void CameraRelocation (Transform groundTransform) {    
      playerUp = groundTransform.up;
      playerForward = groundTransform.forward;
      transform.rotation = Quaternion.identity;
      transform.rotation = Quaternion.FromToRotation (transform.forward, playerForward);
   }

   public void OnCollisionEnter(Collision other) {

   }
}
