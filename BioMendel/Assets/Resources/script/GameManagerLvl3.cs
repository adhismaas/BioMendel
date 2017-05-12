﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManagerLvl3 : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 3;

    // Update is called once per frame
    void Update()
    {
        if (!_init)
            initializeCards();

        if (Input.GetMouseButtonUp(0))
            checkCards();

        if (Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("Screen Level"); }
    }

    void initializeCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            bool test = false;
            int choice = 0;
            while (!test)
            {
                choice = UnityEngine.Random.Range(0, cards.Length);
                test = !(cards[choice].GetComponent<CardLvl3>().initialized);
            }

            cards[choice].GetComponent<CardLvl3>().cardValue = i;
            cards[choice].GetComponent<CardLvl3>().initialized = true;
        }


        foreach (GameObject c in cards)
            c.GetComponent<CardLvl3>().setupGraphics();

        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<CardLvl3>().state == 1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        CardLvl3.DO_NOT = true;

        int x = 0;

        if (Math.Abs(cards[c[0]].GetComponent<CardLvl3>().cardValue - cards[c[1]].GetComponent<CardLvl3>().cardValue) == 3)
        {
            x = 2;
            _matches--;
            //matchText.text = "Number of Matches left : " + _matches;

            if (_matches == 0)
                SceneManager.LoadScene("Screen Level");
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<CardLvl3>().state = x;
            cards[c[i]].GetComponent<CardLvl3>().falseCheck();
        }
    }
}
