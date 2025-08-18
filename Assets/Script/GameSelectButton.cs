using UnityEngine;
using System.Collections.Generic;

public class GameSelectButton : MonoBehaviour
{
    [SerializeField] List<GameObject> _gameSelectList;
    [SerializeField] Vector3 _defaultPos;
    [SerializeField] float _space = 650;
    [SerializeField] List<Animator> _animators;

    int _selectIndex;
    int _nowSelectIndex = 0;

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
            count++;
        }
    }

    public void RightChange()
    {
        if (_nowSelectIndex < _selectIndex - 1)
        {
            for (int i = 0; i < _selectIndex; i++)
            {
                _gameSelectList[i].transform.localPosition = new Vector3(_gameSelectList[i].transform.localPosition.x, _defaultPos.y, _gameSelectList[i].transform.localPosition.z);
                _animators[i].Play("GameSelectLeft");
            }
            _nowSelectIndex++;
        }
    }

    public void LeftChange()
    {
        if (_nowSelectIndex > 0)
        {
            for (int i = 0; i < _selectIndex; i++)
            {
                _gameSelectList[i].transform.localPosition = new Vector3(_gameSelectList[i].transform.localPosition.x, _defaultPos.y, _gameSelectList[i].transform.localPosition.z);
                _animators[i].Play("GameSelectRight");
            }
            _nowSelectIndex--;
        }
    }
}
