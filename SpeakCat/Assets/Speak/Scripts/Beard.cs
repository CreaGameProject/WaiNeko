using UnityEngine;

public class Beard : MonoBehaviour
{
    private RectTransform beard;
    private float beardLength;

    void Start()
    {
        beard = GetComponent<RectTransform>();
        beardLength = 0f;
    }

    void Update()
    {
        //ボリュームに準じて最大値を更新する or 徐々に縮ませる。
        beardLength = Volume.m_volumeRate > beardLength ? Volume.m_volumeRate : beardLength - 0.01f;
        beard.localScale = new Vector3(1f + beardLength * 0.5f, 1f, 1f);
    }
}
