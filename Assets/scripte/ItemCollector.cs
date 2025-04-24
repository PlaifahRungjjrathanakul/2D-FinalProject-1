using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public AudioClip collecter;           // ���§���ⴴ
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ������ѵ����������� item
        if (collision.transform.parent != null && collision.transform.parent.name == "item")
        {
            // ���ҧ Particle ���˹觢ͧ item
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(collecter);
            }

            // ����� item ��誹
            Destroy(collision.gameObject);
        }
    }
}