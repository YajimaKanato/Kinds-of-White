using UnityEngine;
using UnityEngine.UI;

public class CenterReel : ReelBase
{
    Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        CenterReelUpdate();
    }

    public void CenterReelUpdate()
    {
        _slot.MoveCenterReel(_image1, 3);
        _slot.MoveCenterReel(_image2, 2);
        _slot.MoveCenterReel(_image3, 1);
        _slot.MoveCenterReel(_image4, 0);
        _slot.CenterIndexNext();
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
