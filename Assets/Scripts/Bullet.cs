using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private float startForce = 600f;
    private Rigidbody rb;
    public delegate void OnBulletExplodedDelegate(Bullet b);

    public OnBulletExplodedDelegate OnBulletExploded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Orientación de la bala en función de su velocidad (para que apunte hacia la dirección en la que se mueve)
        transform.rotation = Quaternion.LookRotation(rb.linearVelocity);
    }

    public void Shot()
    {
        rb.AddForce(transform.forward * startForce, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision other)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        OnBulletExploded?.Invoke(this);
        
        Destroy(gameObject);
    }
}
