using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _text;

    float _delta = 0;
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
            _text.text = _delta.ToString("00.00");
        }
    }
}
