using UnityEngine;

public class ShadowActivator : MonoBehaviour
{
    public GameObject shadowObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shadowObject.SetActive(true);
        }
    }
}
