using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneSwitcher : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject youWinPanel;
    public GameObject youLossPannel;
    
   

    private AudioSource UISound;
    public AudioClip buttonSound;
    public BoolVariable showYouWin;
    public IntVariable unlockButton;
    public IntVariable increasePos;
    public IntVariable currentLevel;


    public GameEvent addUnlockPosition;
    private void Update()
    {
        if (showYouWin.Value == true)
        {
            StartCoroutine(waitToShowYouWin());
        
        }
    }

    private void Start()
    {
        showYouWin.Value = false;
        UISound = GetComponent<AudioSource>();

        

    }

    IEnumerator waitToShowYouWin()
    {
        yield return new WaitForSeconds(2);
        unlockNewLevel();
        addUnlockPosition.Raise();
        showYouWin.Value = false;
        youWinPanel.SetActive(true);
       
        StopAllCoroutines();
    }
    IEnumerator playButtonSoundWait()
    {
        UISound.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("scene0");
    }
    public void PlayGame()
    {

        StartCoroutine(playButtonSoundWait());
        Time.timeScale = 1f;
    }
    public void NextLevel()
    {

        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("LevelSelection");
    }

    public void Home()
    {
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Main Menu");
    }

    public void restartGame()
    {
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }
    
    public void youLoss()
    {
        Time.timeScale = 0f;
        youLossPannel.SetActive(true);
      
       
        
    }
   

    public void pauseMenu()
    {
        UISound.PlayOneShot(buttonSound);
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
    }

    public void UnlockButtonAddPosition()
    {
        //unlockButton.Value += 1;
        increasePos.Value += 22;

        

    }

    public void Resume()
    {
        UISound.PlayOneShot(buttonSound);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("raoooooo");
        UISound.PlayOneShot(buttonSound);
        Application.Quit();
    }

    public void SetCurentLevel(int val)
    {
        currentLevel.Value = val;
    
    }

    public void level1()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 1");
    }
    public void level2()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 2");
    }
    public void level3()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 3");
    }

    public void level4()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 4");
    }
    public void level5()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 5");
    }
    public void level6()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 6");
    }
    public void level7()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 7");
    }
    public void level8()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 8");
    }
    public void level9()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 9");
    }
    public void level10()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 10");
    }
    public void level11()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 11");
    }
    public void level12()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 12");
    }
    public void level13()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 13");
    }
    public void level14()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 14");
    }
    public void level15()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 15");
    }
    public void level16()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 16");
    }
    public void level17()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 17");
    }
    public void level18()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 18");
    }
    public void level19()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 19");
    }
    public void level20()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 20");
    }
    public void level21()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 21");
    }
    public void level22()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 22");
    }
    public void level23()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 23");
    }
    public void level24()
    {
        Time.timeScale = 1f;
        UISound.PlayOneShot(buttonSound);
        SceneManager.LoadScene("Level 24");
    }
    void unlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }

}
