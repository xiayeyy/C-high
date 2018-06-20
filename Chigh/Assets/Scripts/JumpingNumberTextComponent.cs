using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class JumpingNumberTextComponent : MonoBehaviour
{
    [SerializeField]
    private List<Text> _numbers;
    [SerializeField]
    private List<Text> _unactiveNumbers;
    /// <summary>
    /// 動畫時長
    /// </summary>
    [SerializeField]
    private float _duration = 3f;
    /// <summary>
    /// 數字每次滾動時長
    /// </summary>
    [SerializeField]
    private float _rollingDuration = 0.05f;
    /// <summary>
    /// 滾動延遲（每進一位增加一倍延遲）
    /// </summary>
    [SerializeField]
    private float _delay = 0.008f;
    /// <summary>
    /// Text文本寬高
    /// </summary>
    private Vector2 _numberSize;
    /// <summary>
    /// 每幀變動數值
    /// </summary>
    private int _speed;
    private int _curNumber;
    private int _targetNumber;
    private List<Tweener> _tweener = new List<Tweener>();

    public Action OnComplete;

    private void Awake()
    {
        _numberSize = _numbers[0].rectTransform.sizeDelta;
    }

    public float duration
    {
        get { return _duration; }
        set
        {
            _duration = value;
        }
    }

    private float _different;
    public float different
    {
        get { return _different; }
    }

    public   void Change(int from, int to)
    {
        if (_curNumber == from && _targetNumber == to) return;

        _curNumber = from;
        _targetNumber = to;
        _different = to - from;
        _speed = (int)(_different / (_duration * (1 / _rollingDuration)));

        SetNumber(from, false);
        StopCoroutine("DoJumpNumber");
        StartCoroutine("DoJumpNumber");

    }

  
        
    public int number
    {
        get { return _targetNumber; }
        set
        {
            if (_targetNumber == value) return;
            Change(_curNumber, _targetNumber);
        }
    }

    IEnumerator DoJumpNumber()
    {
        while (true)
        {
            if (_speed > 0)//增加
            {
                _curNumber = Math.Min(_curNumber + _speed, _targetNumber);
            }
            else if (_speed < 0) //減少
            {
                _curNumber = Math.Max(_curNumber + _speed, _targetNumber);
            }
            if (_curNumber == _targetNumber)
            {
                StopCoroutine("DoJumpNumber");
                if (OnComplete != null) OnComplete();
                yield return null;
            }
            SetNumber(_curNumber, true);

            yield return new WaitForSeconds(_rollingDuration);
        }
    }

    /// <summary>
    /// 設置戰力數字
    /// </summary>
    /// <param name="v"></param>
    /// <param name="isTween"></param>
    public void SetNumber(int v, bool isTween)
    {
        char[] c = v.ToString().ToCharArray();
        Array.Reverse(c);
        string s = new string(c);

        if (!isTween)
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                if (i < s.Count())
                    _numbers[i].text = s[i] + "";
                else
                    _numbers[i].text = "0";
            }
        }
        else
        {
            while (_tweener.Count > 0)
            {
                _tweener[0].Complete();
                _tweener.RemoveAt(0);
            }

            for (int i = 0; i < _numbers.Count; i++)
            {
                if (i < s.Count())
                {
                    _unactiveNumbers[i].text = s[i] + "";
                }
                else
                {
                    _unactiveNumbers[i].text = "0";
                }

                _unactiveNumbers[i].rectTransform.anchoredPosition = new Vector2(_unactiveNumbers[i].rectTransform.anchoredPosition.x, -_numberSize.y);
                _numbers[i].rectTransform.anchoredPosition = new Vector2(_unactiveNumbers[i].rectTransform.anchoredPosition.x, 0);

                if (_unactiveNumbers[i].text != _numbers[i].text)
                {
                    DoTween(_numbers[i], _numberSize.y, _delay * i);
                    DoTween(_unactiveNumbers[i], 0, _delay * i);

                    Text tmp = _numbers[i];
                    _numbers[i] = _unactiveNumbers[i];
                    _unactiveNumbers[i] = tmp;
                }
            }
        }
    }

    public void DoTween(Text text, float endValue, float delay)
    {
        Tweener t = DOTween.To(() => text.rectTransform.anchoredPosition, (x) =>
        {
            text.rectTransform.anchoredPosition = x;
        }, new Vector2(text.rectTransform.anchoredPosition.x, endValue), _rollingDuration - delay).SetDelay(delay);
        _tweener.Add(t);
    }

    public void CreateCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    [ContextMenu("測試數字變化")]
    public   void TestChange()
    {
        CreateCube();
        //Change(UnityEngine.Random.Range(1, 1), UnityEngine.Random.Range(1, 100000));
        //Debug.Log(111111);
    }

}