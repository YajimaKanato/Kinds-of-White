using UnityEngine;
using UnityEngine.UI;

public class Score : ObjectBase
{
    Text _text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "";
    }

    public void SetScore(int score)
    {
        _text.text = "Score : " + score;
    }
}
