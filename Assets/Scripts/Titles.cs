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

        _text.text = "����� �ѻ � ����������� ����������� ������������� ������������ ������� ��������� �����. ������������� ��� �������� ������� �� ��� ������� � ������ �� ��� � �������.";
    }

    public void Buttons()
    {
        ChangeImage();

        _images[1].transform.localScale *= scale;
        _images[1].GetComponent<Image>().sprite = blueSprites[1];

        _text.text = "<color=#313fa5>���������</color> � ���������� �� �������� <br>�������� ����������. <br><color=#a06900>�������</color> � ���������� ��������� ����������������� ���� � �������.";
    }

    public void Headphones()
    {
        ChangeImage();

        _images[2].transform.localScale *= scale;
        _images[2].GetComponent<Image>().sprite = blueSprites[2];

        _text.text = "�����-��������� ������ ���������� ������� (���). ���������, �������������� <br>� ������������� ������� �� ����������� ���������. ��� ������ � ����������� ����������� �� ����� ������������ <br>���������� �����.";
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
