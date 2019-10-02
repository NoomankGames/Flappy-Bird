/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//В скрипте контроллируется столкновение птички с препятствием, преодоление препятствия,
//Проигрывание звуков и зарабатывание очков.
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Если столкнувшийся объект - это игрок
        if (collision.transform.CompareTag("Player"))
        {
            Bird.instance.Kill();//Убить птичку
        }
    }
}
