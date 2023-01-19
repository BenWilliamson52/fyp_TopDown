using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Points" ;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("levelone");
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
