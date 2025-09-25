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
        _mem1Text.text = "1 : 連続 0 回";
        _mem2Text.text = "2 : 連続 0 回";
        _mem3Text.text = "3 : 連続 0 回";
        _mem4Text.text = "4 : 連続 0 回";
        _mem5Text.text = "5 : 連続 0 回";
        var mem = MemoriesManager.SecurityMemoriesLoad();
        if (mem != null)
        {
            _mem1Text.text = "1 : 連続 "+mem.Mem1.ToString()+" 回";
            _mem2Text.text = "2 : 連続 "+mem.Mem2.ToString()+" 回";
            _mem3Text.text = "3 : 連続 "+mem.Mem3.ToString()+" 回";
            _mem4Text.text = "4 : 連続 "+mem.Mem4.ToString()+" 回";
            _mem5Text.text = "5 : 連続 "+mem.Mem5.ToString()+" 回";
        }
    }
}
