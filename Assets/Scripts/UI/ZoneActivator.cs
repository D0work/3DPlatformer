using UnityEngine;
using System.Reflection;

public class ZoneActivator : MonoBehaviour
{
    public GameObject[] targetObjects;
    public MonoBehaviour[] targetScripts;
    public FadedImage FadedImage;
    public DamageTime DamageTime;
    public bool isSafe = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isSafe)
            {
                DisableScripts();
                DisableObjects();
            }
            else
            {
                EnableObjects();
                EnableScripts();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isSafe)
            {
                EnableObjects();
                EnableScripts();
            }
            else
            {
                DisableScripts();
                DisableObjects();
            }
        }
    }

    private void EnableScripts()
    {
        FadedImage.myReset();
        DamageTime.myReset();
        FadedImage.enabled = true;
        DamageTime.enabled = true;
    }

    private void DisableScripts()
    {
        FadedImage.myReset();
        DamageTime.myReset();
        FadedImage.enabled = false;
        DamageTime.enabled = false;
    }

    private void EnableObjects()
    {
        foreach (var obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    private void DisableObjects()
    {
        foreach (var obj in targetObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

}
