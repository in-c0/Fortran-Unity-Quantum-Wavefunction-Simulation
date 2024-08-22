/*
 A basic Unity C# script to read the wavefunction data and visualize it.
 Requires a simple prefab (like a sphere) to represent points on the wavefunction. Assign this prefab to the wavePointPrefab field in the WavefunctionVisualizer component.
 (Inside Unity Inspector, Assign this prefab to the wavePointPrefab field in the WavefunctionVisualizer component.)

*/
using System.IO;
using System.Linq;
using UnityEngine;

public class WavefunctionVisualizer : MonoBehaviour
{
    public string relativePath = "Assets/Data/";
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
