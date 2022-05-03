using UnityEngine;

public class TestPlayer : MonoBehaviour
{
   public Rigidbody rb;
   public bool isMoved = false;
   public float t=0;

   void Start () {
      rb = GetComponent <Rigidbody>();
   }

   void FixedUpdate () {
      if ( isMoved )
         return;

      t += Time.fixedDeltaTime;
      //transform.position = Vector3.Lerp (transform.position, new Vector3(0, 3.4f, 10), .1f * t);
      //transform.position = Vector3.MoveTowards (transform.position, new Vector3(0, 3.4f, 10), 6f * Time.fixedDeltaTime);
      //rb.MovePosition (transform.position + transform.forward * Time.fixedDeltaTime);
      transform.position = Vector3.MoveTowards (transform.position, new Vector3(0, 10f, 0), 2f * Time.fixedDeltaTime);
      if ( Vector3.Distance (transform.position, new Vector3(0, 10f, 0)) < 0.1f )
         isMoved = true;
   }
}
