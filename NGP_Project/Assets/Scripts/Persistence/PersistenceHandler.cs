using System.IO;
using UnityEngine;

public class PersistenceHandler : MonoBehaviour
{
    private static string SavePath(string fileName) => Path.Combine(Application.persistentDataPath, fileName + ".json");

    public static void Save<T>(T data, string fileName)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath(fileName), json);
    }

    public static T Load<T>(string fileName)
    {
        string path = SavePath(fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
        Debug.LogWarning("Save file not found: " + path);
        return default;
    }

    public static void DeleteAllSaves()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.json");
        foreach (string file in files)
        {
            File.Delete(file);
        }
        Debug.Log("All save files deleted.");
    }

    public static bool Exists(string fileName)
    {
        return File.Exists(SavePath(fileName));
    }
}
