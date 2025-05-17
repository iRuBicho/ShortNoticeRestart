using UnityEngine;

public class ShadowActivator : MonoBehaviour
{
    [SerializeField] private GameObject shadowObject;

    private void Start()
    {
        if (shadowObject != null)
            shadowObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (shadowObject != null)
            {
                Debug.Log("Player entered trigger - Shadow Activated");
                shadowObject.SetActive(true);
            }
        }
    }
}

