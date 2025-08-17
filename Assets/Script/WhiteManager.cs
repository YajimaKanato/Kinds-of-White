using System;
using System.Collections.Generic;
using UnityEngine;
using WhitePalette;

public class WhiteManager : MonoBehaviour
{
    static WhiteManager _instance;

    static Dictionary<Whites, Color32> _white;
    /// <summary>カラーコードとその色をペアにする辞書</summary>
    public static Dictionary<Whites, Color32> White { get { return _white; } }

    const int RED_WHITE = 255;
    const int GREEN_WHITE = 255;
    const int BLUE_WHITE = 255;
    const int WHITENUMBER = 169;
    /// <summary>白の個数</summary>
    public static int WhiteNumber { get { return WHITENUMBER; } }

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
    /// 白を作る関数
    /// </summary>
    void MakeWhite()
    {
        _white = new Dictionary<Whites, Color32>();

        for (int n = 0; n < 24; n++)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        if (i * j * k != 1)
                        {
                            _white.Add(
                                (Whites)Enum.ToObject(typeof(Whites), 7 * n + 2 * 2 * i + 2 * j + k),
                                new Color32((byte)(RED_WHITE - n - i), (byte)(GREEN_WHITE - n - j), (byte)(BLUE_WHITE - n - k), 255)
                                );
                        }
                    }
                }
            }
        }
        _white.Add(
            Whites.E7E7E7,
            new Color32((byte)(RED_WHITE - 25), (byte)(GREEN_WHITE - 25), (byte)(BLUE_WHITE - 25), 255)
            );
    }
}

namespace WhitePalette
{
    /// <summary>
    /// 白のカラーコード
    /// </summary>
    public enum Whites
    {
        //FFFF
        FFFFFF,
        FFFFFE,
        FFFEFF,
        FFFEFE,
        FEFFFF,
        FEFFFE,
        FEFEFF,
        //FEEE
        FEFEFE,
        FEFEFD,
        FEFDFE,
        FEFDFD,
        FDFEFE,
        FDFEFD,
        FDFDFE,
        //FDDD
        FDFDFD,
        FDFDFC,
        FDFCFD,
        FDFCFC,
        FCFDFD,
        FCFDFC,
        FCFCFD,
        //FCCC
        FCFCFC,
        FCFCFB,
        FCFBFC,
        FCFBFB,
        FBFCFC,
        FBFCFB,
        FBFBFC,
        //FBBB
        FBFBFB,
        FBFBFA,
        FBFAFB,
        FBFAFA,
        FAFBFB,
        FAFBFA,
        FAFAFB,
        //FAAA
        FAFAFA,
        FAFAF9,
        FAF9FA,
        FAF9F9,
        F9FAFA,
        F9FAF9,
        F9F9FA,
        //F999
        F9F9F9,
        F8F8F9,
        F8F9F8,
        F8F9F9,
        F9F8F8,
        F9F8F9,
        F9F9F8,
        //F888
        F8F8F8,
        F7F7F8,
        F7F8F7,
        F7F8F8,
        F8F7F7,
        F8F7F8,
        F8F8F7,
        //F777
        F7F7F7,
        F7F7F6,
        F7F6F7,
        F7F6F6,
        F6F7F7,
        F6F7F6,
        F6F6F7,
        //F666
        F6F6F6,
        F6F6F5,
        F6F5F6,
        F6F5F5,
        F5F6F6,
        F5F6F5,
        F5F5F6,
        //F555
        F5F5F5,
        F5F5F4,
        F5F4F5,
        F5F4F4,
        F4F5F5,
        F4F5F4,
        F4F4F5,
        //F444
        F4F4F4,
        F4F4F3,
        F4F3F4,
        F4F3F3,
        F3F4F4,
        F3F4F3,
        F3F3F4,
        //F333
        F3F3F3,
        F3F3F2,
        F3F2F3,
        F3F2F2,
        F2F3F3,
        F2F3F2,
        F2F2F3,
        //F222
        F2F2F2,
        F2F2F1,
        F2F1F2,
        F2F1F1,
        F1F2F2,
        F1F2F1,
        F1F1F2,
        //F111
        F1F1F1,
        F1F1F0,
        F1F0F1,
        F1F0F0,
        F0F1F1,
        F0F1F0,
        F0F0F1,
        //F000
        F0F0F0,
        F0F0EF,
        F0EFF0,
        F0EFEF,
        EFF0F0,
        EFF0EF,
        EFEFF0,
        //EFFF
        EFEFEF,
        EFEFEE,
        EFEEEF,
        EFEEEE,
        EEEFEF,
        EEEFEE,
        EEEEEF,
        //EEEE
        EEEEEE,
        EEEEED,
        EEEDEE,
        EEEDED,
        EDEEEE,
        EDEEED,
        EDEDEE,
        //EDDD
        EDEDED,
        EDEDEC,
        EDECED,
        EDECEC,
        ECEDED,
        ECEDEC,
        ECECED,
        //ECCC
        ECECEC,
        ECECEB,
        ECEBEC,
        ECEBEB,
        EBECEC,
        EBECEB,
        EBEBEC,
        //EBBB
        EBEBEB,
        EBEBEA,
        EBEAEB,
        EBEAEA,
        EAEBEB,
        EAEBEA,
        EAEAEB,
        //EAAA
        EAEAEA,
        EAEAE9,
        EAE9EA,
        EAE9E9,
        E9EAEA,
        E9EAE9,
        E9E9EA,
        //E999
        E9E9E9,
        E9E9E8,
        E9E8E9,
        E9E8E8,
        E8E9E9,
        E8E9E8,
        E8E8E9,
        //E888
        E8E8E8,
        E8E8E7,
        E8E7E8,
        E8E7E7,
        E7E8E8,
        E7E8E7,
        E7E7E8,
        //E777
        E7E7E7
    }
}
