
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerUpHandler
{
    // Публичная переменная для перехода на указанную сцену 
    public int sceneNumber;
    public void OnPointerUp(PointerEventData eventData)
    {

        SceneManager.LoadScene(sceneNumber);

    }


}
