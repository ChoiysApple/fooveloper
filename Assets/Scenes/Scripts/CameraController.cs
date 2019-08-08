using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
/*
public class cameraController : MonoBehaviour
{

    public Transform target;

    playerScript playerController;

    float xOffset;
    // Use this for initialization
    void Start()
    {
        xOffset = transform.position.x - target.position.x;
        playerController = target.GetComponent<playerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        if (playerController.isFacingRight)
        {
            newPosition.x = target.position.x + xOffset;
        }
        else
        {
            newPosition.x = target.position.x - xOffset;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, 0.07f);


    }
}*/

