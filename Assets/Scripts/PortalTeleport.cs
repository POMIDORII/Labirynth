using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    private bool playerIsOverLapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverLapping = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverLapping = false;
        }
    }

    private void FixedUpdate()
    {
        Teleportation();
    }
    private void Teleportation()
    {
        if(playerIsOverLapping)
        {
            Vector3 portaltoPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portaltoPlayer);

            if(dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portaltoPlayer;
                player.position = receiver.position + positionOffset;

                playerIsOverLapping = false;
            }
        }


    }
}
