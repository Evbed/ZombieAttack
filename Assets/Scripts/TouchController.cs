using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    //Раскоменнтировать нужный метод ввода
    void Update()
    {
        // TouchControl();
        MouseControl();
    }

    private void TouchControl()
    {
        // Для тача
        // Если касаний экрана больше нуля:
        if (Input.touchCount > 0)
        {
            // Берем первый по счету тач из массива тачей
            Touch touch = Input.GetTouch(0);

            // Переводим точку касания из экранного в мировое пространство
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Кэшируем значения для нужных нам коррдинат
            Vector3 currentPos = new Vector3(touchPosition.x, 0, touchPosition.z);

            // Поворот игрока в сторону тача
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentPos), 20 * Time.deltaTime);
        }
    }

    private void MouseControl()
    {
        // Для мышки
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentMousePos = new Vector3(mousePos.x, 0, mousePos.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentMousePos), 20 * Time.deltaTime);
    }
}
