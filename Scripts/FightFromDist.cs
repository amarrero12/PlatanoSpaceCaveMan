using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightFromDist : MonoBehaviour
{
	public float distToEnemy1;
	public float distToEnemy2;
	public float distToEnemy3;
	public bool SmackEm;
	public int BasicKills;
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject FirstKey;
	public GameObject Heart;


    // Start is called before the first frame update
    void Start()
    {
    	BasicKills = 0;
    	SmackEm = false;
    	FirstKey.SetActive(false);
    	Heart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (SmackEm == true)
        {
        	ItFinallyWorks();
        }

        if (BasicKills == 3){
        	FirstKey.SetActive(true);
        	Heart.SetActive(true);
        }

        //Autokill cuz of glitch
        if(Input.GetKeyDown("k"))
        {
        	Destroy(Enemy1);
        	Enemy1 = null;
        	Destroy(Enemy2);
        	Enemy2 = null;
        	Destroy(Enemy3);
        	Enemy3 = null;
        	BasicKills = 3;

        }



        
    }
    //killing enemies
        void ItFinallyWorks()
        {
        // 	if(Enemy1 == null){
        // 	return;
        // }else
        	if(Enemy1 != null){
        		distToEnemy1 = Vector3.Distance(transform.position, Enemy1.transform.position);
        		if (Input.GetButtonDown("Jump")){
        			if (distToEnemy1 <= 5){
        				BasicKills += 1;
        				Destroy(Enemy1);
        				Enemy1 = null;
        				//distToEnemy1 = null;
        			}
        		}
        	}
        // 	if(Enemy2 == null){
        // 	return;
        // }else
        	if(Enemy2 != null){
        		distToEnemy2 = Vector3.Distance(transform.position, Enemy2.transform.position);
        		if (Input.GetButtonDown("Jump")){
        			if (distToEnemy2 <= 5){
        				BasicKills += 1;
        				Destroy(Enemy2);
        				Enemy2 = null;
        				//distToEnemy2 = null;
        			}
        		}
        	}
        // 	if(Enemy3 == null){
        // 	return;
        // }else
        	if(Enemy3 != null){
        		distToEnemy3 = Vector3.Distance(transform.position, Enemy3.transform.position);
        		if (Input.GetButtonDown("Jump")){
        			if (distToEnemy3 <= 5){
        				BasicKills += 1;
        				Destroy(Enemy3);
        				Enemy3 = null;
        				//distToEnemy3 = null;
        			}
        		}
        	}
        }
}


