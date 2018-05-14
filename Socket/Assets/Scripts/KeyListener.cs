using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class KeyListener : MonoBehaviour
{
    public static KeyListener Instance
    {
        get
        {
            return instance;
        }
    }

    static KeyListener instance;

    static internal Queue<KeyCode> KeyQueue = new Queue<KeyCode>();

    public static Stack<GameObject> PreKeys = new Stack<GameObject>();

    [SerializeField]
    static Key key = null;

    private List<KeyCode> watchingKeyList = new List<KeyCode>();

    public static Key Key
    {
        get
        {
            return key;
        }
        set
        {
            if (value != null && value.gameObject != null && value.enabled)
            {
                if (key != null && key.gameObject != null && key.enabled)
                {
                    if (key.windowWeight == WindowWeight.normal && value.windowWeight == WindowWeight.normal)
                    {
                        PreKeys.Push(key.gameObject);
                        key.enabled = false;
                        key = value;
                    }
                    else
                    {
                        if ((int)value.windowWeight > (int)key.windowWeight)
                        {
                            PreKeys.Push(key.gameObject);
                            key.enabled = false;
                            key = value;
                        }
                        else
                        {
                            PreKeys.Push(value.gameObject);
                            value.enabled = false;
                        }
                    }
                }
                else
                {
                    key = value;
                }
            }
            else
            {
                key = value;
            }
        }
    }

    void Awake()
    {
        instance = this;
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            this.watchingKeyList.Add(key);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Manager();
    }

    public void ReturnKey()
    {
        if (this != null && this.gameObject != null)
        {
            //StartCoroutine(CoroutineReturnKey());
        }
    }

    public IEnumerator CoroutineReturnKey()
    {
        yield return new WaitForEndOfFrame();
        if (PreKeys.Count > 0)
        {
            GameObject go = null;

            GameObject[] gos = PreKeys.ToArray();
            int _w = 0;
            foreach (var g in PreKeys)
            {
                if (g == null) { continue; }
                int _g_w = (int)g.GetComponent<Key>().windowWeight;
                if (_g_w > _w)
                {
                    _w = _g_w;
                    go = g;
                }
            }

            while (go == null)
            {
                if (PreKeys.Count <= 0)
                {
                    break;
                }
                go = PreKeys.Pop();
            }
            if (go != null)
            {
                go.GetComponent<Key>().enabled = true;
            }
        }
    }

    public static void EmptyKey()
    {
        key = null;
    }

    void Manager()
    {
        if (key == null)
        {
            return;
        }

        if (key.GetModel == Key.ButtonAndGesture.Gesture)
        {
            return;
        }

        foreach (var key in this.watchingKeyList)
        {
            if (Input.GetKeyDown(key))
            {
                KeyQueue.Enqueue(key);
                break;
            }
        }
    }

    private void OnGUI()
    {
        if (key == null)
        {
            return;
        }

        if (key.GetModel == Key.ButtonAndGesture.Gesture)
        {
            return;
        }
        if (Input.anyKeyDown)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (e.keyCode.ToString() == "10")
                {
                    this.SendKey(KeyCode.Return);
                }

            }
        }
    }

    public void SendKey(KeyCode keyCode)
    {
        if (key != null)
        {
            KeyQueue.Enqueue(keyCode);
        }
    }

    public static void Clear()
    {
        KeyQueue.Clear();
    }
}
