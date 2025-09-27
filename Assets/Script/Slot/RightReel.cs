using UnityEngine;
using UnityEngine.UI;

public class RightReel : ReelBase
{
    [SerializeField] Text _text1, _text2, _text3, _text4;
    [SerializeField] SlotManager _slot;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        ReelUpdate();
    }

    public override void ReelUpdate()
    {
        _slot.MoveRightReel(_text1, 3);
        _slot.MoveRightReel(_text2, 2);
        _slot.MoveRightReel(_text3, 1);
        _slot.MoveRightReel(_text4, 0);
        _slot.RightIndexNext();
    }

    public override void MoveReel(bool stop)
    {
        _anim.speed = 1;
        _anim.SetBool("Stop", stop);
    }

    public override void StopReel(bool stop)
    {
        _anim.speed = 0.8f;
        _anim.SetBool("Stop", stop);
    }

}
