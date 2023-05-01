using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 2f;
    private bool hit = false;

    // private Vector3 baseLocation = new Vector3(0f, 7.18f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = baseLocation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.tag == "Bullet")
            {
                hit = true;
                GameObject.Find("GameManager").GetComponent<GameManager>().SetPlayerPoints(1);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().EnemyDamage();
            }
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}