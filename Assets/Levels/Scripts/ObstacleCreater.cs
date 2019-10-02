/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Скрипт контроллирует создание препятствия для игрока с заданным промежутком времени и пространством
public class ObstacleCreater : MonoBehaviour
{
    [SerializeField] private Obstacle _topObstacle;//Препятствие сверху
    [SerializeField] private Obstacle _bottomObstacle;//Препятствие снизу

    [SerializeField] private float _minPositionY = 3.5f;
    [SerializeField] private float _maxPositionY = 7.5f;
    [SerializeField] private Vector2 _positionAtCreation = new Vector2(3, 0);//Позиция препятствия при создании

    [SerializeField] private float _minSpace = 9.0f;//Минимальное пространство между верхним и нижним препятствием
    [SerializeField] private float _maxSpace = 11.0f;//Максимальное пространство между верхним и нижним препятствием
    [SerializeField] private float _timer = 1.5f;//Время, через которое появляется каждое препятствие
    private float _resetTimer;

    private void Awake()
    {
        _resetTimer = _timer;
        _timer = 0.0f;
    }

    private void Update()
    {
        if (Bird.instance.alive == false)//Если птичка не жива
        {
            Destroy(gameObject);//Удалиться
        }

        //Если игра в режиме проигрывания
        if (GameManager.GamePause == false)
        {
            if (_timer > 0)//Если таймер все ещё идет
            {
                _timer -= Time.deltaTime;
            }
            else//Если таймер закончился
            {
                float positionY = Random.Range(_minPositionY, _maxPositionY);//Получить случайную высоту появления препятствия
                float space = Random.Range(_minSpace, _maxSpace);//Получить случайное пространство между верхней и нижней частями препятствия

                CreateObstacle(_topObstacle, positionY);//Создать верхнее препятствие со случайным пространством от нижней части
                CreateObstacle(_bottomObstacle, positionY - space);//Создать нижнее препятствие со случайным пространством от верхней части
                _timer = _resetTimer;//Вернуть таймер в исходное состояние
            }
        }
    }

    private void CreateObstacle(Obstacle creatingObstacle, float positionY)//Создает новое препятствие
    {
        Obstacle obstacleInstance = Instantiate(creatingObstacle) as Obstacle;
        obstacleInstance.transform.SetParent(transform);
        obstacleInstance.transform.position = new Vector2(_positionAtCreation.x, positionY);//Поместить созданное препятствие на место появления
    }
}
