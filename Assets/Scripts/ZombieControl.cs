
using UnityEngine;

public class ZombieControl : MonoBehaviour
{
    // Ссылка на игрока (нам нужна позиция  пространстве)
    public GameObject player;

    // Редактируемые переменные здоровья и награды для префабов зомби
    public int health, reward;

    private Animator anim;

    // Скорость перемещения зомби
    public float speedMove;
    private Rigidbody rb;

    private void Start()
    {
        // Кэшируем аниматор и rigibody

        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        // Поворачиваем зомби лицом на игрока и отправляем по направлению к нему
        transform.LookAt(player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedMove * Time.deltaTime);

        // Если здоровье зомби кончается включаем анимацию сметри, отключаем скрипт для перемещения
        // отключаем коллайдер (что бы пули могли пролетать насквозь, пока зомби падает), уничтожаем
        // его через 1 сек, и плюсуем награду
        if (health <= 0)
        {
            anim.SetInteger("State", 1);
            gameObject.GetComponent<ZombieControl>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 1f);
            ScoreControl.playerScore += reward;
        }
    }

    // Проверка на стокновение с пулей по тегу и вычитание ХП
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health--;
        }
    }
}
