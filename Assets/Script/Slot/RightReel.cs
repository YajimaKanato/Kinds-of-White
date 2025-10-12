using UnityEngine;
using UnityEngine.UI;

public class RightReel : ReelBase
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        RightReelUpdate();
    }

    public void RightReelUpdate()
    {
        _slot.MoveRightReel(_image1, 3);
        _slot.MoveRightReel(_image2, 2);
        _slot.MoveRightReel(_image3, 1);
        _slot.MoveRightReel(_image4, 0);
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
