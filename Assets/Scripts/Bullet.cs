
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        // Отправляем пулю вперед, и уничтожаем через 1,5сек.
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 800f);
        Destroy(gameObject, 1.5f);
    }
}
