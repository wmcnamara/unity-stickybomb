using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class StickyBomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private float explosionForce = 10.0f;
    [SerializeField] private float explosionRadius = 10.0f;
    [SerializeField] private float explosionDelay = 1.5f;
    [SerializeField] private float explosionUpwardForce = 1.0f;

    private AudioSource source;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        rb.isKinematic = false;
    }

    public void Explode()
    {
        Debug.Log("Exploded!");

        source.PlayOneShot(explosionSound);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody hitRb = hit.GetComponent<Rigidbody>();

            if (hitRb != null)
            {
                hitRb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpwardForce);
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;

        Invoke(nameof(Explode), explosionDelay);
    }
}