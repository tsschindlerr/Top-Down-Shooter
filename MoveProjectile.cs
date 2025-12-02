using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public float projectileTopBound;
    public float projectileSideBound;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if(transform.position.x > projectileSideBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -projectileSideBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > projectileTopBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -projectileTopBound)
        {
            Destroy(gameObject);
        }

    }
}
