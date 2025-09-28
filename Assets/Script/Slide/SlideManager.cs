using UnityEngine;
using System.Collections.Generic;
using WhitePalette;
using System;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    [SerializeField] GameObject _filter;
    [SerializeField] List<SlideAnswer> _slideAnswerList;
    [SerializeField] Slide[] _slide;
    [SerializeField] Text _text;
    [SerializeField] int _getMedalAmount = 5000;
    List<Whites> _answerWhiteList = new List<Whites>();
    List<Slide> _selectSlide = new List<Slide>();
    List<int> _selectIndex = new List<int>();

    int _slideCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _filter.SetActive(false);
        _text.text = "";
        SlideSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SlideSetting()
    {
        _slideCount = _slideAnswerList.Count;
        Debug.Log(_slideCount);
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
            if (count >= _slideCount * 2) break;
        }

        List<int> ints = new List<int>();
        for (int i = 0; i < _slideCount; i++)
        {
            ints.Add(i);
        }

        if (_slide.Length == _slideAnswerList.Count)
        {
            for (int i = 0; i < _answerWhiteList.Count; i++)
            {
                rand = UnityEngine.Random.Range(0, ints.Count);
                _slide[ints[rand]].Whites = _answerWhiteList[i];
                _slide[ints[rand]].WhiteType = WhiteManager.White[_answerWhiteList[i]];
                _slideAnswerList[i].Whites = _answerWhiteList[i];
                _slideAnswerList[i].WhiteType = WhiteManager.White[_answerWhiteList[i]];
                ints.RemoveAt(rand);
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
            Vector3 pos1 = _selectSlide[0].gameObject.transform.localPosition;
            Vector3 pos2 = _selectSlide[1].gameObject.transform.localPosition;
            _selectSlide[0].PositionChange(pos2);
            _selectSlide[1].PositionChange(pos1);
            _selectSlide.Clear();

            if (_selectIndex[0] != -1 && _selectIndex[1] != -1)
            {
                Slide s1 = _slide[_selectIndex[0]];
                Slide s2 = _slide[_selectIndex[1]];
                _slide[_selectIndex[0]] = s2;
                _slide[_selectIndex[1]] = s1;
                _selectIndex.Clear();
            }

            bool isAllMatch = true;
            for (int i = 0; i < _slideCount; i++)
            {
                Debug.Log($"{_slide[i].Whites.ToString()} : {_answerWhiteList[i].ToString()}");
                if (_slide[i].Whites != _answerWhiteList[i])
                {
                    isAllMatch = false;
                    break;
                }
            }

            if (isAllMatch)
            {
                GetComponent<Timer>().IsEnd = true;
                _text.text = "Nice White!!";
                Medal.SaveMedal(Medal.LoadMedal() + _getMedalAmount);
                _filter.SetActive(true);
            }
        }
        else
        {
            _selectSlide[0].UnSelect();
            _selectSlide[1].UnSelect();
            _selectSlide.Clear();
            _selectIndex.Clear();
        }
    }
}
