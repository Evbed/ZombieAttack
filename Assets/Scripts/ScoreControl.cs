using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{

    // Текущий счет игрока
    public static int playerScore;

    // Ссылки на текстовые объекты
    public Text textScore, gameOverScore;

    private void Start()
    {
        // Количество очков в новой сессии
        playerScore = 0;
    }

    private void Update()
    {
        // Если текущий счет больше лучшего счета, записываем его
        if (PlayerPrefs.GetInt("bestScore") < playerScore)
        {
            PlayerPrefs.SetInt("bestScore", playerScore);
        }

        // Выводим текущий счет в углу экрана
        textScore.text = ("Score: " + playerScore.ToString());

        // Выводим текущий счет на экране поражения
        gameOverScore.text = ("Current score: " + playerScore.ToString());
    }
}
