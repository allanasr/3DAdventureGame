using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Singleton;
using System;
public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup saveSetup;

    private string path = Application.streamingAssetsPath + "/save.txt";

    public Action<SaveSetup> fileLoaded;

    public int lastLevel;

    public SaveSetup setup
    {
        get { return saveSetup; }
    }
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    private void CreateNewSave()
    {
        SaveSetup setup = new SaveSetup();
        setup.lastLevel = 0;
        setup.playerName = "Allan";
    }
    private void Start()
    {
        Invoke(nameof(Load), .2f);
    }
    [NaughtyAttributes.Button]
    private void Save()
    {
        string setupToJson = JsonUtility.ToJson(setup);
        SaveFile(setupToJson);
    }

    public void SaveLastLevel(int level)
    {
        saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }
    [NaughtyAttributes.Button]

    public void SaveItens()
    {
        saveSetup.coins = CollectableManager.Instance.GetByType(ItemType.COIN).sOInt.value;
        saveSetup.health = CollectableManager.Instance.GetByType(ItemType.LIFE_PACK).sOInt.value;
        Save();
    }

    private void SaveFile(string json)
    {
        File.WriteAllText(path, json);
    }


    private void Load()
    {
        string fileLoad = "";
        if(File.Exists(path))
        {
            fileLoad = File.ReadAllText(path);
            saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoad);
            lastLevel = saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }


        fileLoaded.Invoke(saveSetup);
    }
}   

[System.Serializable]
public class SaveSetup
{
    public float coins;
    public float health;
    public int lastLevel;
    public string playerName;
}