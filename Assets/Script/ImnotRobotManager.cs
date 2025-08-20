using UnityEngine;
using System.Collections.Generic;
using WhitePalette;
using UnityEngine.UI;

public class ImnotRobotManager : MonoBehaviour
{
    [SerializeField] GameObject _image;
    [SerializeField] Text _text;
    [SerializeField] Text _successText;

    List<WhiteSquare> _selectList;

    static int _successCount;
    public static int SuccessCount { get { return _successCount; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _successText.text = "セキュリティ\n連続突破回数\n" + _successCount;
        _text.text = "";
        _image.SetActive(false);
        _selectList = new List<WhiteSquare>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectWhite(WhiteSquare white)
    {
        _selectList.Add(white);
    }

    public void UnSelectWhite(WhiteSquare white)
    {
        _selectList.Remove(white);
    }

    public void PressedEnter()
    {
        bool succes = false;
        if (_selectList.Count > 0)
        {
            succes = true;
        }

        foreach (WhiteSquare white in _selectList)
        {
            if (white.Whites != Whites.FFFFFF)
            {
                succes = false;
                break;
            }
        }

        _image.SetActive(true);

        if (succes)
        {
            _text.text = "Nice White!!";
            _successCount++;
        }
        else
        {
            _text.text = "Not White...";
            _successCount = 0;
        }
    }
}
