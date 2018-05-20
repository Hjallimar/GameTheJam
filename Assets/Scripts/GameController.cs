using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;
    public Text playerLife;

    private Quaternion orginalCameraRotation;

    [HideInInspector]
    public int coins;
    public int life;

    void Start()
    {
        gameControllerInstance = this;
        life = 9;
        orginalCameraRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        //playerLife.text = "x" + life;

    }


/*    public void ScreenShake()
    {
        Camera.main.DOShakeRotation(0.2f, 2, 40, 90);
        Invoke("ResetCameraRotaion", 0.2f);
    }*/

    private void ResetCameraRotaion()
    {
        Camera.main.transform.rotation = orginalCameraRotation;
    }

    public void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}