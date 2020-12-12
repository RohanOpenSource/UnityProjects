//replace the animations and objects to suite your project
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    float mx;
    public SpriteRenderer spr;
    public Sprite m;
    public Sprite normal;
    public Animator anim;
    public Transform atk;
    public float atkr=4;
    public LayerMask enemy;
    public bool canDamage = true;
    public int health=100;
    public float jumpForce=10f;

    private void Update()
    {
        mx=Input.GetAxisRaw("Horizontal");
        //StartCoroutine(waiter());

        if (Mathf.Abs(mx) > 0)
        {
            anim.SetBool("isRunning", true);
            
        }
        /*if (Input.GetKeyDown("w"))
        {
            Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            rb.velocity = movement;
            //anim.SetTrigger("DoJump");
        }*/

        else
        {
            anim.SetBool("isRunning", false);

        }

        if (mx > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (mx < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(Physics2D.OverlapCircle(atk.position, atkr-0.5f, enemy) && canDamage)
        {
            TakeDamage(10);
        }




    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(waiter());
            
        }
        canDamage = false;
        StartCoroutine(Flash());



    }
    private IEnumerator Flash()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spr.color = Color.white;
        canDamage = true;

    }
    public void Attack()
    {
        
        anim.SetTrigger("Attack1");
        Collider2D[] e=Physics2D.OverlapCircleAll(atk.position, atkr, enemy);
        foreach(Collider2D en in e)
        {
            if (en.GetComponent<enemy_script>().canDamage)
            {
                en.GetComponent<enemy_script>().TakeDamage(10);

            }
           
        }
    }
    

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }


    IEnumerator waiter()
    {


        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("level");

    }
}

