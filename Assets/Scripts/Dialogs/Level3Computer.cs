using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Computer : MonoBehaviour
{
    [SerializeField] private string _rightPass;
    [SerializeField] private Text[] _text = new Text[4];
    [SerializeField] private GameObject _pictureImage;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _credits;

    int currentNum = 0;

    private void Update()
    {
        int num = -1;
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                num = i;
            }
        }
        if (num != -1)
        {
            _text[currentNum].text = num.ToString();
            if (++currentNum >= _text.Length)
            {
                string entrustedPass = "";
                foreach (var item in _text)
                {
                    entrustedPass += item.text;
                }
                if (entrustedPass == _rightPass)
                {
                    _pause.SetActive(false);
                    _pictureImage.SetActive(true);
                    Invoke("ShowCredits", 3.5f);
                }
                else
                {
                    foreach (var item in _text)
                    {
                        currentNum = 0;
                        item.text = "";
                    }
                }
            }
        }
    }
    private void ShowCredits()
    {
        _credits.SetActive(true);
        Invoke("ToMainMenu", 25f);
    }
    private void ToMainMenu()
    {
        _pause.GetComponent<Pause>().OnClickYes();
    }
}
