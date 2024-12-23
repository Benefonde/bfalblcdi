using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public SaveData save = new SaveData();

    public void SaveJason()
    {
        if (PlayerPrefs.GetInt("saveNumber", 1) == 0)
        {
            Debug.LogError("Tried to save file #0");
            return;
        }
        string saveData = JsonUtility.ToJson(save);
        System.IO.File.WriteAllText($"{Application.persistentDataPath}/save{save.saveNum}.json", JsonUtility.ToJson(save));
    }
}

[System.Serializable]
public class SaveData
{
    public BfdiContestant playerContestant;
    public Team playerTeam;
    public string saveName;
    public int percentage;

    public BfdiContestant[] contestantsLeft;
    public int challenges;
    public Team[] teams;
    public int saveNum;
}
