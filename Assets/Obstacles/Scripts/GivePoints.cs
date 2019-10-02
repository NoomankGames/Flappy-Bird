/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Выдает очки игроку
public class GivePoints : MonoBehaviour
{
    [SerializeField] private AudioClip _point;//Звук, означающий получение очков

    private bool _pointsGiven = false;//Очки были даны?

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;//Отключить проигрывание на старте игры
        _audioSource.loop = false;//Отключить зацикливание проигрывания
        _audioSource.clip = _point;//Поставить дорожку
    }

    private void Update()
    {
        if (transform.position.x <= Bird.instance.transform.position.x)//Если объект позади птички
        {
            if (_pointsGiven == false)//Если очки не были выданы игроку
            {
                _audioSource.Play();//Проиграть дорожку
                GameManager.Score++;//Выдать очки игроку
                _pointsGiven = true;//Очки были выданы
            }
            else
            {
                if(_audioSource.isPlaying == false)
                {
                    Destroy(this);//Уничтожить этот компонент после проигрывания
                }
            }
        }
    }
}
