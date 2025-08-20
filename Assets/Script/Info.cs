using System.Collections;
using UnityEngine;

public class Info : MonoBehaviour
{
    Coroutine _openCoroutine;
    Coroutine _closeCoroutine;
    Timer _timer;

    Vector3 _defaultScale;

    float _maxScale = 1.0f;
    float _minScale = 0.1f;

    const float SCALETIME = 0.5f;

    private void Awake()
    {
        _timer = FindFirstObjectByType<Timer>();
        _defaultScale = transform.localScale;
        Debug.Log(_defaultScale);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if( _timer != null)
        {
            _timer.IsEnd = true;
        }
        if (_openCoroutine == null)
        {
            _openCoroutine = StartCoroutine(OpenCoroutine());
        }
    }

    private void OnDisable()
    {
        if (_openCoroutine != null)
        {
            StopCoroutine(_openCoroutine);
            _openCoroutine = null;
        }
    }

    public void Close()
    {
        if (_closeCoroutine != null)
        {
            StopCoroutine(_closeCoroutine);
            _closeCoroutine = null;
        }
        _closeCoroutine = StartCoroutine(CloseCoroutine());
    }

    IEnumerator OpenCoroutine()
    {
        float delta = 0;
        float scaleDelta = _maxScale - _minScale;
        while (true)
        {
            delta += Time.deltaTime;
            transform.localScale = _defaultScale * (_minScale + scaleDelta * delta / SCALETIME);
            if (delta > SCALETIME)
            {
                transform.localScale = _defaultScale * _maxScale;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator CloseCoroutine()
    {
        float delta = 0;
        float scaleDelta = _minScale - _maxScale;
        while (true)
        {
            delta += Time.deltaTime;
            transform.localScale = _defaultScale * (_maxScale + scaleDelta * delta / SCALETIME);
            if (delta > SCALETIME)
            {
                transform.localScale = _defaultScale * _minScale;
                gameObject.SetActive(false);
                if(_timer != null)
                {
                    _timer.IsEnd = false;
                }
                yield break;
            }
            yield return null;
        }
    }
}
