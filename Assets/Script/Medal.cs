/// <summary>
/// セーブ用クラス
/// いじらない
/// </summary>
[System.Serializable]
public class MedalData
{
    public int MedalAmount;
}

public class Medal
{
    static MedalData _medalData;
    const string FILENAME = "medal";

    public static void SaveMedal(int amount)
    {
        _medalData = new MedalData();
        _medalData.MedalAmount = amount;
        SaveManager.SaveDataPrefs(FILENAME, _medalData);
    }

    public static int LoadMedal()
    {
        var medal = SaveManager.LoadDataPrefs<MedalData>(FILENAME);
        return medal != default ? medal.MedalAmount : 100;
    }
}
