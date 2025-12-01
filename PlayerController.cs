using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //player movement
    public float speed;
    public float topBound;
    public float sideBound;
    private Rigidbody playerRb;

    //firing projectiles
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        MovePlayer();
        ConstrainPlayerMove();
        Fire();
    }

    // moves the player mased on WASD/arrow input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Limits player moevement to given area
    void ConstrainPlayerMove()
    {
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
        if (transform.position.z < -topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -topBound);
        }
        if (transform.position.x > sideBound)
        {
            transform.position = new Vector3(sideBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -sideBound)
        {
            transform.position = new Vector3(-sideBound, transform.position.y, transform.position.z);
        }

    }

    //destroy player on collision with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Player collided with Enemy");
        }
    }

    //destroy powerup on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player collected Powerup");
        }
    }

    // fire a projectile on click
    void Fire() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
        }

}
