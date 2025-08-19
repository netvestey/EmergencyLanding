using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Titles : MonoBehaviour
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
        ChangeImage();

        _images[0].transform.localScale *= scale;
        _images[0].GetComponent<Image>().sprite = blueSprites[0];

        _text.text = "«Союз МС» — модификация российского пилотируемого космического корабля семейства «Союз». Предназначена для доставки экипажа до трёх человек и грузов на МКС и обратно.";
    }

    public void Buttons()
    {
        ChangeImage();

        _images[1].transform.localScale *= scale;
        _images[1].GetComponent<Image>().sprite = blueSprites[1];

        _text.text = "<color=#313fa5>Амплитуда</color> — отклонение от среднего <br>значения радиоволны. <br><color=#a06900>Частота</color> — количество колебаний электромагнитного поля в секунду.";
    }

    public void Headphones()
    {
        ChangeImage();

        _images[2].transform.localScale *= scale;
        _images[2].GetComponent<Image>().sprite = blueSprites[2];

        _text.text = "Радио-диспетчер Центра управления полётами (ЦУП). Принимает, перенаправляет <br>и документирует сигналы от космических аппаратов. При спуске и возвращении космонавтов на Землю обеспечивает <br>стабильную связь.";
    }

    public void ChangeImage()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].transform.localScale = _localScales[i];
            _images[i].GetComponent<Image>().sprite = beigeSprites[i];
        }
    }
}
