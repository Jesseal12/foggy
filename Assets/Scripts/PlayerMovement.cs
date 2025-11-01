using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
   public float movementSpeed = 15f;
   public float jumpForce = 10f;
   private bool  isGrounded;
   private Rigidbody2D rb;




   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      
   }

   private void Move()
   {
      
      
         var movement = Input.GetAxis("Horizontal");
         rb.linearVelocity = new Vector2(movement*movementSpeed, rb.linearVelocityY);

         return;
      
   }

   private void Jump()
   {
      if (Input.GetButtonDown("Jump") && isGrounded)
      {
         rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
         
      }
   }

   void OnCollisionStay2D(Collision2D collision)
   {
      print("Olemme maassa");
      if (collision.gameObject.tag == "Ground")
      {
         print("Aika Hyppiä");
         isGrounded = true;
      }
      
   }

   void OnCollisionExit2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         
         isGrounded = false;
      }
         
      
   }
   
   void Update()
   {
      Move();
      Jump();
      
   }
   

}
