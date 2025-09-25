using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _text;

    float _delta = 0;
    float _minute = 0;
    float _hour = 0;
    string _time;
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
            if (_minute >= 60)
            {
                _minute = 0;
                _hour++;
            }
            _time = _hour.ToString("00") + ":" + _minute.ToString("00") + ":" + ((int)_delta).ToString("00");
            _text.text = _time;
        }
        else
        {
            if (GameSelectButton.NowSelectIndex == 1)
            {
                PairSave();
            }
            else if (GameSelectButton.NowSelectIndex == 2)
            {
                SlideSave();
            }
        }
    }

    public void PairSave()
    {
        MemoriesManager.PairMemoriesSave(_time);
    }

    public void SlideSave()
    {
        MemoriesManager.SlideMemoriesSave(_time);
    }
}
