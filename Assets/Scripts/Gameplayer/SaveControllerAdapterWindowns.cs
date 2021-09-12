using UnityEngine;

public class SaveControllerAdapterWindowns :ISaveController
{
    private Save _currentSave;

    public Save CurrentSave 
    {
        get
        {
            Load();
            return _currentSave;
        }
    }

    public SaveControllerAdapterWindowns()
    {
        Load();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            string save = PlayerPrefs.GetString("Save");

            _currentSave = JsonUtility.FromJson<Save>(save);
        }
        else
        {
            Save newSave = new Save() { TheBestScore = 0, TheLastScore = 0 };

            string save = JsonUtility.ToJson(newSave);

            PlayerPrefs.SetString("Save", save);

            PlayerPrefs.Save();
        }
    }

    public void Save(int score)
    {
        Save newSave = new Save();

        newSave.TheLastScore = score;

        if (PlayerPrefs.HasKey("Save"))
        {
            Save currentSave = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            
            if(currentSave.TheBestScore < score)
            {
                newSave.TheBestScore = score;
            }
            else
            {
                newSave.TheBestScore = currentSave.TheBestScore;
            }
        }
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(newSave));
    }
}

public class Save
{
    public int TheBestScore;

    public int TheLastScore;
}
