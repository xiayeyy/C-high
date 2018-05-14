using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Assets11;

public enum WindowWeight
{
    normal,
    priority,
    foremost,
}

public class Key : MonoBehaviour
{
    public WindowWeight windowWeight = WindowWeight.normal;
    public bool priority = false;

    [SerializeField]
    bool enable = false;
    bool accessible = true;

    [SerializeField]
    ButtonAndGesture buttonAndGesture = ButtonAndGesture.Both;
    //识别模式设定

    [SerializeField]
    float delay = 0;
    //启动延迟

    public delegate void KeyDelegate();

    public KeyDelegate keyDelegate;

    public MonoBehaviour target = null;

    public ButtonAndGesture GetModel
    {
        get { return buttonAndGesture; }
    }

    public bool Accessible
    {
        set { accessible = value; }
    }

    void OnEnable()
    {
        KeyListener.Clear();
        KeyListener.Key = this;
        enable = false;
        Invoke("Active", delay);
    }

    void OnDisable()
    {
        enable = false;
        if (KeyListener.Key == this)
        {
            KeyListener.Key = null;
        }

        KeyListener.Clear();
    }

    void Update()
    {
        if (KeyListener.KeyQueue.Count > 0)
        {
            if (enable)
            {
                if (!accessible)
                {
                    return;
                }

                var key = KeyListener.KeyQueue.Dequeue();

                //this.target.InvokeKeyPressEvent(key, 0);

            }
            else
            {
                KeyListener.KeyQueue.Dequeue();
                return;
            }
        }
    }

    void Active()
    {
        enable = true;
    }

    public enum ButtonAndGesture
    {
        Both,
        Button,
        Gesture,
    }

    private void OnDestroy()
    {
        if (KeyListener.Instance != null)
        {
            KeyListener.Instance.ReturnKey();
        }
    }
}