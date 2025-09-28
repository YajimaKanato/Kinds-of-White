using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class Timerrrr : ObjectBase
{
    [SerializeField] float _timeLimit = 60;
    [SerializeField] Text _nice;
    [SerializeField] GameObject _button;
    [SerializeField] TypingManager _typingManager;

    Text _text;

    float _delta;
    bool _isMemoried = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "60.00";
        _delta = _timeLimit;
        _nice.text = "";
        _button.SetActive(false);
        _isMemoried = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart && !_isEnd)
        {
            if (_delta > 0)
            {
                _delta -= Time.deltaTime;
                _text.text = _delta.ToString("00.00");
            }
            else
            {
                var objs = FindObjectsByType<ObjectBase>(FindObjectsSortMode.None);
                foreach (var obj in objs)
                {
                    obj.GameEnd();
                }
                _delta = 0;
                _text.text = _delta.ToString("00.00");
                _nice.text = "Nice White!!";
                _button.SetActive(true);
                if (!_isMemoried)
                {
                    _isMemoried = true;
                    switch (StartSign.LevelIndex)
                    {
                        case 0:
                            MemoriesManager.TypingEasyMemoriesSave(_typingManager.Score);
                            break;
                        case 1:
                            MemoriesManager.TypingNormalMemoriesSave(_typingManager.Score);
                            break;
                        case 2:
                            MemoriesManager.TypingHardMemoriesSave(_typingManager.Score);
                            break;
                    }
                    Medal.SaveMedal(Medal.LoadMedal() + _typingManager.Score / 50);
                }
            }
        }
    }
}
