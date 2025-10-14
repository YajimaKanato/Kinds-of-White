using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    static BGM _instance;
    static AudioMixer _audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
            _audioMixer = _mixer;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// BGMの大きさを変更する関数
    /// </summary>
    /// <param name="slider"> 音量を変更するときに使用しているスライダー</param>
    public static void MixerSetting(float value)
    {
        _audioMixer.SetFloat("BGM", value);
    }
}
