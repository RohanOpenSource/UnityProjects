using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bullet : MonoBehaviour
{
	public Rigidbody2D rb;
	public float speed=20f;
	public float damage = 40f;
	public bool canHit=false;




    // Start is called before the first frame update
    void Start()
    {
    	rb.velocity= transform.right * speed;
			StartCoroutine(wait());


    }
		private IEnumerator wait(){
			yield return new WaitForSeconds(0.2f);
			canHit=true;
		}


    void OnTriggerEnter2D(Collider2D h){
			Debug.Log("hit something");
    	Player player = h.gameObject.GetComponent<Player>();

		if (player != null && canHit)
		{
			player.TakeDamage(damage);
			Destroy(gameObject);
		}


    }

}
