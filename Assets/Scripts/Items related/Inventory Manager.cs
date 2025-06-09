using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);

            if (menuActivated)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                DisablePlayerControl();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                EnablePlayerControl();
            }
        }
    }

    void DisablePlayerControl()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            foreach (MonoBehaviour script in player.GetComponents<MonoBehaviour>())
                script.enabled = false;
        }

        Camera cam = Camera.main;
        if (cam != null)
        {
            foreach (MonoBehaviour script in cam.GetComponents<MonoBehaviour>())
                script.enabled = false;
        }
    }

    void EnablePlayerControl()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            foreach (MonoBehaviour script in player.GetComponents<MonoBehaviour>())
                script.enabled = true;
        }

        Camera cam = Camera.main;
        if (cam != null)
        {
            foreach (MonoBehaviour script in cam.GetComponents<MonoBehaviour>())
                script.enabled = true;
        }
    }
}
