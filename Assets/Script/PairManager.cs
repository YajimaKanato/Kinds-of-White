using UnityEngine;
using WhitePalette;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;

public class PairManager : MonoBehaviour
{
    [SerializeField] Text _clearText;
    [SerializeField] GameObject _enterObj;

    Card[] _cards;
    List<Whites> _whitesList;
    List<Card> _selectedCard = new List<Card>();

    int _pairCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pairCount = 0;
        _clearText.text = "";
        _enterObj.SetActive(false);
        WhiteSetting();
    }

    void WhiteSetting()
    {
        _cards = FindObjectsByType<Card>(FindObjectsSortMode.None);

        //ê›íËÇ∑ÇÈîíÇÃÉäÉXÉgÇçÏÇÈ
        _whitesList = new List<Whites>();
        int rand;
        int count = 0;
        while (_whitesList.Count < _cards.Length)
        {
            rand = UnityEngine.Random.Range(0, WhiteManager.WhiteNumber);
            if (!_whitesList.Contains((Whites)Enum.ToObject(typeof(Whites), rand)))
            {
                _whitesList.Add((Whites)Enum.ToObject(typeof(Whites), rand));
                _whitesList.Add((Whites)Enum.ToObject(typeof(Whites), rand));
            }
            count++;
            if (count >= WhiteManager.WhiteNumber) break;
        }

        //îíÇê›íËÇ∑ÇÈ
        int index;
        count = 0;
        foreach (var card in _cards)
        {
            index = UnityEngine.Random.Range(0, _whitesList.Count);
            card.Whites = _whitesList[index];
            card.WhiteType = WhiteManager.White[_whitesList[index]];
            _whitesList.RemoveAt(index);
            card.Num = count;
            count++;
        }
    }

    public void SelectedCrad(Card card)
    {
        _selectedCard.Add(card);
        if (_selectedCard.Count >= 2)
        {
            if (_selectedCard[0].Whites == _selectedCard[1].Whites)
            {
                SEManager.SEPlay("MakePair");
                _selectedCard[0].gameObject.SetActive(false);
                _selectedCard[0].InstantiateParticle();
                _selectedCard[1].gameObject.SetActive(false);
                _selectedCard[1].InstantiateParticle();
                _selectedCard.Clear();
                _pairCount++;
            }
            else
            {
                _enterObj.SetActive(true);
            }
        }

        if (_pairCount == _cards.Length)
        {
            GetComponent<Timer>().IsEnd = true;
            SEManager.SEPlay("NiceWhite");
            _clearText.text = "Nice White!!";
        }
    }

    public void Enter()
    {
        SEManager.SEPlay("NormalButton");
        StartCoroutine(UnSelecteCard(_selectedCard));
    }

    IEnumerator UnSelecteCard(List<Card> list)
    {
        foreach (var card in list)
        {
            card.SelectCard();
        }
        _selectedCard.Clear();
        _enterObj.SetActive(false);
        yield break;
    }
}
