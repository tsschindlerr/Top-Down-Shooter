using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float bottomBound;
    private Rigidbody enemyRb;
    private GameObject player;
    private Vector3 lookDirection;

    void Start()
    {
        //access essential components for enemy movement
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        //create a vector to face the player + add speed
        if (player != null)
        {
            lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            //transform.Translate(lookDirection * speed);
        }
        else
        {
            lookDirection = transform.position;
        }

        //if enemy falls under the map = destroy
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Enemy collided with Projectile");
        }
    }
}
