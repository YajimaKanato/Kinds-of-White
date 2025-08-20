using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class Slide : MonoBehaviour
{
    [SerializeField] GameObject _check;

    SlideManager _slideManager;
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
        _slideManager = FindFirstObjectByType<SlideManager>();
        _check.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Select()
    {
        Debug.Log(_whites.ToString());
        _check.SetActive(true);
        _slideManager.AddList(this);
    }

    public void UnSelect()
    {
        _check.SetActive(false);
    }

    public void PositionChange(Vector3 pos)
    {
        transform.localPosition = pos;
    }
}
