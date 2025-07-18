using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextSetter : MonoBehaviour
{
    public float scale = 1.2f;
    public TMP_Text _text;
    public GameObject[] _images;
    public Sprite[] beigeSprites;
    public Sprite[] blueSprites;
    Vector3[] _localScales;

    void Start()
    {
        _localScales = new Vector3[_images.Length];
        for (int i = 0; i < _images.Length; ++i)
            _localScales[i] = _images[i].transform.localScale;
    }

    public void Apparatus()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].transform.localScale = _localScales[i];
            _images[i].GetComponent<Image>().sprite = beigeSprites[i];
        }
        _images[0].transform.localScale *= scale;
        _images[0].GetComponent<Image>().sprite = blueSprites[0];

        _text.text = "«Союз МС» — модификация российского пилотируемого космического корабля семейства «Союз». Предназначена для доставки экипажа до трёх человек и грузов на МКС и обратно.";
    }

    public void Clock()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].transform.localScale = _localScales[i];
            _images[i].GetComponent<Image>().sprite = beigeSprites[i];
        }
        _images[1].transform.localScale *= scale;
        _images[1].GetComponent<Image>().sprite = blueSprites[1];

        _text.text = "Частота — количество колебаний электромагнитного поля в секунду.";
    }

    public void Buttons()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].transform.localScale = _localScales[i];
            _images[i].GetComponent<Image>().sprite = beigeSprites[i];
        }
        _images[2].transform.localScale *= scale;
        _images[2].GetComponent<Image>().sprite = blueSprites[2];
        _text.text = "Амплитуда — отклонение от среднего <br>значения радиоволны.";
    }

    public void Headphones()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].transform.localScale = _localScales[i];
            _images[i].GetComponent<Image>().sprite = beigeSprites[i];
        }
        _images[3].transform.localScale *= scale;
        _images[3].GetComponent<Image>().sprite = blueSprites[3];
        _text.text = "Радио-диспетчер Центра управления полётами (ЦУП). Принимает, перенаправляет <br>и документирует сигналы от космических аппаратов. При спуске и возвращении космонавтов на Землю обеспечивает <br>стабильную связь.";
    }
}
