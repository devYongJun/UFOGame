using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class ScoreData
{
    public List<Record> recordList;
}

[Serializable]
public class Record
{
    public string name;
    public int score;
}


public class DataManager : MonoBehaviour
{
    const string SCORE_DATA = "/score_data.json";

    public ScoreData LoadScore()
    {
        ScoreData scoreData = null;
        try
        {
            string json = File.ReadAllText(Application.dataPath + SCORE_DATA, Encoding.UTF8);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        catch (FileNotFoundException exception)
        {
            Debug.Log(exception);
            scoreData = new ScoreData();
            scoreData.recordList = new List<Record>();
        }
        return scoreData;
    }

    public void SaveScore(ScoreData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint:true);
        File.WriteAllText(Application.dataPath + SCORE_DATA, json);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}