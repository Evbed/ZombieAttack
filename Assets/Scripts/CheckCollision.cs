
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    // Указываем потерпели поражение или нет
    public static bool gameOver;

    // Ссылка на окно поражения
    public GameObject gameOverScreen;
    Animator anim;
    private void Start()
    {
        // Кэшируем Аниматор объекта
        anim = GetComponent<Animator>();
        gameOver = false;
    }

    // Проверка на соприкосновение с врагом по тегу
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Включаем анимацию гибели персонажа
            anim.SetInteger("State", 1);

            // Даем другим обьектам понять что игрок погиб
            gameOver = true;

            // Включаем окно поражения
            gameOverScreen.SetActive(true);

            // Отключаем скрипт управления (что бы персонаж не реагировал на положение мыши после проигрыша)
            gameObject.GetComponent<TouchController>().enabled = false;
        }
    }
}
