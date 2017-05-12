﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLvl6 : MonoBehaviour
{
    public static bool DO_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private int _cardValueLatin;
    [SerializeField]
    private bool _initialized = false;


    private Sprite _cardBack;
    private Sprite _cardFace;
    private Sprite _cardFaceLatin;

    private GameObject _manager;

    void Start()
    {
        _state = 0;
        _manager = GameObject.FindGameObjectsWithTag("Manager6")[0];
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManagerLvl6>().getCardBack();
        _cardFace = _manager.GetComponent<GameManagerLvl6>().getCardFace(_cardValue);
    }

    public void flipCard()
    {
        if (_state == 0)
            _state = 1;

        else if (_state == 1)
            _state = 0;

        if (_state == 0 && !DO_NOT)
            GetComponent<Image>().sprite = _cardBack;

        else if (_state == 1 && !DO_NOT)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }
}
