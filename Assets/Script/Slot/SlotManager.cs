using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] ReelBase _rightRB, _centerRB, _leftRB;

    List<int> _rightReel = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    List<int> _centerReel = new List<int>() { 1, 6, 3, 8, 4, 9, 2, 5, 7 };
    List<int> _leftReel = new List<int>() { 9, 7, 5, 3, 4, 6, 8, 1, 2 };
    List<string> _reelImage = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    static int _rightIndex = 0, _centerIndex = 0, _leftIndex = 0;
    int r, c, l;
    bool _stopRight, _stopCenter, _stopLeft;

    public void MoveRightReel(Text text, int diff)
    {
        text.text = _reelImage[_rightReel[(_rightIndex + diff) % _rightReel.Count] - 1];
    }

    public void RightIndexNext()
    {
        _rightIndex++;
        _rightIndex %= _rightReel.Count;
    }

    public void MoveCenterReel(Text text, int diff)
    {
        text.text = _reelImage[_centerReel[(_centerIndex + diff) % _centerReel.Count] - 1];
    }

    public void CenterIndexNext()
    {
        _centerIndex++;
        _centerIndex %= _centerReel.Count;
    }

    public void MoveLeftReel(Text text, int diff)
    {
        text.text = _reelImage[_leftReel[(_leftIndex + diff) % _leftReel.Count] - 1];
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
                r = _rightReel[(_rightIndex + 1) % _rightReel.Count];
                _rightRB.StopReel(_stopRight);
                break;
            case 1:
                _stopCenter = true;
                c = _centerReel[(_centerIndex + 1) % _centerReel.Count];
                _centerRB.StopReel(_stopCenter);
                break;
            case 2:
                _stopLeft = true;
                l = _leftReel[(_leftIndex + 1) % _leftReel.Count];
                _leftRB.StopReel(_stopLeft);
                break;
        }

        if (_stopRight && _stopCenter && _stopLeft)
        {
            WinOrLose();
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

    /// <summary>
    /// ������𔻒肷��֐�
    /// </summary>
    void WinOrLose()
    {
        Debug.Log($"{l},{c},{r}");

        if (r * c * l == 7 * 7 * 7)
        {
            Debug.Log("���b�L�[�Z�u��");
        }
        else if (r == c && c == l)
        {
            Debug.Log("����ڑ���");
        }
        else if (r + c + l == 3 * c)
        {
            Debug.Log("�A�ԑ���");
        }
        else if (r * c * l % 2 == 1)
        {
            Debug.Log("�����");
        }
        else if (r % 2 == 0 && c % 2 == 0 && l % 2 == 0)
        {
            Debug.Log("��������");
        }
        else
        {
            Debug.Log("�n�Y��");
        }
    }
}
