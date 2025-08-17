using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class WhiteSquare : MonoBehaviour
{
    Whites _whites;
    public Whites Whites { get { return _whites; } set { _whites = value; } }

    Color32 _whiteType;
    public Color32 WhiteType { get { return _whiteType; } set { _whiteType = value; } }

    Image _image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (this.tag != "White")
        {
            this.tag = "White";
        }
        WhiteSetting();
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
}
