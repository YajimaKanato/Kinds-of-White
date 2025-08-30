using System;
using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class TypingText : MonoBehaviour
{
    Text _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<Text>();
    }

    public void SetWhite()
    {
        _text.color = WhiteManager.White[(Whites)Enum.ToObject(typeof(Whites), UnityEngine.Random.Range(10, WhiteManager.WhiteNumber - 10 * StartSign.LevelIndex))];
    }
}
