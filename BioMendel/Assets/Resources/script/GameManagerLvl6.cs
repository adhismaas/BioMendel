using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManagerLvl6 : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    public float time = 0f;

    private bool _init = false;
    private int _matches = 4;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (!_init)
            initializeCards();

        if (Input.GetMouseButtonUp(0))
            checkCards();

        if(Input.GetKeyDown(KeyCode.Escape)){ SceneManager.LoadScene("Screen Level");}
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
                test = !(cards[choice].GetComponent<CardLvl6>().initialized);
            }

            cards[choice].GetComponent<CardLvl6>().cardValue = i;
            cards[choice].GetComponent<CardLvl6>().initialized = true;
        }


        foreach (GameObject c in cards)
            c.GetComponent<CardLvl6>().setupGraphics();

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
            if (cards[i].GetComponent<CardLvl6>().state == 1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        CardLvl6.DO_NOT = true;

        int x = 0;

        if (Math.Abs(cards[c[0]].GetComponent<CardLvl6>().cardValue - cards[c[1]].GetComponent<CardLvl6>().cardValue) == 4)
        {
            x = 2;
            _matches--;

            if (_matches <= 0)
                SceneManager.LoadScene("Screen Level");
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<CardLvl6>().state = x;
            cards[c[i]].GetComponent<CardLvl6>().falseCheck();
        }
    }
}
