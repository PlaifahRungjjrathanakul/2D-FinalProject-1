using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    public AudioClip collecter;           // เสียงกระโดด
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจว่าเป็นวัตถุภายใต้กลุ่ม item
        if (collision.transform.parent != null && collision.transform.parent.name == "item")
        {
            // สร้าง Particle ตำแหน่งของ item
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(collecter);
            }

            // ทำลาย item ที่ชน
            Destroy(collision.gameObject);
        }
    }
}