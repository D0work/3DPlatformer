using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public MonoBehaviour scriptToEnable;
    public MonoBehaviour scriptToDisable;
    public Transform objectToReset;
    private Vector3 initialPosition;

    void Start()
    {
        if (objectToReset != null)
            initialPosition = objectToReset.position;
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerDeath += allReset;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerDeath -= allReset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scriptToEnable != null)
                scriptToEnable.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allReset();
        }
    }

    void allReset()
    {
        if (scriptToDisable != null)
            scriptToDisable.enabled = false;

        if (objectToReset != null)
            objectToReset.position = initialPosition;
    }
}
