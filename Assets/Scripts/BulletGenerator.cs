
using System.Collections;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    // Переменная для остановки корутины создания пуль(в случае проигрыша игрока)
    private Coroutine currentCoroutine;

    // Cсылка на префаб пули
    public GameObject bullet;

    // Проверка, жив ли игрок
    private bool playerDead;

    //Публичный параметр времени создания пуль, можно изменить в инспекторе 
    public float bulleTimeSpawn;

    private void Start()
    {
        currentCoroutine = StartCoroutine(BulletSpawn());
    }

    private void Update()
    {
        // Проверяем добрался ли враг до игрока
        playerDead = CheckCollision.gameOver;
    }

    public IEnumerator BulletSpawn()
    {
        while (!playerDead)
        {
            // Если враг не добрался до нас, создаем пули, с заданным интервалом по времени
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(bulleTimeSpawn);

            if (playerDead)
            {
                //Если добрался, то тормозим корутину создания пуль
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
            }
        }
    }
}



