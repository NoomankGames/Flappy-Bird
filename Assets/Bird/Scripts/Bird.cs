/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Здесь реализуется состояние птички
public class Bird : Singleton<Bird>
{
    [SerializeField] private Sprite _deadBird;//Изображение мертвой птички

    public float minZAngle = -30.0f;//Минимальный угол по Z
    public float maxZAngle = 30.0f;//Максимальный угол по Z
    [SerializeField] private float _rotateSpeed = 5.0f;//Скорость вращения
    [HideInInspector] public float zAngleValue = 0.0f;

    [SerializeField] private float _minHeight = -4.75f;//Минимальная высота на которой может находиться птичка
    [SerializeField] private float _maxHeight = 4.75f;//Максимальная высота на которой может находиться птичка

    [HideInInspector]public bool alive = true;//Птичка жива?

    [SerializeField] private AudioClip _hit;//Звук, означающий удар птички о препятстие
    [SerializeField] private AudioClip _die;//Звук, означающий смерть птички

    private AudioSource _audioSource;

    private void Awake()
    {
        zAngleValue = 0.0f;
        alive = true;//В начале игры птичка всегда жива   
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;//Отключить проигрывание на старте игры
        _audioSource.loop = false;//Отключить зацикливание проигрывания
    }

    private void Update()
    {
        if (transform.position.y <= _minHeight)//Если птичка ниже или на уровне минимальной высоты
        {
            Kill();//Убить птичку
            transform.position = new Vector2(transform.position.x, _minHeight);//Поместить птичку на минимальную высоту
        }
        else if (transform.position.y >= _maxHeight)//Если птичка выше или на уровне максимальной высоты
        {
            transform.position = new Vector2(transform.position.x, _maxHeight);//Поместить птичку на максимальную высоту
        }

        if (zAngleValue < minZAngle) zAngleValue = minZAngle;
        else if (zAngleValue > maxZAngle) zAngleValue = maxZAngle;
        zAngleValue -= Time.deltaTime * _rotateSpeed;
        transform.localEulerAngles = new Vector3(0, 0, zAngleValue);

        //Если ранее проигрывался звук удара птички о препятствие и проигрывание закончилось
        if (_audioSource.clip == _hit && _audioSource.isPlaying == false)
        {
            //Проиграть звук смерти
            _audioSource.clip = _die;
            _audioSource.Play();
        }
        else if (_audioSource.clip == _die && _audioSource.isPlaying == false)
        {
            _audioSource.enabled = false;
        }
    }

    public void Kill()//Реализует смерть птички
    {
        if (alive == true)
        {
            alive = false;//Птичка больше не жива
            GetComponent<SpriteRenderer>().sprite = _deadBird;//Визуализация мертвой птички

            _audioSource.clip = _hit;
            _audioSource.Play();
            GetComponent<Fly>().enabled = false;//Птичка больше летать не может
        }
    }
}
