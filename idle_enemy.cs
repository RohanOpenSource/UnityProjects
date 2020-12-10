//this enemy will not move. you can use the a# pathfinding project for awsome pathfinding(link to brackeys video in teh description)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    public SpriteRenderer spr;
    public int health = 100;
    public bool canDamage = true;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            die();
        }
        canDamage = false;
        StartCoroutine(Flash());



    }
    private IEnumerator Flash()
    {
        spr.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        spr.color = Color.white;
        canDamage = true;

    }

    public void die()
    {
        Destroy(gameObject);
    }

}
