using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text bestScore;

    // Передаёт значение максимально набранных очков из PlayerPrefs в текстовое поле на канвасе
    private void Start()
    {
        bestScore.text = ("Your best score: " + PlayerPrefs.GetInt("bestScore"));
    }
}
