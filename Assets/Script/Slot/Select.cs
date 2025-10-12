using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    [SerializeField] List<GameObject> _list;
    [SerializeField] Text _text;
    static int _index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in _list)
        {
            item.SetActive(false);
        }
        _list[_index].SetActive(true);
        _text.text = (_index + 1) + " / " + _list.Count;
    }

    public void RightSelect()
    {
        SEManager.SEPlay("SelectButton");
        _list[_index].SetActive(false);
        _index++;
        _index %= _list.Count;
        _list[_index].SetActive(true);
        _text.text = (_index + 1) + " / " + _list.Count;
    }

    public void LeftSelect()
    {
        SEManager.SEPlay("SelectButton");
        _list[_index].SetActive(false);
        _index--;
        if (_index < 0) _index = _list.Count - 1;
        _list[_index].SetActive(true);
        _text.text = (_index + 1) + " / " + _list.Count;
    }
}
