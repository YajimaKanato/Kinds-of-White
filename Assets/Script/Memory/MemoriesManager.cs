using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

public static class MemoriesManager
{
    static List<int> _securityList = new List<int>(Enumerable.Repeat(0, 5));
    const string SECURITYFILENAME = "security";
    static List<(int hour, int minute, int second)> _pairList = new List<(int hour, int minute, int second)>();
    const string PAIRFILENAME = "pair";
    static List<(int hour, int minute, int second)> _slideList = new List<(int hour, int minute, int second)>();
    const string SLIDEFILENAME = "slide";
    static List<int> _typingListEasy = new List<int>(Enumerable.Repeat(0, 5));
    const string TYPINGFILENAMEEASY = "typingeasy";
    static List<int> _typingListNormal = new List<int>(Enumerable.Repeat(0, 5));
    const string TYPINGFILENAMENORMAL = "typingnormal";
    static List<int> _typingListHard = new List<int>(Enumerable.Repeat(0, 5));
    const string TYPINGFILENAMEHARD = "typinghard";

    public static void SecurityMemoriesSave(int memory)
    {
        _securityList.Add(memory);
        var mem = _securityList.OrderByDescending(x => x).ToList();
        for (int i = 5; i < mem.Count; i++)
        {
            mem.RemoveAt(mem.Count - 1);
        }

        var data = new MemoryData($"{mem[0]}", $"{mem[1]}", $"{mem[2]}", $"{mem[3]}", $"{mem[4]}");

        SaveManager.SaveDataPrefs(SECURITYFILENAME, data);
    }

    public static MemoryData SecurityMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(SECURITYFILENAME);
    }

    public static void PairMemoriesSave(string time)
    {
        var s = Array.ConvertAll(time.Split(':'), int.Parse);
        _pairList.Add((s[0], s[1], s[2]));
        var mem = _pairList.OrderBy(n => n.hour).ThenBy(n => n.minute).ThenBy(n => n.second).Select(n => $"{n.hour}:{n.minute}:{n.second}").ToList();
        if (mem.Count > 5)
        {
            mem.RemoveAt(mem.Count - 1);
        }
        else
        {
            for (int i = mem.Count - 1; i < 5; i++)
            {
                mem.Add("00:00:00");
            }
        }

        var data = new MemoryData(mem[0], mem[1], mem[2], mem[3], mem[4]);

        SaveManager.SaveDataPrefs(PAIRFILENAME, data);
    }

    public static MemoryData PairMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(PAIRFILENAME);
    }

    public static void SlideMemoriesSave(string time)
    {
        var s = Array.ConvertAll(time.Split(':'), int.Parse);
        _slideList.Add((s[0], s[1], s[2]));
        var mem = _slideList.OrderBy(n => n.hour).ThenBy(n => n.minute).ThenBy(n => n.second).Select(n => $"{n.hour}:{n.minute}:{n.second}").ToList();
        if (mem.Count > 5)
        {
            mem.RemoveAt(mem.Count - 1);
        }
        else
        {
            for (int i = mem.Count - 1; i < 5; i++)
            {
                mem.Add("00:00:00");
            }
        }

        var data = new MemoryData(mem[0], mem[1], mem[2], mem[3], mem[4]);

        SaveManager.SaveDataPrefs(SLIDEFILENAME, data);
    }

    public static MemoryData SlideMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(SLIDEFILENAME);
    }

    public static void TypingEasyMemoriesSave(int score)
    {
        _typingListEasy.Add(score);
        var mem = _typingListEasy.OrderByDescending(n => n).ToList();
        for (int i = 5; i < mem.Count; i++)
        {
            mem.RemoveAt(mem.Count - 1);
        }

        var data = new MemoryData($"{mem[0]}", $"{mem[1]}", $"{mem[2]}", $"{mem[3]}", $"{mem[4]}");

        SaveManager.SaveDataPrefs(TYPINGFILENAMEEASY, data);
    }

    public static void TypingNormalMemoriesSave(int score)
    {
        _typingListNormal.Add(score);
        var mem = _typingListNormal.OrderByDescending(n => n).ToList();
        for (int i = 5; i < mem.Count; i++)
        {
            mem.RemoveAt(mem.Count - 1);
        }

        var data = new MemoryData($"{mem[0]}", $"{mem[1]}", $"{mem[2]}", $"{mem[3]}", $"{mem[4]}");

        SaveManager.SaveDataPrefs(TYPINGFILENAMENORMAL, data);
    }

    public static void TypingHardMemoriesSave(int score)
    {
        _typingListHard.Add(score);
        var mem = _typingListHard.OrderByDescending(n => n).ToList();
        for (int i = 5; i < mem.Count; i++)
        {
            mem.RemoveAt(mem.Count - 1);
        }

        var data = new MemoryData($"{mem[0]}", $"{mem[1]}", $"{mem[2]}", $"{mem[3]}", $"{mem[4]}");

        SaveManager.SaveDataPrefs(TYPINGFILENAMEHARD, data);
    }

    public static MemoryData TypingEasyMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(TYPINGFILENAMEEASY);
    }

    public static MemoryData TypingNormalMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(TYPINGFILENAMENORMAL);
    }

    public static MemoryData TypingHardMemoriesLoad()
    {
        return SaveManager.LoadDataPrefs<MemoryData>(TYPINGFILENAMEHARD);
    }
}

[Serializable]
public class MemoryData
{
    public string Mem1;
    public string Mem2;
    public string Mem3;
    public string Mem4;
    public string Mem5;

    public MemoryData(string mem1, string mem2, string mem3, string mem4, string mem5)
    {
        Mem1 = mem1;
        Mem2 = mem2;
        Mem3 = mem3;
        Mem4 = mem4;
        Mem5 = mem5;
    }
}
