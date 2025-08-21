using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _text;

    float _delta = 0;
    float _minute = 0;
    float _hour = 0;
    bool _isEnd = false;
    public bool IsEnd { get { return _isEnd; } set { _isEnd = value; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnd)
        {
            _delta += Time.deltaTime;
            if (_delta >= 60)
            {
                _delta = 0;
                _minute++;
            }
            if( _minute >= 60)
            {
                _minute = 0;
                _hour++;
            }
            _text.text = "";
            _text.text += _hour.ToString("00");
            _text.text += ":";
            _text.text += _minute.ToString("00");
            _text.text += ":";
            _text.text += ((int)_delta).ToString("00");
        }
    }
}
