using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Destination")]
    public Teleporter teleporterDestination;

    [Tooltip("Effect when teleporting")]
    public GameObject teleporterEffect;

    private bool isTeleporterAvalable = true;

    // OnTriggerEnter est appelé quand le Collider other entre dans le déclencheur
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && isTeleporterAvalable)
        {
            teleporterDestination.isTeleporterAvalable = false;

            if (teleporterEffect != null)
            {
                Instantiate(teleporterEffect, transform.position, transform.rotation, null);
            }

            CharacterController controller = other.gameObject.GetComponent<CharacterController>();

            if (controller != null) { 
                controller.enabled = false;
            }

            float heightOffset = transform.position.y - other.transform.position.y;

            other.transform.position = teleporterDestination.transform.position - new Vector3(0,heightOffset,0);

            if (controller != null)
            {
                controller.enabled = true;
            }
        }
    }

    // OnTriggerExit est appelé quand le Collider other cesse de toucher le déclencheur
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTeleporterAvalable = true;
        }
    }
}
