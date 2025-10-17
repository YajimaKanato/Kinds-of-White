using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MedalText : MonoBehaviour
{
    Text _medalText;
    Coroutine _coroutine;
    int _currentMedal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentMedal = Medal.LoadMedal();
        _medalText = GetComponent<Text>();
        _medalText.text = _currentMedal.ToString();
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void MedalUp(int diff)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(MedalCoroutine(diff));
        }
    }

    IEnumerator MedalCoroutine(int diff)
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

        yield break;
    }
}
