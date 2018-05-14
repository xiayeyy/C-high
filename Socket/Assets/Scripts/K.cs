using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K <T> : MonoBehaviour where T : K<T> { 
    public Transform parent { get; private set; }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Transform LoadPage(Transform prefab)
    {
        if (this.parent == null)
        {
            this.parent = GameObject.Find("Canvas").transform;
        }
        return this.LoadPage(prefab, this.parent);
    }
    public K LoadPage<K>(Transform prefab)
    {
        if (this.parent == null)
        {
            this.parent = GameObject.Find("Canvas").transform;
        }
        return this.LoadPage<K>(prefab, this.parent);
    }
    public Transform LoadPage(Transform prefab, Transform parent)
    {
        var trans = Instantiate(prefab, parent, false) as Transform;
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.gameObject.SetActive(true);
       
        return trans;
    }

    public K LoadPage<K>(Transform prefab, Transform parent)
    {
        var trans = this.LoadPage(prefab, parent);
        return trans.GetComponent<K>();
    }
}
