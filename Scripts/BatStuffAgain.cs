using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStuffAgain : MonoBehaviour
{
	SpriteRenderer batlook;
	float AhiMismo;
	public GameObject player;
	public PlayerMove PScript;

    // Start is called before the first frame update
    void Start()
    {
        batlook = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AhiMismo = Vector3.Distance(transform.position, player.transform.position);

        if (AhiMismo < 3) 
        {
        	if (Input.GetKeyDown("x"))
        	{
        		batlook.enabled = false;
        		PScript.BatterUp();
        	}
        }
    }
}
