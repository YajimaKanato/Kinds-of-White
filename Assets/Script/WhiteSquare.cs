using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class WhiteSquare : MonoBehaviour
{
    [SerializeField] GameObject _check;
    [SerializeField] float _maxScale = 1.0f;
    [SerializeField] float _minScale = 0.9f;

    Image _image;
    ImnotRobotManager _imnotRobot;

    Whites _whites;
    public Whites Whites { get { return _whites; } set { _whites = value; } }

    Color32 _whiteType;
    public Color32 WhiteType { get { return _whiteType; } set { _whiteType = value; } }
    Vector3 _scale;

    bool _isSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (this.tag != "White")
        {
            this.tag = "White";
        }
        WhiteSetting();
        _check.SetActive(false);
        _imnotRobot = FindFirstObjectByType<ImnotRobotManager>();
        _scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void WhiteSetting()
    {
        _image = GetComponent<Image>();
        _image.color = _whiteType;
    }

    public void Selected()
    {
        _isSelected = !_isSelected;
        if (_isSelected)
        {
            transform.localScale = _scale * _minScale;
            _imnotRobot.SelectWhite(this);
            _check.SetActive(true);
        }
        else
        {
            transform.localScale = _scale * _maxScale;
            _imnotRobot.UnSelectWhite(this);
            _check.SetActive(false);
        }
    }
}
