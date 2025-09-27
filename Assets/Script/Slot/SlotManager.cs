using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] ReelBase _rightRB, _centerRB, _leftRB;

    List<int> _rightReel = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    List<int> _centerReel = new List<int>() { 1, 6, 3, 8, 0, 4, 9, 13, 2, 5, 10, 12, 7, 11 };
    List<int> _leftReel = new List<int>() { 9, 7, 5, 3, 4, 6, 8, 13, 0, 12, 11, 10, 1, 2 };
    List<string> _reelImage = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    static int _rightIndex, _centerIndex, _leftIndex;
    bool _stopRight, _stopCenter, _stopLeft;

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

    /// <summary>
    /// ���[���̉�]���~������֐�
    /// </summary>
    /// <param name="num">��~�����郊�[���̔ԍ��i������0,1,2�j</param>
    public void StopReel(int num)
    {
        switch (num)
        {
            case 0:
                _stopRight = true;
                _rightRB.StopReel(_stopRight);
                break;
            case 1:
                _stopCenter = true;
                _centerRB.StopReel(_stopCenter);
                break;
            case 2:
                _stopLeft = true;
                _leftRB.StopReel(_stopLeft);
                break;
        }
    }

    /// <summary>
    /// ���[������]������֐�
    /// </summary>
    public void StartReel()
    {
        //���ׂẴ��[�����~�܂��Ă�Ƃ��Ƀ��[����]�J�n
        if (_stopRight && _stopCenter && _stopLeft)
        {
            _stopRight = false;
            _stopCenter = false;
            _stopLeft = false;
            _rightRB.MoveReel(_stopRight);
            _centerRB.MoveReel(_stopCenter);
            _leftRB.MoveReel(_stopLeft);
        }
    }
}
