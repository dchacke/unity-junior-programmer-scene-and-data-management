using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    // Called each time the menu scene is opened
    private void Awake()
    {
        // Ensure singleton
        // This has to be a singleton or else the main manager
        // is instantiated again when the user returns from the
        // main scene to the menu scene.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log("awake");
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
