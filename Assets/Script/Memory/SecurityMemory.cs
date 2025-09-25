using UnityEngine;
using UnityEngine.UI;

public class SecurityMemory : MonoBehaviour
{
    [SerializeField] Text _mem1Text;
    [SerializeField] Text _mem2Text;
    [SerializeField] Text _mem3Text;
    [SerializeField] Text _mem4Text;
    [SerializeField] Text _mem5Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mem1Text.text = "1 : �A�� 0 ��";
        _mem2Text.text = "2 : �A�� 0 ��";
        _mem3Text.text = "3 : �A�� 0 ��";
        _mem4Text.text = "4 : �A�� 0 ��";
        _mem5Text.text = "5 : �A�� 0 ��";
        var mem = MemoriesManager.SecurityMemoriesLoad();
        if (mem != null)
        {
            _mem1Text.text = "1 : �A�� "+mem.Mem1.ToString()+" ��";
            _mem2Text.text = "2 : �A�� "+mem.Mem2.ToString()+" ��";
            _mem3Text.text = "3 : �A�� "+mem.Mem3.ToString()+" ��";
            _mem4Text.text = "4 : �A�� "+mem.Mem4.ToString()+" ��";
            _mem5Text.text = "5 : �A�� "+mem.Mem5.ToString()+" ��";
        }
    }
}
