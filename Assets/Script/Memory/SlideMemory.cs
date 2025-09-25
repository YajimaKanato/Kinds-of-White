using UnityEngine;
using UnityEngine.UI;

public class SlideMemory : MonoBehaviour
{
    [SerializeField] Text _mem1Text;
    [SerializeField] Text _mem2Text;
    [SerializeField] Text _mem3Text;
    [SerializeField] Text _mem4Text;
    [SerializeField] Text _mem5Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mem1Text.text = "1 : 00:00:00";
        _mem2Text.text = "2 : 00:00:00";
        _mem3Text.text = "3 : 00:00:00";
        _mem4Text.text = "4 : 00:00:00";
        _mem5Text.text = "5 : 00:00:00";
        var mem = MemoriesManager.SlideMemoriesLoad();
        if (mem != null)
        {
            _mem1Text.text = "1 : " + mem.Mem1;
            _mem2Text.text = "2 : " + mem.Mem2;
            _mem3Text.text = "3 : " + mem.Mem3;
            _mem4Text.text = "4 : " + mem.Mem4;
            _mem5Text.text = "5 : " + mem.Mem5;
        }
    }
}
