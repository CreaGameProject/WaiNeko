using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Image close;
    void Start()
    {
        close = GetComponent<Image>();
        StartCoroutine("RandomBlink");
    }

    public IEnumerator RandomBlink()
    {
        while (true)
        {
            float interval = Random.Range(2f, 10f);
            yield return new WaitForSeconds(interval);
            float count = Random.Range(0, 1f);
            if (count > 0.1f)
            {
                close.enabled = true;
                yield return new WaitForSeconds(0.1f);
                close.enabled = false;
            }
            else
            {
                close.enabled = true;
                yield return new WaitForSeconds(0.1f);
                close.enabled = false;
                yield return new WaitForSeconds(0.1f);
                close.enabled = true;
                yield return new WaitForSeconds(0.1f);
                close.enabled = false;
            }
        }
    }
}
