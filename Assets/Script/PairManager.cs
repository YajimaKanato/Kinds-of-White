using UnityEngine;
using WhitePalette;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine.UI;

public class PairManager : MonoBehaviour
{
    [SerializeField] Text _clearText;

    Card[] _cards;
    List<Whites> _whitesList;
    List<Card> _selectedCard = new List<Card>();

    Whites _whites;

    int _pairCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pairCount = 0;
        _clearText.text = "";
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
                _selectedCard[0].gameObject.SetActive(false);
                _selectedCard[1].gameObject.SetActive(false);
                _selectedCard.Clear();
            }
            else
            {
                StartCoroutine(UnSelecteCard(_selectedCard));
            }
        }

        if (_pairCount == _cards.Length)
        {
            _clearText.text = "Nice White!!";
        }
    }

    IEnumerator UnSelecteCard(List<Card> list)
    {
        yield return new WaitForSeconds(0.5f);
        foreach (var card in list)
        {
            card.SelectCard();
        }
        _selectedCard.Clear();
        yield break;
    }
}
