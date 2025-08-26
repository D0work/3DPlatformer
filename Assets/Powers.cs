using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Powers : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Reset PowerUp Delay")]
    public float waitTime = (5.0f);
    [Tooltip("The shooter")]
    public Health playerHealth;

    [Header("Input Actions")]
    [Tooltip("The binding for making the player activate shield")]
    public InputAction ShieldInput;
    public GameObject Shield;

    [Tooltip("The binding for making the player create platform")]
    public InputAction CreateInput;
    public Transform OriginCreate;
    public Transform OriginParent;
    public GameObject PrefabPlatform;

    [Header("Spells limits")]
    public RawImage imagePlateform;
    public RawImage imageShield;
    public GameObject[] plateformChildren;
    public GameObject[] shieldChildren;

    private bool shieldInputBlocked = false;
    private bool platformInputBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Update()
    {
        if (ShieldInput.triggered && !shieldInputBlocked)
        {
            bool b = !Shield.activeSelf;
            Shield.SetActive(b);
            playerHealth.isAlwaysInvincible = b;

            if (b) Shield.GetComponent<TimedObjectDeActive>().timeAlive = 0;

            StartCoroutine(HandleEffect(imageShield, shieldChildren, () => shieldInputBlocked = false));
            shieldInputBlocked = true;
        }
        if (CreateInput.triggered && !platformInputBlocked)
        {
            Instantiate(PrefabPlatform, OriginCreate.position, OriginParent.rotation);
            StartCoroutine(HandleEffect(imagePlateform, plateformChildren, () => platformInputBlocked = false));
            platformInputBlocked = true;
        }
    }

    /// <summary>
    /// Standard Unity function called whenever the attached gameobject is enabled
    /// </summary>
    private void OnEnable()
    {
        ShieldInput.Enable();
        CreateInput.Enable();
    }

    /// <summary>
    /// Standard Unity function called whenever the attached gameobject is disabled
    /// </summary>
    private void OnDisable()
    {
        ShieldInput.Disable();
        CreateInput.Disable();
    }

    IEnumerator HandleEffect(RawImage parent, GameObject[] children, System.Action onComplete)
    {
        SetTransparency(parent, 0f);
        SetChildrenTransparency(children, 0f);

        yield return new WaitForSeconds(waitTime);

        SetTransparency(parent, 1f);
        SetChildrenTransparency(children, 1f);

        onComplete.Invoke();
        Debug.Log("Trigger réactivated for " + parent.name);
    }

    void SetTransparency(RawImage img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }

    void SetChildrenTransparency(GameObject[] children, float alpha)
    {
        foreach (var child in children)
        {
            RawImage img = child.GetComponent<RawImage>();
            if (img != null)
            {
                SetTransparency(img, alpha);
            }
        }
    }

}