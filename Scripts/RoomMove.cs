using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
	//how much we wanna move the camera and player for the transition
	public Vector2 cameraChange;
	public Vector3 playerChange;

	//calls back to the camera movement script
	private CameraMovement cam;

    // Start is called before the first frame update
    void Start()
    {
    	//reference
        cam = Camera.main.GetComponent<CameraMovement>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
    	//if player touches collider, move camera (transition screen)
    	if(other.CompareTag("Player"))
    	{
    		cam.minPosition += cameraChange;
    		cam.maxPosition += cameraChange;
    		other.transform.position += playerChange;
    	}
    }
}
