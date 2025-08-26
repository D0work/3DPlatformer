using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Tooltip("La cible � suivre (ex: le joueur)")]
    public Transform target;

    [Tooltip("Offset local par rapport � la cible")]
    public Vector3 offset = Vector3.zero;

    [Tooltip("Suivre en temps r�el ?")]
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
