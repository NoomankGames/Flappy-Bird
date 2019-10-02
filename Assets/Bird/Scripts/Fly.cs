/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
//Позволяет объекту взмахивать крыльями, чтобы подняться выше
public class Fly : MonoBehaviour
{
    [SerializeField] private float _swingForce = 5.0f;//Сила взмаха

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _swing;//Звук, означающий взмах крыльями

    private Bird _thisBird;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _thisBird = GetComponent<Bird>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _audioSource.playOnAwake = false;//Отключить проигрывание на старте игры
        _audioSource.loop = false;//Отключить зацикливание проигрывания
        _audioSource.clip = _swing;//Поставить дорожку
    }

    private void Update()
    {
        if (_thisBird.alive == true)//Если эта птичка жива
        {
            //Если пользователь тапнул по экрану, но не нажал на UI-Элемент
            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                Swing();//Объект делает взмах               
            }
        }
    }

    private void LateUpdate()
    {
        if(GameManager.GamePause == true)//Если игра на паузе
        {
            _rigidbody.gravityScale = 0.0f;//Отключить гравитацию
        }
        else//Если игра не на паузе
        {
            _rigidbody.gravityScale = 1.0f;//Включить гравитацию
        }
    }

    private void Swing()//Реализует взмах, чтобы подняться выше
    {
        _rigidbody.velocity = Vector3.zero;//Обнулить вектор скорости перед взмахом, чтобы взлеты не суммировались
        _rigidbody.AddForce(Vector2.up * _swingForce, ForceMode2D.Impulse);//Дать толчок физическому объекту вверх
        _thisBird.zAngleValue = _thisBird.maxZAngle;
        _audioSource.Play();
    }
}
