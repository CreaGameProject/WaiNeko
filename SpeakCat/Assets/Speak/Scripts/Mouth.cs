using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    private RectTransform mouth;
    private Vector2 mouthPos;

    void Start()
    {
        mouth = GetComponent<RectTransform>();
        mouthPos = mouth.anchoredPosition;    
    }

    // Update is called once per frame
    void Update()
    {
        //ボリュームに応じて下あごを下げる
        mouth.anchoredPosition = mouthPos + Vector2.down * Volume.m_volumeRate * 80;     
    }
}
