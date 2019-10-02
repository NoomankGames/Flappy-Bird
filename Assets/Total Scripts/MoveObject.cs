/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Позволяет двигать объект с заданной скоростью и направлением
public class MoveObject : MonoBehaviour
{
    [SerializeField] private float _speed = 0.25f;//Скорость движения

    [SerializeField] private Vector2 _moveVector;//Вектор движения

    private void Update()
    {
        if (Bird.instance.alive == true)//Если птичка жива
        {
            transform.Translate(_moveVector * _speed * Time.deltaTime);//Двигать объект в заданном векторе с указанной скоростью
        }
    }
}
