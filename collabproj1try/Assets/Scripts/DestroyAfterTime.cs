using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 1;
    private float timer = 0;

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > timeToDestroy)
        {
            Destroy(gameObject);
        }

    }
}
