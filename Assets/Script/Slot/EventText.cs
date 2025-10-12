using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EventText : MonoBehaviour
{
    Text _text;
    Animator _anim;
    List<string> _textList = new List<string>() { "シロット", "ワクワク", "当たるかな？", "見極めろ！" };
    const string _baseText = "　　　　　　　　　　　　";
    const string TWOMATCH = "　 　 　Good White！！　　　";
    const string THREEMATCH = "　  　　Nice White！！　　　";
    const string NOMATCH = " 　　　　Bad White,,,　　　";
    string _outText;
    int _length;
    int rand;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _text = GetComponent<Text>();
        NewTextSet();
    }

    public void TextUpdate()
    {
        _length++;
        _length %= _outText.Length;
        if (_length == 0)
        {
            NewTextSet();
        }
        _text.text = _outText.Substring(_length, _outText.Length - _length) + _outText.Substring(0, _length);

    }

    public void NewTextSet()
    {
        _length = 0;
        rand = Random.Range(0, _textList.Count);
        _outText = _baseText + _textList[rand];
        _text.text = _outText;
    }

    public void ThreeMatch()
    {
        _anim.SetTrigger("Hit");
        SEManager.SEPlay("GoodWhite");
        _text.text = THREEMATCH;
    }

    public void TwoMatch()
    {
        _anim.SetTrigger("Hit");
        SEManager.SEPlay("NiceWhite");
        _text.text = TWOMATCH;
    }

    public void NoMatch()
    {
        _anim.SetTrigger("Hit");
        SEManager.SEPlay("NotWhite");
        _text.text = NOMATCH;
    }
}
