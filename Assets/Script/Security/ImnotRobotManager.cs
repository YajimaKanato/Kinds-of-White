using UnityEngine;
using System.Collections.Generic;
using WhitePalette;
using UnityEngine.UI;

public class ImnotRobotManager : MonoBehaviour
{
    [SerializeField] GameObject _image;
    [SerializeField] Text _text;
    [SerializeField] Text _successText;
    [SerializeField] MedalText _medalText;

    List<WhiteSquare> _selectList;

    int _count = 0;

    static int _successCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _successText.text = "セキュリティ\n連続突破回数\n" + _successCount;
        _text.text = "";
        _image.SetActive(false);
        _selectList = new List<WhiteSquare>();
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

        _count = 0;
        foreach (WhiteSquare white in _selectList)
        {
            _count++;
            if (white.Whites != Whites.FFFFFF)
            {
                succes = false;
                break;
            }
        }

        _image.SetActive(true);

        WhiteSquare[] squares = FindObjectsByType<WhiteSquare>(FindObjectsSortMode.None);
        foreach (WhiteSquare white in squares)
        {
            white.AnswerOpen();
        }

        if (succes && _count == FindFirstObjectByType<WhiteSetter>().WhiteNum)
        {
            SEManager.SEPlay("NiceWhite");
            _text.text = "Nice White!!";
            _successCount++;
            GetMedal();
        }
        else
        {
            SEManager.SEPlay("NotWhite");
            _text.text = "Not White...";
            if (_successCount > 0)
            {
                SaveCount();
            }
            _successCount = 0;
        }
    }

    public void SaveCount()
    {
        MemoriesManager.SecurityMemoriesSave(_successCount);
    }

    void GetMedal()
    {
        _medalText.MedalUp(_successCount * 5);
        Medal.SaveMedal(Medal.LoadMedal() + _successCount * 5);
    }
}
