using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    public TextMeshProUGUI text;

    public float numb;

    private void Awake()
    {
        text.SetText("{0}", numb);
    }
}
