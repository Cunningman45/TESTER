using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    //initialize variables
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;

    //variables so the camera follows the player, with variables to determine how far ahead of the player
    //that the camera can see and how fast the camera adjusts to the players movements
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    void Update(){
        //Makes the camera follow the player along the x axis
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }//end Update
}//end class CameraFollowPlayer
