using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
  public Rigidbody2D rb1;


  public float jF=20f;
  public float mx;
  public Transform feet;
  public LayerMask gL;
  public float mS=0;

  public bool isGrounded()
{
  Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, gL);
  if(groundCheck != null) {
    return true;

  }
  return false;

}

    // Update is called once per frame
    void Update()
    {
      mx=Input.GetAxisRaw("Horizontal");
      if(Input.GetButtonDown("Jump") && isGrounded()) {
	    Jump();
	}
    }
    private void FixedUpdate() {
      Vector2 movement=new Vector2(mx*mS, rb1.velocity.y);
      rb1.velocity = movement;


    }
    void Jump() {
      Vector2 movement=new Vector2(rb1.velocity.x, jF);
      rb1.velocity=movement;
}


}
