using System;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
   public float movementSpeed = 15f;
   public float jumpForce = 10f;
   public float damagePushBack = 1f;
   private bool  isGrounded;
   private Rigidbody2D rb;
   private float playerHealth=3;
   private bool damagePossible;
   private bool cantMove;
   



   void Start()
   {
      damagePossible = true;
      cantMove = false;
      rb = GetComponent<Rigidbody2D>();
      
   }

   private void DamageTimer(float damage)
   {
      
      while (damage > 0f)
      {
         damage -= Time.deltaTime;
            
      }

      if (damage <= 0f)
      {
         damagePossible = true;
      }

      

   }

  private void StunTimer(float stunTime)
   {
      rb.bodyType = RigidbodyType2D.Kinematic;
      while (stunTime > 0f)
      {
         stunTime -= Time.deltaTime;
      }

      if (stunTime <= 0f)
      {
         rb.bodyType = RigidbodyType2D.Dynamic;
         cantMove = false;
      }
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
      //print("Olemme maassa");
      if (collision.gameObject.tag == "Ground")
      {
         //print("Aika Hyppiä");
         isGrounded = true;
      }
      
      
      
      
      
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      var damagingObject = other.gameObject.GetComponent<DamageObject>();
      if (damagePossible && damagingObject!=null)
      {
         //look if it is possible to take damage and take damage from object or enemy containing damage object script
         playerHealth -= damagingObject.damage;
         rb.linearVelocity = new Vector2(damagePushBack, playerHealth);
         damagePossible = false;
         cantMove = true;
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
      
      if (damagePossible!=true)
      {
         var damageTimer = 3f;
         DamageTimer(damageTimer);
         
      }

      if (cantMove)
      {
         var stunTimer = 1.5f;
         StunTimer(stunTimer);
         
      }
      
      
      
      
      
      
      
      
      
   }
   

}
