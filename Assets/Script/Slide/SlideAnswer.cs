using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class SlideAnswer : MonoBehaviour
{
    Image _image;
    Whites _whites;
    public Whites Whites { get { return _whites; } set { _whites = value; } }

    Color32 _whiteType = new Color(255, 255, 255);
    public Color32 WhiteType { get { return _whiteType; } set { _whiteType = value; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _image = GetComponent<Image>();
        _image.color = _whiteType;
    }

    public void FindColor()
    {
        Debug.Log(_whites.ToString());
    }
}
