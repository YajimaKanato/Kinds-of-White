using System;
using UnityEngine;
using WhitePalette;

public class WhiteSetter : MonoBehaviour
{
    [SerializeField] int _maxWhiteNum = 5;

    //以下二つはインデックスがリンクする
    GameObject[] _objects;
    WhiteSquare[] _squares;

    int _whiteNum;
    public int WhiteNum { get { return _whiteNum; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Setting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Setting()
    {
        //色変更するオブジェクト取得
        _objects = GameObject.FindGameObjectsWithTag("White");
        Debug.Log(_objects.Length);
        _squares = new WhiteSquare[_objects.Length];

        int whiteObj;

        //白（真白以外）の生成
        for (int i = 0; i < _objects.Length; i++)
        {
            //用意されている白の中から真白以外をランダムで一色選ぶ
            _whiteNum = UnityEngine.Random.Range(1, WhiteManager.WhiteNumber);
            _squares[i] = _objects[i].GetComponent<WhiteSquare>();
            _squares[i].Whites = (Whites)Enum.ToObject(typeof(Whites), _whiteNum);
            _squares[i].WhiteType = WhiteManager.White[_squares[i].Whites];
        }

        //真白の生成
        //真白にする数
        _whiteNum = UnityEngine.Random.Range(1, _maxWhiteNum + 1);
        for (int i = 0; i < _whiteNum; i++)
        {
            //白く塗ったオブジェクトの中から真白にするオブジェクトをランダムで選ぶ
            whiteObj = UnityEngine.Random.Range(0, _objects.Length);

            //ランダムで選んだオブジェクトがすでに真白だったら
            if (_squares[whiteObj].Whites == Whites.FFFFFF)
            {
                i--;
                continue;
            }

            //真白にする
            _squares[whiteObj].Whites = Whites.FFFFFF;
            _squares[whiteObj].WhiteType = WhiteManager.White[Whites.FFFFFF];
        }
    }
}
