/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;

//Этот класс позволяет другим объектам ссылаться на единственный
//общий объект. Используется в классах GameManager и InputManager
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    //Метод доступа. В первом вызове настроит свойство _instance.
    //Если требуемый объект не найден, выводит сообщение об ошибке
    public static T instance
    {
        get
        {
            //Если свойство _instance ещё не настроено ...
            if (_instance == null)
            {
                //Попытаться найти объект
                _instance = FindObjectOfType<T>();

                //Вывести ошибку в случае неудачи
                if (_instance == null)
                {
                    Debug.LogError("Can't find " + typeof(T) + "!");
                }
            }

            //Вернуть экземпляр для использования!
            return _instance;
        }
    }
}
