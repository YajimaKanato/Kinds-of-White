using UnityEngine;
using UnityEngine.UI;

public class BGMScroll : MonoBehaviour
{
    Scrollbar _scroll;
    float _size;

    private void Start()
    {
        _scroll = GetComponent<Scrollbar>();
        _size = _scroll.size;
    }

    public void ValueUpdate()
    {
        if (_scroll.value <= 0)
        {
            _scroll.value = 0;
        }
        if (_scroll.value >= 1)
        {
            _scroll.value = 1;
        }
        _scroll.size = _size;
    }
}
