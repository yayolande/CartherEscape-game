using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float forwardThrust = 500f;
   public float sideThrust = 100f;
   public float sidewayMove;
   public Vector3 thrustPlayer;
   public Vector3 forwardPlayer;
   public Vector3 rightPlayer;
   public Rigidbody rb;
   public bool isFirstContact = true;

   void Start () {
      forwardPlayer = transform.forward;
      rightPlayer = transform.right;
   }

    void Update()
    {
       sidewayMove = Input.GetAxis ("Horizontal");
    }

    void FixedUpdate () {
       //thrustPlayer = new Vector3 (sidewayMove * sideThrust, 0, forwardThrust);
       thrustPlayer = (forwardPlayer * forwardThrust) + (rightPlayer * sideThrust * sidewayMove);
       rb.AddForce (thrustPlayer * Time.fixedDeltaTime, ForceMode.VelocityChange);
      // Debug.DrawLine (transform.position, transform.position + forwardPlayer * 5, Color.red, 1);
      // Debug.DrawLine (transform.position, transform.position - forwardPlayer * 5, Color.green, 1);
      // Debug.DrawLine (transform.position, transform.position + transform.up * 5, Color.red, 1);

    }

    void OnCollisionEnter (Collision collision) {
       if ( collision.collider.tag == "Ground" && !isFirstContact ) {
          Debug.Log ("We hit the ground");
          forwardPlayer = collision.transform.forward;
          rightPlayer = collision.transform.right;
          transform.rotation = Quaternion.identity;
          transform.rotation = Quaternion.FromToRotation (transform.forward, forwardPlayer);
          FindObjectOfType <GameManager> ().AdjustCamera (collision.transform);
       }

       isFirstContact = false;
    }
}
