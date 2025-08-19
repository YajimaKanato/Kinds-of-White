using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSelectButton : MonoBehaviour
{
    [SerializeField] GameObject _dontToucth;
    [SerializeField] List<GameObject> _gameSelectList;
    [SerializeField] List<Animator> _animators;
    [SerializeField] Vector3 _defaultPos;
    [SerializeField] Vector3 _defaultScale;
    [SerializeField] float _space = 650;
    [SerializeField] float _maxScale = 1f;
    [SerializeField] float _minScale = 0.8f;

    int _selectIndex;
    int _nowSelectIndex = 0;
    bool _isChanging = false;
    const float ANIMATIONRANGE = 0.83f;
    const float EXTRA = 0.15f;

    private void Start()
    {
        GameSelectSetting();
    }

    void GameSelectSetting()
    {
        _selectIndex = _gameSelectList.Count;
        int count = 0;
        foreach (var gameSelect in _gameSelectList)
        {
            gameSelect.transform.localPosition = _defaultPos + new Vector3(_space * count, 0, 0);
            if (count != 0)
            {
                gameSelect.transform.localScale = _defaultScale * _minScale;
            }
            else
            {
                gameSelect.transform.localScale = _defaultScale * _maxScale;
            }
            count++;
        }
        _dontToucth.SetActive(false);
    }

    public void RightChange()
    {
        if (!_isChanging)
        {
            if (_nowSelectIndex < _selectIndex - 1)
            {
                for (int i = 0; i < _selectIndex; i++)
                {
                    _gameSelectList[i].transform.localPosition = new Vector3(_gameSelectList[i].transform.localPosition.x, _defaultPos.y, _gameSelectList[i].transform.localPosition.z);
                    StartCoroutine(LeftMoveCoroutine(_gameSelectList[i]));
                    if (i == _nowSelectIndex)
                    {
                        StartCoroutine(ScaleDownCoroutine(_gameSelectList[i]));
                    }
                    else if (i == _nowSelectIndex + 1)
                    {
                        StartCoroutine(ScaleUpCoroutine(_gameSelectList[i]));
                    }
                }
                _nowSelectIndex++;
            }
        }
    }

    public void LeftChange()
    {
        if (!_isChanging)
        {
            if (_nowSelectIndex > 0)
            {
                for (int i = 0; i < _selectIndex; i++)
                {
                    _gameSelectList[i].transform.localPosition = new Vector3(_gameSelectList[i].transform.localPosition.x, _defaultPos.y, _gameSelectList[i].transform.localPosition.z);
                    StartCoroutine(RightMoveCoroutine(_gameSelectList[i]));
                    if (i == _nowSelectIndex)
                    {
                        StartCoroutine(ScaleDownCoroutine(_gameSelectList[i]));
                    }
                    else if (i == _nowSelectIndex - 1)
                    {
                        StartCoroutine(ScaleUpCoroutine(_gameSelectList[i]));
                    }
                }
                _nowSelectIndex--;
            }
        }
    }

    IEnumerator RightMoveCoroutine(GameObject obj)
    {
        _dontToucth.SetActive(true);
        float delta = 0;
        Vector3 startPos = obj.transform.localPosition;
        Vector3 move = new Vector3(_space, 0, 0);
        while (true)
        {
            delta += Time.deltaTime / ANIMATIONRANGE;
            obj.transform.localPosition = startPos + move * delta;
            if (delta >= ANIMATIONRANGE + EXTRA)
            {
                obj.transform.localPosition = startPos + move;
                _dontToucth.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator LeftMoveCoroutine(GameObject obj)
    {
        _dontToucth.SetActive(true);
        float delta = 0;
        Vector3 startPos = obj.transform.localPosition;
        Vector3 move = new Vector3(_space, 0, 0);
        while (true)
        {
            delta += Time.deltaTime / ANIMATIONRANGE;
            obj.transform.localPosition = startPos - move * delta;
            if (delta > ANIMATIONRANGE + EXTRA)
            {
                obj.transform.localPosition = startPos - move;
                _dontToucth.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator ScaleUpCoroutine(GameObject obj)
    {
        float delta = 0;
        float scale = _minScale;
        while (true)
        {
            delta += Time.deltaTime / ANIMATIONRANGE;
            scale = _minScale + delta * Mathf.Abs(_maxScale - _minScale);
            obj.transform.localScale = _defaultScale * scale;
            if (delta > ANIMATIONRANGE + EXTRA)
            {
                obj.transform.localScale = _defaultScale * _maxScale;
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator ScaleDownCoroutine(GameObject obj)
    {
        float delta = 0;
        float scale = _maxScale;
        while (true)
        {
            delta += Time.deltaTime / ANIMATIONRANGE;
            scale = _maxScale - delta * Mathf.Abs(_maxScale - _minScale);
            obj.transform.localScale = _defaultScale * scale;
            if (delta >= ANIMATIONRANGE + EXTRA)
            {
                obj.transform.localScale = _defaultScale * _minScale;
                yield break;
            }
            yield return null;
        }
    }

    public void Changing()
    {
        if (!_isChanging)
        {
            StartCoroutine(ChangingCoroutine());
        }
    }

    IEnumerator ChangingCoroutine()
    {
        _isChanging = true;
        yield return new WaitForSeconds(0.9f);
        _isChanging = false;
        yield break;
    }
}
