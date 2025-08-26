using UnityEngine;
using UnityEngine.UI;

public class DamageTime : MonoBehaviour
{
    [Header("UI & Timing")]
    public Image damageFill;
    public float fillDuration = 5f;
    private float timer = 0f;

    [Header("Damage Settings")]
    public int damageAmount = 1;
    public Health playerHealth;

    [Header("Audio")]
    public AudioClip crackSound;
    private AudioSource audioSource;

    [Header("Cycle Settings")]
    public bool autoReset = false;


    private bool hasDamaged = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        myReset();
    }

    void Update()
    {
        if (hasDamaged) return;

        if (timer < fillDuration)
        {
            timer += Time.deltaTime;
            float fillAmount = timer / fillDuration;
            if (damageFill)
                damageFill.fillAmount = fillAmount;
        }
        else
        {
            damage();
            hasDamaged = true;

            if (autoReset)
                myReset();
        }

    }

    void damage()
    {
        if (playerHealth)
        {
            playerHealth.TakeDamage(damageAmount);
            PlayDamageSound();
        }
    }

    public void myReset()
    {
        timer = 0f;
        hasDamaged = false;
        if (damageFill)
            damageFill.fillAmount = 0f;
    }

    void PlayDamageSound()
    {
        if (crackSound && audioSource)
        {
            audioSource.PlayOneShot(crackSound);
        }
    }
}
