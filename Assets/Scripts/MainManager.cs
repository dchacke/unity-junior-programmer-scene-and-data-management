using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        // But why implement all the singleton stuff when you
        // could instead have a static class that isn't attached
        // to any game object? Then you don't need to worry about
        // destroying duplicate instances (there are NO instances),
        // and you can still store your data and access it from
        // anywhere. You won't even need DonDestroyOnLoad.
        // I'm a Unity noob but this strikes me as code smell.
        // OOP isn't all that.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
