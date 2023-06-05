using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    Vector3 originalPos = Vector3.zero;
    void Awake()
    {
        originalPos = transform.localPosition;
    }
    public IEnumerator Shake(float duration, float magnitude)
    {


        float elapsed = 0.0f;


        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x + transform.localPosition.x, y + transform.localPosition.y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
    public void StartShake()
    {
        StartCoroutine(Shake(0.2f, 0.1f));
    }
    public void StartShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }
}
