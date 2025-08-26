using UnityEngine;
using UnityEngine.UI;

public class FadedImage : MonoBehaviour
{
    [Header("Overlay Settings")]
    public Image iceOverlay;
    public float fadeDuration = 5f;

    private float timer = 0f;
    private bool isFading = true;

    private void Start()
    {
        myReset();
    }
    void Update()
    {
        if (!isFading || iceOverlay == null) return;

        if (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            SetAlpha(alpha);
        }
        else
        {
            SetAlpha(1f);
            isFading = false;
        }
    }

    public void myReset()
    {
        timer = 0f;
        isFading = true;
        SetAlpha(0f);
    }

    private void SetAlpha(float alpha)
    {
        Color c = iceOverlay.color;
        c.a = Mathf.Clamp01(alpha);
        iceOverlay.color = c;
    }
    public void StartFade()
    {
        myReset();
    }
}
