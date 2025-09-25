using UnityEngine;
using UnityEngine.UI;

public class TypingMemory : MonoBehaviour
{
    [SerializeField] int _index;
    [SerializeField] Text _mem1Text;
    [SerializeField] Text _mem2Text;
    [SerializeField] Text _mem3Text;
    [SerializeField] Text _mem4Text;
    [SerializeField] Text _mem5Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mem1Text.text = "1 : 00000";
        _mem2Text.text = "2 : 00000";
        _mem3Text.text = "3 : 00000";
        _mem4Text.text = "4 : 00000";
        _mem5Text.text = "5 : 00000";
        MemoryData mem = null;
        switch (_index)
        {
            case 0:
                mem = MemoriesManager.TypingEasyMemoriesLoad();
                break;
            case 1:
                mem = MemoriesManager.TypingNormalMemoriesLoad();
                break;
            case 2:
                mem = MemoriesManager.TypingHardMemoriesLoad();
                break;
        }
        if (mem != null)
        {
            _mem1Text.text = "1 : " + int.Parse(mem.Mem1).ToString("00000");
            _mem2Text.text = "2 : " + int.Parse(mem.Mem2).ToString("00000");
            _mem3Text.text = "3 : " + int.Parse(mem.Mem3).ToString("00000");
            _mem4Text.text = "4 : " + int.Parse(mem.Mem4).ToString("00000");
            _mem5Text.text = "5 : " + int.Parse(mem.Mem5).ToString("00000");
        }
    }
}
