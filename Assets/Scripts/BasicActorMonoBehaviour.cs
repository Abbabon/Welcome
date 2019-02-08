using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasicActorMonoBehaviour : MonoBehaviour {

    #region Transform Vector Commons
    public float x
    {
        get
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            return t.position.x;
        }
        set
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            t.position =
                new Vector3(value, t.position.y, t.position.z);
        }
    }

    public float y
    {
        get
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            return t.position.y;
        }
        set
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            t.position =
                 new Vector3(t.position.x, value, t.position.z);
        }
    }

    public float rotation
    {
        get
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            return t.rotation.z;
        }
        set
        {
            transform.Rotate(new Vector3(0, 0, value));
        }
    }

    public float depth
    {
        get
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            return t.position.z;
        }
        set
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            t.position =
                new Vector3(t.position.x, t.position.y, value);
        }

    }

    public float scale
    {
        get
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            return t.localScale.x;
        }
        set
        {
            Transform t = gameObject.GetComponentInParent<Transform>();
            t.localScale =
                new Vector3(value, value, value);
        }
    }
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Fading

    protected IEnumerator FadeToFullAlpha(float t, SpriteRenderer g)
    {
        while (g.color.a < 1.0f)
        {
            g.color = new Color(g.color.r, g.color.g, g.color.b, g.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    protected IEnumerator FadeToZeroAlpha(float t, SpriteRenderer g)
    {
        while (g.color.a < 1.0f)
        {
            g.color = new Color(g.color.r, g.color.g, g.color.b, g.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    #endregion
}
