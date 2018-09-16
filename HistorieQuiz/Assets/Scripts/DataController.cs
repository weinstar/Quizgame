using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour {
    
    private RoundData[] allRoundData;

    private string gameDataFileName = "data.json";

    private PlayerProgress playerProgress;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
        LoadGameData();
        LoadPlayerProgress();

        SceneManager.LoadScene("MenuScreen");
        
         	
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    public void SubmitNewPlayerScore(int newScore)
    {
        if(newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();

        }

    }
	
    public int GetHighestScore()
    {
        return playerProgress.highestScore;
    }



    private void LoadPlayerProgress ()
    {

        playerProgress = new PlayerProgress(); 

        if(PlayerPrefs.HasKey("highestscore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestscore");
        }       



    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestscore",playerProgress.highestScore);



    }


    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;


        }
        else{

            Debug.LogError("Cannot Load Game Data");
        }

    }



}
