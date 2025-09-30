using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EventText : MonoBehaviour
{
    Text _text;
    List<char> _textList = new List<char>() { '�@', '�@', '�@', '�@', '�@', '�@', '�@', '�@', '�@', '�@', '�@', '�@' };
    const string SMALLWIN = "��������I";
    const string MEDIUMWIN = "��������I";
    const string BIGWIN = "�哖����I";
    const string LUCKYSTREAK = "�m�ϒ��I�I";
    const string LUCKYSTREAKSTART = "�m�ϓ˓��I�I";
    const string LUCKYSTREAKEND = "�m�ϏI���I�I";

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
        _textList.ForEach(c => _text.text += c);
    }
}
