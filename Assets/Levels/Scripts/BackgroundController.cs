/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Скрипт позволяет контроллировать создание бесконечных задних фонов без разрывов
public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform _background;//Задний фон
    private Transform _newBackground;//Новый задний фон

    [SerializeField] private Vector2 _posForCreateBG;//Позиция, при которой создается новый бэкграунд
    [SerializeField] private Vector2 _posForNewBG;//Позиция, где создается новый бэкграунд

    private void Start()
    {
        _newBackground = Instantiate(_background, _background.position, Quaternion.identity, transform) as Transform;//На старте создается бэкграунд
    }

    private void Update()
    {
        if(_newBackground.position.x <= _posForCreateBG.x)//Если бэкграунд перешел позицию, при которой создается новый бэкграунд
        {
            _newBackground = Instantiate(_background, _posForNewBG, Quaternion.identity, transform) as Transform;//Создать новый бэкграунд
        }
    }
}
