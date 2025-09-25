using UnityEngine;
using UnityEngine.UI;

public class CenterReel : MonoBehaviour
{
    [SerializeField] Text _text1, _text2, _text3, _text4;
    [SerializeField] SlotManager _slot;

    public void Move()
    {
        _slot.MoveCenterReel(_text1, 3);
        _slot.MoveCenterReel(_text2, 2);
        _slot.MoveCenterReel(_text3, 1);
        _slot.MoveCenterReel(_text4, 0);
        _slot.CenterIndexNext();
    }
}
