using UnityEngine;
using UnityEngine.UI;

public class SecurityMemory : MonoBehaviour
{
    [SerializeField] Text _mem1Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mem1Text.text = "Å‘å˜A‘±‰ñ”\n\n0 ‰ñ";
        var mem = MemoriesManager.SecurityMemoriesLoad();
        if (mem != null)
        {
            _mem1Text.text = "Å‘å˜A‘±‰ñ”\n\n"+mem.Mem1.ToString()+" ‰ñ";
        }
    }
}
