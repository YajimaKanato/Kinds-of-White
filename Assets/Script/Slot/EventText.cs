using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EventText : MonoBehaviour
{
    Text _text;
    List<char> _textList = new List<char>() { '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　' };
    const string SMALLWIN = "小当たり！";
    const string MEDIUMWIN = "中当たり！";
    const string BIGWIN = "大当たり！";
    const string LUCKYSTREAK = "確変中！！";
    const string LUCKYSTREAKSTART = "確変突入！！";
    const string LUCKYSTREAKEND = "確変終了！！";

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        _textList.ForEach(c => _text.text += c);
    }
}
