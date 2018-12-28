using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditRect : MonoBehaviour {
    Camera c;

    private void Start()
    {
        c = GetComponent<Camera>();
    }
    private void OnEnable()
    {
        Rocket.fadeOut += Shrek;
    }
    private void OnDisable()
    {
        Rocket.fadeOut -= Shrek;
    }

    void Shrek()
    {
        StartCoroutine(BackToSize());
    }
    IEnumerator BackToSize()
    {
        for (float i = 0.3f; i >= 0; i -= Time.deltaTime)
        {
            c.rect = new Rect(new Vector2(c.rect.x, i), new Vector2(1, 1));
            yield return null;
        }

        c.rect = new Rect(new Vector2(c.rect.x, 0), new Vector2(1, 1));
    }
}
