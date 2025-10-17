using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class SlotManager : MonoBehaviour
{
    [SerializeField] ReelBase _rightRB, _centerRB, _leftRB;
    [SerializeField] GameObject _rightCover, _centerCover, _leftCover;
    [SerializeField] Text _medalText;
    [SerializeField] Text _betText;
    [SerializeField] EventText _eventText;
    [SerializeField] Image _up, _down;

    List<int> _rightReel = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
    List<int> _centerReel = new List<int>() { 1, 6, 3, 4, 2, 5, 7 };
    List<int> _leftReel = new List<int>() { 7, 5, 3, 4, 6, 1, 2 };
    List<Whites> _reelColor = new List<Whites>() { Whites.FFFFFF, Whites.FBFBFB, Whites.F7F7F7, Whites.F3F3F3, Whites.EFEFEF, Whites.EBEBEB, Whites.E7E7E7 };
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
        _medalText.text = _currentMedal.ToString();
        _betText.text = "BET\n" + _bet.ToString();
        _up.color = Color.white;
        _down.color = Color.clear;
        _stopRight = true;
        _stopCenter = true;
        _stopLeft = true;
        _isWinOrLose = true;
    }

    public void MoveRightReel(Image image, int diff)
    {
        image.color = WhiteManager.White[_reelColor[_rightReel[(_rightIndex + diff) % _rightReel.Count] - 1]];
    }

    public void RightIndexNext()
    {
        _rightIndex++;
        _rightIndex %= _rightReel.Count;
    }

    public void MoveCenterReel(Image image, int diff)
    {
        image.color = WhiteManager.White[_reelColor[_centerReel[(_centerIndex + diff) % _centerReel.Count] - 1]];
    }

    public void CenterIndexNext()
    {
        _centerIndex++;
        _centerIndex %= _centerReel.Count;
    }

    public void MoveLeftReel(Image image, int diff)
    {
        image.color = WhiteManager.White[_reelColor[_leftReel[(_leftIndex + diff) % _leftReel.Count] - 1]];
    }

    public void LeftIndexNext()
    {
        _leftIndex++;
        _leftIndex %= _leftReel.Count;
    }

    /// <summary>
    /// ÉäÅ[ÉãÇÃâÒì]Çí‚é~Ç≥ÇπÇÈä÷êî
    /// </summary>
    /// <param name="num">í‚é~Ç≥ÇπÇÈÉäÅ[ÉãÇÃî‘çÜÅiç∂Ç©ÇÁ0,1,2Åj</param>
    public void StopReel(int num)
    {
        SEManager.SEPlay("ReelStop");
        switch (num)
        {
            case 0:
                _rightCover.SetActive(true);
                r = _rightReel[(_rightIndex + 1) % _rightReel.Count];
                _rightRB.StopReel(true);
                break;
            case 1:
                _centerCover.SetActive(true);
                c = _centerReel[(_centerIndex + 1) % _centerReel.Count];
                _centerRB.StopReel(true);
                break;
            case 2:
                _leftCover.SetActive(true);
                l = _leftReel[(_leftIndex + 1) % _leftReel.Count];
                _leftRB.StopReel(true);
                break;
        }
    }

    public void SetRightFlag()
    {
        _stopRight = true;
    }

    public void SetCenterFlag()
    {
        _stopCenter = true;
    }

    public void SetLeftFlag()
    {
        _stopLeft = true;
    }

    /// <summary>
    /// ÉäÅ[ÉãÇâÒì]Ç≥ÇπÇÈä÷êî
    /// </summary>
    public void StartReel()
    {
        //Ç∑Ç◊ÇƒÇÃÉäÅ[ÉãÇ™é~Ç‹Ç¡ÇƒÇÈÇ∆Ç´Ç…ÉäÅ[ÉãâÒì]äJén
        if (_stopRight && _stopCenter && _stopLeft && _currentMedal > 0)
        {
            _stopRight = false;
            _stopCenter = false;
            _stopLeft = false;
            _rightCover.SetActive(false);
            _centerCover.SetActive(false);
            _leftCover.SetActive(false);
            _isWinOrLose = false;
            _rightRB.MoveReel(_stopRight);
            _centerRB.MoveReel(_stopCenter);
            _leftRB.MoveReel(_stopLeft);
            _up.color = Color.clear;
            _down.color = Color.white;
            SEManager.SEPlay("LeverDown");
            SEManager.SEPlay("InCoin");
            SEManager.SEPlay("ReelStart");
            StartCoroutine(MedalCoroutine(_bet, false));
        }
    }

    /// <summary>
    /// ìñÇΩÇËÇîªíËÇ∑ÇÈä÷êî
    /// </summary>
    public void WinOrLose()
    {
        if (_stopRight && _stopCenter && _stopLeft && !_isWinOrLose)
        {

            _isWinOrLose = true;
            _up.color = Color.white;
            _down.color = Color.clear;

            var medal = _bet;
            if (r == c && c == l)
            {
                medal *= 50;
                _eventText.ThreeMatch();
                Debug.Log("ÇRêFëµÇ¢");
            }
            else if (r == c || c == l || l == r)
            {
                medal *= 3;
                _eventText.TwoMatch();
                Debug.Log("ÇQêFëµÇ¢");
            }
            else
            {
                medal = 0;
                _eventText.NoMatch();
                Debug.Log("ÉnÉYÉå");
            }
            Debug.Log($"{l},{c},{r}");

            StartCoroutine(MedalCoroutine(medal, true));
        }
    }

    IEnumerator MedalCoroutine(int diff, bool upordown)
    {
        if (diff != 0)
        {
            WaitForSeconds wait;
            if (diff >= 10)
            {
                wait = new WaitForSeconds(0.6f / diff);
            }
            else
            {
                wait = new WaitForSeconds(0.1f);
            }
            if (upordown)
            {
                int i = 0;
                while (true)
                {
                    if (i < diff)
                    {
                        _currentMedal++;
                        _medalText.text = _currentMedal.ToString();
                        yield return wait;
                    }
                    else
                    {
                        yield break;
                    }
                    i++;
                }
            }
            else
            {
                int i = 0;
                while (true)
                {
                    if (i < diff)
                    {
                        _currentMedal--;
                        _medalText.text = _currentMedal.ToString();
                        yield return wait;
                    }
                    else
                    {
                        yield break;
                    }
                    i++;
                }
            }
        }

        yield break;
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
        if (_bet >= _currentMedal)
        {
            _bet = _currentMedal;
        }
        _betText.text = "BET\n" + _bet.ToString();
        SEManager.SEPlay("Bet");
        yield return new WaitForSeconds(0.3f);
        _bet += bet;
        if (_bet <= 0)
        {
            _bet = 1;
        }
        if (_bet >= _currentMedal)
        {
            _bet = _currentMedal;
        }
        _betText.text = "BET\n" + _bet.ToString();
        SEManager.SEPlay("Bet");
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            _bet += bet;
            if (_bet <= 0)
            {
                _bet = 1;
            }
            if (_bet >= _currentMedal)
            {
                _bet = _currentMedal;
            }
            _betText.text = "BET\n" + _bet.ToString();
            SEManager.SEPlay("Bet");
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void SaveMedal()
    {
        Medal.SaveMedal(_currentMedal);
    }
}
