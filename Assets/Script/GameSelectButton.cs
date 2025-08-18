using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSelectButton : MonoBehaviour
{
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
            count++;
        }
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

                    if (i == _nowSelectIndex)
                    {
                        Debug.Log("ScaleDown");
                        _animators[i].Play("ScaleDownL");
                        StartCoroutine(ScaleDownCoroutine(_gameSelectList[i]));
                    }
                    else if (i == _nowSelectIndex + 1)
                    {
                        Debug.Log("ScaleUp");
                        _animators[i].Play("ScaleUpL");
                        StartCoroutine(ScaleUpCoroutine(_gameSelectList[i]));
                    }
                    else
                    {
                        _animators[i].Play("GameSelectLeft");
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

                    if (i == _nowSelectIndex)
                    {
                        Debug.Log("ScaleDown");
                        _animators[i].Play("ScaleDownR");
                        StartCoroutine(ScaleDownCoroutine(_gameSelectList[i]));
                    }
                    else if (i == _nowSelectIndex - 1)
                    {
                        Debug.Log("ScaleUp");
                        _animators[i].Play("ScaleUpR");
                        StartCoroutine(ScaleUpCoroutine(_gameSelectList[i]));
                    }
                    else
                    {
                        _animators[i].Play("GameSelectRight");
                    }
                }
                _nowSelectIndex--;
            }
        }
    }

    IEnumerator ScaleUpCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(0.9f);
        obj.transform.localScale = _defaultScale * _maxScale;
        yield break;
    }

    IEnumerator ScaleDownCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(0.9f);
        obj.transform.localScale = _defaultScale * _minScale;
        yield break;
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
