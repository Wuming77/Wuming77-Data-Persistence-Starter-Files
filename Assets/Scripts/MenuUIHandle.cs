using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MenuUIHandle : MonoBehaviour
{
    public static string bestPlayerName = "Name";
    public static string playerName;
    public static int score = 0;
    public TextMeshProUGUI BestScoreText;
    public TMP_InputField InputText;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            //Debug.Log(path);
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.playerName;
            score = data.score;
            InputText.text = data.playerName;
            BestScoreText.text = "Best Score :" + bestPlayerName + " : " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        if (InputText.text.Length != 0)
        {
            playerName = InputText.text;
            
        }
        else
        {
            playerName = "Joy";
        }
        SceneManager.LoadScene(1);
    }
    public void ChangeBestScoreText()
    {
        if(BestScoreText.text == "Best Score")
        {
            BestScoreText.text = "Best Score : : 0"; 
        }      
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
    class SaveData
    {
        public string playerName;
        public int score;
    }
}
