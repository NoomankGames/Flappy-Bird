/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Скрипт удаляет объект спустя заданный промежуток времени
public class DestroyAfterDelay : MonoBehaviour
{ 
    [SerializeField] private bool _destroyAfterPlayingSound = false;//Удалить объект после проигрывания звука?

    [SerializeField] private float _delay = 10.0f;//Промежуток времени, через который уничтожается объект

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //Если у объекта есть источник звука и уничтожение происходит после проигрывания дорожки, то промежуток времени = длине проигрываемой дорожке
        if (_audioSource != null && _destroyAfterPlayingSound == true) _delay = _audioSource.clip.length;
    }

    private void Update()
    {
        Destroy(gameObject, _delay);//Уничтожить объект через заданный промежуток времени
    }
}
