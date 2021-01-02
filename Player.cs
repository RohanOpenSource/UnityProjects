using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float health=10f;
  public ParticleSystem hitfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount){
      health-=amount;
      //hitfx.Play
      if(health<=0){
        Destroy(gameObject);
      }

    }
}
