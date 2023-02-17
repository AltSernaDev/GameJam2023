using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTP : MonoBehaviour
{
    [SerializeField] Transform player, receiver;
    public bool downTP;
    public int thisTempNum;

    bool playerOverlap;

    void Update()
    {
        if(playerOverlap)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up,portalToPlayer);

            if (dotProduct>0f)
            {
                TempleChecker.tempCheckerCode.down = downTP;
                //TempleChecker.tempCheckerCode.temple = (TempleChecker.Temple)thisTempNum;
                TempleChecker.tempCheckerCode.UpdateCameras(thisTempNum);
                player.gameObject.GetComponent<CharacterController>().enabled= false;
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up,rotationDiff);
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;
                playerOverlap = false;
                player.gameObject.GetComponent<CharacterController>().enabled = true;
                Debug.Log("VEME");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlap = false;
        }
    }
}
