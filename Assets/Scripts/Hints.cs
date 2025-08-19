using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public Settings settings;

    public TMP_Text _text;
    public string signal;
    public string ampl;
    public string freq;
    public List<string> spawned = new(3);

    public GameObject arrows;

    private void Start()
    {
        signal = "�������� <color=#313fa5> �����</color> ����� ����� <br>��, ��� <color=#a06900>���������</color>!";
        ampl = "������ ����� � ��� ���������. <br>��� ���������� ���������� <br>�� �������� �������� �����.";
        freq = "������ ����� � ��� �������. <br>��� ���������� ���������� ��������� ����������������� <br>���� � �������.";
    }
    public void SwitchLeft()
    {
        for (int i = 0; i < spawned.Count; ++i)
        {
            if (_text.text == spawned[i])
            {
                if (i != 0)
                    _text.text = spawned[--i];
                else
                    _text.text = spawned[^1];
                break;
            }
        }
    }

    public void SwitchRight()
    {
        for (int i = 0; i < spawned.Count; ++i)
        {
            if (_text.text == spawned[i])
            {
                if (i != (spawned.Count - 1))
                    _text.text = spawned[++i];
                else
                    _text.text = spawned[0];
                break;
            }
        }
    }
}
