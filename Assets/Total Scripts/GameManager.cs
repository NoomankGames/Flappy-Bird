/*
 * author : Kirakosyan Nikita Andreevich
 * e-mail : noomank.games@gmail.com
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Контроллирует процесс игры
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Text _score;//Отображение очков птички
    [SerializeField] private GameObject _menu;//Меню игрока

    public static int Score = 0;//Кол-во очков у птички
    public static bool GamePause { get; private set; }//Пауза игры

    private void Awake()
    {
        GamePause = true;//До начала игры она будет находиться на паузе
    }

    private void Update()
    {
        if(Bird.instance.alive == false)//Если птичка мертва
        {
            _menu.SetActive(true);//Выключить меню игрока
            _menu.transform.Find("Start Button").GetComponent<Image>().color = Color.gray;//Сделать кнопку старта серой
            _menu.transform.Find("Start Button").GetComponent<Button>().interactable = false;//Отключить кнопку старта
        }
        else//Если птичка жива
        {
            if (GamePause == true)//Если игра на паузе
            {
                Time.timeScale = 0.0f;//Остановить время
            }
            else//Если игра не на паузе
            {
                _menu.SetActive(false);//Выключить меню игрока
                Time.timeScale = 1.0f;//Включить время
            }
        }
    }

    private void LateUpdate()
    {
        _score.text = Score.ToString();
    }

    public void ChangeGameMode()//Изменить режим игры
    {
        if (GamePause == true) GamePause = false;//Если игра стояла на паузе, то перевести её в режим проигрывания
        else GamePause = true;//Если игра была в режиме проигрываения, но поставить её на паузу
    }

    public void RestartLevel()//Перезапуск уровня
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Загрузить этот же уровень
    }
}
