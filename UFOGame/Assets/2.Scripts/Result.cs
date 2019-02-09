using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public RecordCell recordCell;
    public GameObject inputBoard;
    public GameObject rankBoard;
    public Transform scrollContent;
    public InputField inputUserName;
    public DataManager dataManager;

    private void Start()
    {
        inputBoard.SetActive(true);
        rankBoard.SetActive(false);
    }

    public void OnButtonOK()
    { 
        if(string.IsNullOrEmpty(inputUserName.text))
        {
            return;
        }

        inputBoard.SetActive(false);
        rankBoard.SetActive(true);

        Record myRecord = new Record
        {
            name = inputUserName.text,
            score = GameController.Instance.GetScore()
        };

        ScoreData scoreData = dataManager.LoadScore();
        scoreData.recordList.Add(myRecord);
        scoreData.recordList.Sort(CompareRecord);
        dataManager.SaveScore(scoreData);

        for (int i = 0; i < scoreData.recordList.Count; i++)
        {
            RecordCell cell = Instantiate<RecordCell>(recordCell, scrollContent);
            Record recordData = scoreData.recordList[i];

            int rank = i + 1;
            string userId = recordData.name;
            int score = recordData.score;
            bool me = (recordData == myRecord);
            cell.Init(userId, rank, score, me);
        }
    }

    int CompareRecord(Record a, Record b)
    {
        if (a.score > b.score)
            return -1;
        else if (a.score < b.score)
            return 1;
        return 0;
    }

    public void OnButtonLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OnButtonRestart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}