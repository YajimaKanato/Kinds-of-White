using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class WhiteSquare : MonoBehaviour
{
    [SerializeField] GameObject _check;

    Image _image;
    ImnotRobotManager _imnotRobot;

    Whites _whites;
    public Whites Whites { get { return _whites; } set { _whites = value; } }

    Color32 _whiteType;
    public Color32 WhiteType { get { return _whiteType; } set { _whiteType = value; } }

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
            _imnotRobot.SelectWhite(this);
            _check.SetActive(true);
        }
        else
        {
            _imnotRobot.UnSelectWhite(this);
            _check.SetActive(false);
        }
    }
}
