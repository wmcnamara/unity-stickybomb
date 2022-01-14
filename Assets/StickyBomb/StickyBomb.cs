using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StickyBomb : MonoBehaviour
{

    [Header("Explosion Config")]

    [Tooltip("The force of the explosion (which may be modified by distance).")]
    [SerializeField] private float explosionForce = 10.0f;

    [Tooltip("The radius of the sphere within which the explosion has its effect.")]
    [SerializeField] private float explosionRadius = 10.0f;

    [Tooltip("A delay measured in seconds, that the bomb will wait after sticking to a surface before detonating.")]
    [SerializeField] private float explosionDelay = 1f;

    [Tooltip("Adjustment to the apparent position of the explosion to make it seem to lift objects.")]
    [SerializeField] private float explosionUpwardForce = 1.0f;


    [Header("FX")]

    [Tooltip("Optional explosion effect that will be spawned on the bomb on detonation. Leave empty for no effect.")]
    [SerializeField] private GameObject explosionEffect;

    [Tooltip("Optional explosion audio clip that will be played when the bomb detonates. Leave empty for no sound.")]
    [SerializeField] private AudioClip explosionSound;

    [Tooltip("The volume scale of the explosion sound")]
    [SerializeField] [Range(0.0f, 1.0f)] private float explosionVolume = 1.0f;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    public void Explode()
    {
        /*
            Spawn in explosion effect, and sound effect if the user has configured them in the inspector. 
        */
        if (explosionEffect != null)
        {
            var effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            if (explosionSound != null)
            {
                effect.AddComponent<AudioSource>().PlayOneShot(explosionSound, explosionVolume);
            }
        }

        /*
            Get every collider in the radius near the bomb, and apply an explosion force to each. 
        */
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