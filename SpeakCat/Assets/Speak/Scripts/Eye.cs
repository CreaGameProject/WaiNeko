using UnityEngine;

public class Eye : MonoBehaviour
{
    private RectTransform eye;
    private Vector2 defaltPos;
    [SerializeField] private Vector2 up;
    [SerializeField] private Vector2 down;
    [SerializeField] private Vector2 right;
    [SerializeField] private Vector2 left;

    private byte eyeState;

    private float t;
    private Vector2 befrePos;//滑らかに動かすためのベクトル→38
    void Start()
    {
        eye = GetComponent<RectTransform>();
        defaltPos = eye.anchoredPosition;
        t = 0;
    }

    void Update()
    {
        t += Time.deltaTime;
        byte beforeState = eyeState;
        StateUpdate();
        if (beforeState != eyeState)
        {
            t = 0;
            befrePos = eye.anchoredPosition;
        }
        else
        {
            if (t < 0.1f)
            {
                //滑らかに動かす
                eye.anchoredPosition = Vector2.Lerp(befrePos, EyePos(), t / 0.1f);
            }
            else
            {
                befrePos = eye.anchoredPosition = EyePos();  
            }
        }

    }

    //状態の更新
    private void StateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) eyeState += 1;
        if (Input.GetKeyDown(KeyCode.DownArrow)) eyeState += 2;
        if (Input.GetKeyDown(KeyCode.RightArrow)) eyeState += 4;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) eyeState += 8;
        if (Input.GetKeyUp(KeyCode.UpArrow)) eyeState -= 1;
        if (Input.GetKeyUp(KeyCode.DownArrow)) eyeState -= 2;
        if (Input.GetKeyUp(KeyCode.RightArrow)) eyeState -= 4;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) eyeState -= 8;
    }

    //状態の読み取り
    private Vector2 EyePos()
    {
        switch (eyeState)
        {
            case 1: return defaltPos + up;
            case 2: return defaltPos + down;
            case 4: return defaltPos + right;
            case 8: return defaltPos + left;
            case 5: return defaltPos + (up + right) * 0.7f;
            case 9: return defaltPos + (up + left) * 0.7f;
            case 6: return defaltPos + (down + right) * 0.7f;
            case 10: return defaltPos + (down + left) * 0.7f;
            default: return defaltPos;
        }
    }
}
