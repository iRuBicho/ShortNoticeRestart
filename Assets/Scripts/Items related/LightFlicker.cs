using UnityEngine;
using PixelCrushers.QuestMachine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;
    public float flickerSpeed = 0.05f;
    public float intensityMin = 0.5f;
    public float intensityMax = 1.5f;
    [SerializeField] private bool flickering = true;

    void Start()
    {
        if (flickerLight == null) flickerLight = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    void Update()
    {
        if (QuestMachine.GetQuestState("HelpLumia") == QuestState.Successful)
        {
            flickering = false;
        }
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            if (flickering)
            {
                flickerLight.intensity = Random.Range(intensityMin, intensityMax);
            }
            yield return new WaitForSeconds(flickerSpeed);
        }
    }

    public void SetFlickering(bool state)
    {
        flickering = state;
    }
}
