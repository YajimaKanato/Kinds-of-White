using System;
using UnityEngine;
using UnityEngine.UI;
using WhitePalette;

public class WhiteDropDown : MonoBehaviour
{
    [SerializeField] SpriteRenderer _whiteobj;

    Dropdown _dropDown;

    private void Start()
    {
        DropDownSetting();
    }

    void DropDownSetting()
    {
        _dropDown = GetComponent<Dropdown>();
        foreach (var white in Enum.GetValues(typeof(Whites)))
        {
            _dropDown.options.Add(new Dropdown.OptionData(white.ToString()));
        }
        _dropDown.RefreshShownValue();
    }

    public void ColorChange()
    {
        foreach (var white in Enum.GetValues(typeof(Whites)))
        {
            if ((int)white == _dropDown.value)
            {
                Debug.Log(((Whites)white).ToString());
                _whiteobj.color = WhiteManager.White[(Whites)white];
                break;
            }
        }
    }
}
