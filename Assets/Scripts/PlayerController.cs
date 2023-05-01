using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // This component will handle player action and state

    [Header("Attributes")]
    [SerializeField]
    private int health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float laserSpawnOffset;

    [Header("Player UI")]
    [SerializeField]
    private GameObject healthText;

    [Header("Bounds")]
    [SerializeField]
    private float boundMaxX;
    [SerializeField]
    private float boundMinX;
    [SerializeField]
    private float boundMaxY;
    [SerializeField]
    private float boundMinY;

    [Header("Projectiles")]
    [SerializeField]
    private GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        healthText.GetComponent<Text>().text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        ShootLaser();
        UpdateUI();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CalculateMovement()
    {
        // Get X-axis movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Get Y-axis movement
        float verticalInput = Input.GetAxis("Vertical");

        // Deprecated: Using a more performant statement
        // transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        // transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.up);

        // Create direction Vector3 object
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the player game object
        transform.Translate(speed * Time.deltaTime * direction);

        // Keep the player in bounds
        if (transform.position.y > boundMaxY)
        {
          //  transform.position = new Vector3(transform.position.x, boundMaxY, 0f);
        }
        else if (transform.position.y < boundMinY)
        {
           // transform.position = new Vector3(transform.position.x, boundMinY, 0f);
        }

        if (transform.position.x > boundMaxX)
        {
           // transform.position = new Vector3(boundMaxX, transform.position.y, 0f);
        }
        else if (transform.position.x < boundMinX)
        {
           // transform.position = new Vector3(boundMinX, transform.position.y, 0f);
        }
    }

    private void ShootLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position of this transform
            Instantiate(laser, transform.position + new Vector3(0f, laserSpawnOffset, 0f), Quaternion.identity);
        }
    }

    private void UpdateUI()
    {
        healthText.GetComponent<Text>().text = health.ToString();
    }

    public void EnemyDamage()
    {
        if (health >= 1)
        {
            health -= 1;
        }
    }

    public void EnemyDamage(EnemyState enemy)
    {
        if (health >= 1)
        {
            if (enemy.grunt)
            {
                health -= 1;
            }
            else if (enemy.brute)
            {
                health -= 2;
            }
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
