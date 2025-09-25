using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] Text _rightText, _centerText, _leftText;
    [SerializeField] float _rightReelInterval = 0.5f;
    [SerializeField] float _centerReelInterval = 0.7f;
    [SerializeField] float _leftReelInterval = 0.3f;

    List<int> _rightReel = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    List<int> _centerReel = new List<int>() { 1, 6, 3, 8, 0, 4, 9, 13, 2, 5, 10, 12, 7, 11 };
    List<int> _leftReel = new List<int>() { 9, 7, 5, 3, 4, 6, 8, 13, 0, 12, 11, 10, 1, 2 };
    List<string> _reelImage = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    int _rightIndex, _centerIndex, _leftIndex;
    bool _stopRight, _stopCenter, _stopLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_stopRight && _stopCenter && _stopLeft)
        {
            RestartReel();
        }
    }

    public void MoveRightReel(Text text, int diff)
    {
        text.text = _reelImage[_rightReel[(_rightIndex + diff) % _rightReel.Count]];
    }

    public void RightIndexNext()
    {
        _rightIndex++;
        _rightIndex %= _rightReel.Count;
    }

    public void MoveCenterReel(Text text, int diff)
    {
        text.text = _reelImage[_centerReel[(_centerIndex + diff) % _centerReel.Count]];
    }

    public void CenterIndexNext()
    {
        _centerIndex++;
        _centerIndex %= _centerReel.Count;
    }

    public void MoveLeftReel(Text text, int diff)
    {
        text.text = _reelImage[_leftReel[(_leftIndex + diff) % _leftReel.Count]];
    }

    public void LeftIndexNext()
    {
        _leftIndex++;
        _leftIndex %= _leftReel.Count;
    }

    public void StopReel(int pos)
    {
        switch (pos)
        {
            case 0:
                _stopRight = true;
                break;
            case 1:
                _stopCenter = true;
                break;
            case 2:
                _stopLeft = true;
                break;
        }
    }

    void RestartReel()
    {
        _stopRight = _stopCenter = _stopLeft = false;
    }
}
