using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
	public PlayerMove scriptWithKey;
	public float distToSora;
	public GameObject Sora;
	public Animator roomAnim;
	public BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	distToSora = Vector3.Distance(transform.position, Sora.transform.position);
        
        if (scriptWithKey.gotKey == true)
        {
        	if (distToSora <= 5)
        	{
        		roomAnim.SetBool("unlock", true);
        		collider.enabled = false;
        	}
        }
    }
}
