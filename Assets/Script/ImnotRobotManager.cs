using UnityEngine;
using System.Collections.Generic;
using WhitePalette;
using UnityEngine.UI;

public class ImnotRobotManager : MonoBehaviour
{
    [SerializeField] Text _successText;

    List<WhiteSquare> _selectList;

    static int _successCount;
    public static int SuccessCount { get { return _successCount; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _successText.text = "セキュリティ突破回数\n" + _successCount;
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
        bool succes = true;
        foreach (WhiteSquare white in _selectList)
        {
            if (white.Whites != Whites.FFFFFF)
            {
                succes = false;
                break;
            }
        }

        if (succes)
        {
            _successCount++;
        }
    }
}
