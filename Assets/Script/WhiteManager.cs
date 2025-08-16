using System;
using System.Collections.Generic;
using UnityEngine;
using WhitePalette;

public class WhiteManager : MonoBehaviour
{
    [SerializeField] int _step = 2;

    static WhiteManager _instance;

    static Dictionary<Whites, Color32> _white;
    /// <summary>カラーコードとその色をペアにする辞書</summary>
    public static Dictionary<Whites, Color32> White { get { return _white; } }

    Whites _whites;

    const int RED_WHITE = 255;
    const int GREEN_WHITE = 255;
    const int BLUE_WHITE = 255;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //シングルトン処理
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            MakeWhite();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 白を216色作る関数
    /// </summary>
    void MakeWhite()
    {
        _white = new Dictionary<Whites, Color32>();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 6; k++)
                {
                    foreach (var white in Enum.GetValues(typeof(Whites)))
                    {
                        if ((int)white == 36 * i + 6 * j + k)
                        {
                            _whites = (Whites)white;
                            break;
                        }
                    }
                    _white.Add(_whites, new Color32((byte)(RED_WHITE - i * _step), (byte)(GREEN_WHITE - j * _step), (byte)(BLUE_WHITE - k * _step), 255));
                }
            }
        }
    }
}

namespace WhitePalette
{
    public enum Whites
    {
        FFFFFF,
        FFFFFE,
        FFFFFD,
        FFFFFC,
        FFFFFB,
        FFFFFA,
        FFFEFF,
        FFFEFE,
        FFFEFD,
        FFFEFC,
        FFFEFB,
        FFFEFA,
        FFFDFF,
        FFFDFE,
        FFFDFD,
        FFFDFC,
        FFFDFB,
        FFFDFA,
        FFFCFF,
        FFFCFE,
        FFFCFD,
        FFFCFC,
        FFFCFB,
        FFFCFA,
        FFFBFF,
        FFFBFE,
        FFFBFD,
        FFFBFC,
        FFFBFB,
        FFFBFA,
        FFFAFF,
        FFFAFE,
        FFFAFD,
        FFFAFC,
        FFFAFB,
        FFFAFA,
        FEFFFF,
        FEFFFE,
        FEFFFD,
        FEFFFC,
        FEFFFB,
        FEFFFA,
        FEFEFF,
        FEFEFE,
        FEFEFD,
        FEFEFC,
        FEFEFB,
        FEFEFA,
        FEFDFF,
        FEFDFE,
        FEFDFD,
        FEFDFC,
        FEFDFB,
        FEFDFA,
        FEFCFF,
        FEFCFE,
        FEFCFD,
        FEFCFC,
        FEFCFB,
        FEFCFA,
        FEFBFF,
        FEFBFE,
        FEFBFD,
        FEFBFC,
        FEFBFB,
        FEFBFA,
        FEFAFF,
        FEFAFE,
        FEFAFD,
        FEFAFC,
        FEFAFB,
        FEFAFA,
        FDFFFF,
        FDFFFE,
        FDFFFD,
        FDFFFC,
        FDFFFB,
        FDFFFA,
        FDFEFF,
        FDFEFE,
        FDFEFD,
        FDFEFC,
        FDFEFB,
        FDFEFA,
        FDFDFF,
        FDFDFE,
        FDFDFD,
        FDFDFC,
        FDFDFB,
        FDFDFA,
        FDFCFF,
        FDFCFE,
        FDFCFD,
        FDFCFC,
        FDFCFB,
        FDFCFA,
        FDFBFF,
        FDFBFE,
        FDFBFD,
        FDFBFC,
        FDFBFB,
        FDFBFA,
        FDFAFF,
        FDFAFE,
        FDFAFD,
        FDFAFC,
        FDFAFB,
        FDFAFA,
        FCFFFF,
        FCFFFE,
        FCFFFD,
        FCFFFC,
        FCFFFB,
        FCFFFA,
        FCFEFF,
        FCFEFE,
        FCFEFD,
        FCFEFC,
        FCFEFB,
        FCFEFA,
        FCFDFF,
        FCFDFE,
        FCFDFD,
        FCFDFC,
        FCFDFB,
        FCFDFA,
        FCFCFF,
        FCFCFE,
        FCFCFD,
        FCFCFC,
        FCFCFB,
        FCFCFA,
        FCFBFF,
        FCFBFE,
        FCFBFD,
        FCFBFC,
        FCFBFB,
        FCFBFA,
        FCFAFF,
        FCFAFE,
        FCFAFD,
        FCFAFC,
        FCFAFB,
        FCFAFA,
        FBFFFF,
        FBFFFE,
        FBFFFD,
        FBFFFC,
        FBFFFB,
        FBFFFA,
        FBFEFF,
        FBFEFE,
        FBFEFD,
        FBFEFC,
        FBFEFB,
        FBFEFA,
        FBFDFF,
        FBFDFE,
        FBFDFD,
        FBFDFC,
        FBFDFB,
        FBFDFA,
        FBFCFF,
        FBFCFE,
        FBFCFD,
        FBFCFC,
        FBFCFB,
        FBFCFA,
        FBFBFF,
        FBFBFE,
        FBFBFD,
        FBFBFC,
        FBFBFB,
        FBFBFA,
        FBFAFF,
        FBFAFE,
        FBFAFD,
        FBFAFC,
        FBFAFB,
        FBFAFA,
        FAFFFF,
        FAFFFE,
        FAFFFD,
        FAFFFC,
        FAFFFB,
        FAFFFA,
        FAFEFF,
        FAFEFE,
        FAFEFD,
        FAFEFC,
        FAFEFB,
        FAFEFA,
        FAFDFF,
        FAFDFE,
        FAFDFD,
        FAFDFC,
        FAFDFB,
        FAFDFA,
        FAFCFF,
        FAFCFE,
        FAFCFD,
        FAFCFC,
        FAFCFB,
        FAFCFA,
        FAFBFF,
        FAFBFE,
        FAFBFD,
        FAFBFC,
        FAFBFB,
        FAFBFA,
        FAFAFF,
        FAFAFE,
        FAFAFD,
        FAFAFC,
        FAFAFB,
        FAFAFA,
    }
}
