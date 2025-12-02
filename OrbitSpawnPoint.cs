using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OrbitSpawnPoint : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer;
    public float orbitingSpeed;

    private float angleY;
    
    void Start()
    {
        if (!player) return;

        Vector3 direction = transform.position - player.position;
        angleY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }

    
    void Update()
    {
        if (!player) return; //don't do anything if the player is missing

        angleY += Input.GetAxis("Mouse X") * orbitingSpeed * Time.deltaTime;

        float rad = angleY * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Sin(rad) * distanceFromPlayer, 0f, Mathf.Cos(rad) * distanceFromPlayer);
        transform.position = player.position + offset;

        transform.LookAt(-player.position);
    }
}
