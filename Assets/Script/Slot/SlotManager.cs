using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] ReelBase _rightRB, _centerRB, _leftRB;
    [SerializeField] Text _medalText;
    [SerializeField] Text _betText;

    List<int> _rightReel = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    List<int> _centerReel = new List<int>() { 1, 6, 3, 8, 4, 9, 2, 5, 7 };
    List<int> _leftReel = new List<int>() { 9, 7, 5, 3, 4, 6, 8, 1, 2 };
    List<string> _reelImage = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    Coroutine _coroutine;

    static int _rightIndex = 0, _centerIndex = 0, _leftIndex = 0;
    static int _bet = 3;
    int _currentMedal;
    int r, c, l;
    bool _stopRight = true, _stopCenter = true, _stopLeft = true;
    bool _isWinOrLose = true;

    private void Start()
    {
        _currentMedal = Medal.LoadMedal();
        _medalText.text = _currentMedal.ToString("0000");
        _betText.text = "賭ける枚数 : " + _bet.ToString();
        _stopRight = true;
        _stopCenter = true;
        _stopLeft = true;
        _isWinOrLose = true;
    }

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
    /// リールの回転を停止させる関数
    /// </summary>
    /// <param name="num">停止させるリールの番号（左から0,1,2）</param>
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

        if (_stopRight && _stopCenter && _stopLeft && !_isWinOrLose)
        {
            WinOrLose();
        }
    }

    /// <summary>
    /// リールを回転させる関数
    /// </summary>
    public void StartReel()
    {
        //すべてのリールが止まってるときにリール回転開始
        if (_stopRight && _stopCenter && _stopLeft)
        {
            _stopRight = false;
            _stopCenter = false;
            _stopLeft = false;
            _isWinOrLose = false;
            _rightRB.MoveReel(_stopRight);
            _centerRB.MoveReel(_stopCenter);
            _leftRB.MoveReel(_stopLeft);
            _currentMedal -= _bet;
            _medalText.text = _currentMedal.ToString("0000");
        }
    }

    /// <summary>
    /// 当たりを判定する関数
    /// </summary>
    void WinOrLose()
    {
        _isWinOrLose = true;
        Debug.Log($"{l},{c},{r}");

        if (r * c * l == 7 * 7 * 7)
        {
            Debug.Log("ラッキーセブン");
        }
        else if (r == c && c == l)
        {
            Debug.Log("ぞろ目揃い");
        }
        else if (r + c + l == 3 * c)
        {
            Debug.Log("連番揃い");
        }
        else if (r * c * l % 2 == 1)
        {
            Debug.Log("奇数揃い");
        }
        else if (r % 2 == 0 && c % 2 == 0 && l % 2 == 0)
        {
            Debug.Log("偶数揃い");
        }
        else
        {
            Debug.Log("ハズレ");
        }
    }

    public void Bet(int bet)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(BetCoroutine(bet));
        }
    }

    public void ButtonUp()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    IEnumerator BetCoroutine(int bet)
    {
        _bet += bet;
        if (_bet <= 0)
        {
            _bet = 1;
        }
        _betText.text = "賭ける枚数 : " + _bet.ToString();
        yield return new WaitForSeconds(0.3f);
        _bet += bet;
        if (_bet <= 0)
        {
            _bet = 1;
        }
        _betText.text = "賭ける枚数 : " + _bet.ToString();
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            _bet += bet;
            if (_bet <= 0)
            {
                _bet = 1;
            }
            _betText.text = "賭ける枚数 : " + _bet.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SaveMedal()
    {
        Medal.SaveMedal(_currentMedal);
    }
}
