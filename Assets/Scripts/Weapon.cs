using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // This script will handle a laser's position and movement when spawned

    private Vector3 endTranslationPosition;

    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy(gameObject, timeToDestroy);
        // endTranslationPosition = new Vector3(transform.position.x, transform.position.y + 20f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(TranslateOverTime(transform, endTranslationPosition, speed));
        transform.Translate(speed * Time.deltaTime * Vector3.up);

        if (transform.position.y > 8.65f)
        {
            Destroy(gameObject);
        }
    }
    
}