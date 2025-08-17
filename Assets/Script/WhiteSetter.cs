using System;
using UnityEngine;
using WhitePalette;

public class WhiteSetter : MonoBehaviour
{
    [SerializeField] int _maxWhiteNum = 5;

    //�ȉ���̓C���f�b�N�X�������N����
    GameObject[] _objects;
    WhiteSquare[] _squares;

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
        //�F�ύX����I�u�W�F�N�g�擾
        _objects = GameObject.FindGameObjectsWithTag("White");
        _squares = new WhiteSquare[_objects.Length];

        int whiteNum;
        int whiteObj;

        //���i�^���ȊO�j�̐���
        for (int i = 0; i < _objects.Length; i++)
        {
            //�p�ӂ���Ă��锒�̒�����^���ȊO�������_���ň�F�I��
            whiteNum = UnityEngine.Random.Range(1, WhiteManager.WhiteNumber);
            _squares[i] = _objects[i].GetComponent<WhiteSquare>();
            _squares[i].Whites = (Whites)Enum.ToObject(typeof(Whites), whiteNum);
            _squares[i].WhiteType = WhiteManager.White[_squares[i].Whites];
        }

        //�^���̐���
        //�^���ɂ��鐔
        whiteNum = UnityEngine.Random.Range(0, _maxWhiteNum);
        for (int i = 0; i < whiteNum; i++)
        {
            //�����h�����I�u�W�F�N�g�̒�����^���ɂ���I�u�W�F�N�g�������_���őI��
            whiteObj = UnityEngine.Random.Range(0, _objects.Length);

            //�����_���őI�񂾃I�u�W�F�N�g�����łɐ^����������
            if (_squares[whiteObj].Whites == Whites.FFFFFF)
            {
                i--;
                continue;
            }

            //�^���ɂ���
            _squares[whiteObj].Whites = Whites.FFFFFF;
            _squares[whiteObj].WhiteType = WhiteManager.White[Whites.FFFFFF];
        }
    }
}
