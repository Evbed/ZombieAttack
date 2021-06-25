using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Массив на 10 зомби: (6 - рядовые(60%), 3 - бывалые(30%), 1 - бронированный(10%))
    public GameObject[] enemies;

    // Промежуток времени для создания врага
    private float timeOfRespawn;

    private void Start()
    {
        // Стратовое значение времени спавна зомби    
        timeOfRespawn = 2f;

        // Запуск корутин
        StartCoroutine(ZombieSpawn());
        StartCoroutine(TimeOfSpawn());
    }

    private IEnumerator ZombieSpawn()
    {
        while (true)
        {
            // Угол создания врага относительно нулевых координат
            float randDirection = Random.Range(0, 180);

            // Позиция спавна зомби за передлами экрана
            float posX = transform.position.x + (Mathf.Cos((randDirection) * Mathf.Deg2Rad) * 12);
            float posZ = transform.position.z + (Mathf.Sin((randDirection) * Mathf.Deg2Rad) * 12);

            // Создаём рандомного врага на заданных координатах  
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(posX, 0, posZ), Quaternion.identity);
            
            // Задаем периодичность спавна 
            yield return new WaitForSeconds(timeOfRespawn);
        }
    }

    private IEnumerator TimeOfSpawn()
    {
        // Уменьшаем время спавна каждые 10 сек, до тех пока пока оно не будет минимальным(0,5 сек)
        while (timeOfRespawn != 0.5f)
        {
            timeOfRespawn -= 0.1f;
            yield return new WaitForSeconds(10);
        }
    }
}
