using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Tooltip("La cible à suivre (ex: le joueur)")]
    public Transform target;

    [Tooltip("Offset local par rapport à la cible")]
    public Vector3 offset = Vector3.zero;

    [Tooltip("Suivre en temps réel ?")]
    public bool followContinuously = true;

    void Update()
    {
        if (target && followContinuously)
        {
            transform.position = target.position + offset;
        }
    }

    public void SnapToTarget()
    {
        if (target)
            transform.position = target.position + offset;
    }
}
