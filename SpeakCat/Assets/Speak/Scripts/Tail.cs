using UnityEngine;

public class Tail : MonoBehaviour
{
    private RectTransform tail;
    private float tailRotatin;

    void Start()
    {
        tail = GetComponent<RectTransform>();
        tailRotatin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //言わばボリュームの積分
        tailRotatin += Volume.m_volumeRate;
        tailRotatin = tailRotatin > Mathf.PI * 2f ? tailRotatin -= Mathf.PI * 2f : tailRotatin;
        tail.rotation = Quaternion.Euler(Vector3.forward * Mathf.Sin(tailRotatin) * 5f);  
    }
}
