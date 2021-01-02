using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform fp;
	public GameObject bullet;
	public string fireButton;

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(fireButton)){
    		shoot();
    	}

    }
    void shoot(){
    	Instantiate(bullet, fp.position, fp.rotation);

    }
}
