using System.IO;
using UnityEngine;

public class PersistenceHandler : MonoBehaviour
{
    private static string SavePath(string _fileName) => Path.Combine(Application.persistentDataPath, _fileName + ".json");

    public static void Save<T>(T _data, string _fileName)
    {
        string _json = JsonUtility.ToJson(_data, true);
        File.WriteAllText(SavePath(_fileName), _json);
    }

    public static T Load<T>(string _fileName)
    {
        string _path = SavePath(_fileName);
        if (File.Exists(_path))
        {
            string _json = File.ReadAllText(_path);
            return JsonUtility.FromJson<T>(_json);
        }
        Debug.LogWarning("Save file not found: " + _path);
        return default;
    }

    public static void DeleteAllSaves()
    {
        string[] _files = Directory.GetFiles(Application.persistentDataPath, "*.json");
        foreach (string _file in _files)
        {
            File.Delete(_file);
        }
        Debug.Log("All save files deleted.");
    }

    public static bool HasAnySaveFile()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "*.json");
        return files.Length > 0;
    }

    public static bool Exists(string fileName)
    {
        return File.Exists(SavePath(fileName));
    }
}
