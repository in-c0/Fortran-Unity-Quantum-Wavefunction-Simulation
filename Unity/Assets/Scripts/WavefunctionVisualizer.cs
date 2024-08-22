/*
 A basic Unity C# script to read the wavefunction data and visualize it.
 Requires a simple prefab (like a sphere) to represent points on the wavefunction. Assign this prefab to the wavePointPrefab field in the WavefunctionVisualizer component.
 (Inside Unity Inspector, Assign this prefab to the wavePointPrefab field in the WavefunctionVisualizer component.)

*/
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
public class WavefunctionVisualizer : MonoBehaviour
{
    [ReadOnly] public string relativePath = "Data/"; // path begins from Assets/ ...  (= Application.dataPath)
    public GameObject wavePointPrefab;
    public float scaleFactor = 10f;
    private string[] dataFiles;

    void Start()
    {
        string dataDirectory = Path.Combine(Application.dataPath, relativePath);
        dataFiles = Directory.GetFiles(dataDirectory, "*.dat").OrderBy(f => f).ToArray();

        if (dataFiles.Length > 0)
        {
            string latestFile = dataFiles[dataFiles.Length - 1];
            VisualizeWavefunction(latestFile);
        }
        else
        {
            Debug.LogError("No data files found in directory: " + dataDirectory);
        }
    }

    void VisualizeWavefunction(string path)
    {
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(' ');
                int index = int.Parse(data[0]);
                float realPart = float.Parse(data[1]);
                float imagPart = float.Parse(data[2]);

                float magnitude = Mathf.Sqrt(realPart * realPart + imagPart * imagPart);

                Vector3 position = new Vector3(index * 0.1f, magnitude * scaleFactor, 0);
                Instantiate(wavePointPrefab, position, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }
}


[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bool previousGUIState = GUI.enabled;
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = previousGUIState;
    }
}

public class ReadOnlyAttribute : PropertyAttribute
{
    // This is just a marker class
}