using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour
{
    public Light lightSource;
    public float minFlickerIntensity = 0.3f;
    public float maxFlickerIntensity = 1.5f;
    public float flickerSpeed = 0.05f;
    private bool isFlickering = true;

    private void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (isFlickering)
        {
            lightSource.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);
            yield return new WaitForSeconds(flickerSpeed);
            yield return new WaitForSeconds(Random.Range(0.03f, 0.1f));
        }
    }

    public void StopFlicker()
    {
        Debug.Log("Flickering has stopped."); // Debugging line
        isFlickering = false;
        lightSource.intensity = 1f;
    }
}
