using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OnClickScaller : MonoBehaviour
{
    public GameObject _button;

    public void Scaler()
    {
        RectTransform _tr = GetComponent<RectTransform>();
        _tr.DOComplete();
        _tr.DOPunchScale(Vector3.one * -2f, 1f, 2);
    }
}
