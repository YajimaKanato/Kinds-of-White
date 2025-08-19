using UnityEngine;
using System.Collections.Generic;
using WhitePalette;
using System;

public class SlideManager : MonoBehaviour
{
    [SerializeField] List<SlideAnswer> _slideAnswerList;
    List<Whites> _answerWhiteList = new List<Whites>();
    Slide[] _slide;
    List<Slide> _selectSlide = new List<Slide>();
    List<int> _selectIndex = new List<int>();

    int _slideCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SlideSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SlideSetting()
    {
        _slideCount = _slideAnswerList.Count;
        int rand;
        int count = 0;
        while (_answerWhiteList.Count < _slideCount)
        {
            rand = UnityEngine.Random.Range(0, WhiteManager.WhiteNumber);
            if (!_answerWhiteList.Contains((Whites)Enum.ToObject(typeof(Whites), rand)))
            {
                _answerWhiteList.Add((Whites)Enum.ToObject(typeof(Whites), rand));
            }

            count++;
            if (count >= _slideCount) break;
        }

        _slide = FindObjectsByType<Slide>(FindObjectsSortMode.None);
        Debug.Log(_slide.Length);
        if (_slide.Length == _slideAnswerList.Count)
        {
            for (int i = 0; i < _answerWhiteList.Count; i++)
            {
                _slide[i].Whites = _answerWhiteList[i];
                _slide[i].WhiteType = WhiteManager.White[_answerWhiteList[i]];
                _slideAnswerList[i].Whites = _answerWhiteList[i];
                _slideAnswerList[i].WhiteType = WhiteManager.White[_answerWhiteList[i]];
            }
        }
        else
        {
            Debug.Log("_slide.Length != _slideAnswerList.Count");
        }
    }

    public void AddList(Slide slide)
    {
        _selectSlide.Add(slide);
        _selectIndex.Add(Array.IndexOf(_slide, slide));
        if (_selectSlide.Count >= 2)
        {
            SlideCheck();
        }
    }

    void SlideCheck()
    {
        if (_selectSlide[0].Whites != _selectSlide[1].Whites)
        {
            _selectSlide[0].PositionChange(_selectSlide[1].gameObject.transform.localPosition);
            _selectSlide[1].PositionChange(_selectSlide[0].gameObject.transform.localPosition);
            _selectSlide.Clear();

            if (_selectIndex[0] != -1 && _selectIndex[1] != -1)
            {
                Slide s = _slide[_selectIndex[0]];
                _slide[_selectIndex[0]] = _slide[_selectIndex[1]];
                _slide[_selectIndex[1]] = s;
            }

            bool isAllMatch = true;
            for (int i = 0; i < _slideCount; i++)
            {
                if (_slide[i].Whites != _answerWhiteList[i])
                {
                    isAllMatch = false;
                    break;
                }
            }

            if (isAllMatch)
            {

            }
        }
        else
        {
            _selectSlide.Clear();
        }
    }
}
