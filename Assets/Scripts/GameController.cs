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
        playerLife.text = "x" + life;

    }

    private void ResetCameraRotaion()
    {
        Camera.main.transform.rotation = orginalCameraRotation;
    }

    public void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}