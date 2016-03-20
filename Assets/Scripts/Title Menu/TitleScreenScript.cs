using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public Canvas quitMenu;
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void PlayClick() 
    {
        SceneManager.LoadScene(1); // load level 1       
    }

    public void QuitClick()
    {       
        quitMenu.enabled = true; 
        var color = playButton.colors;
        color.normalColor = Color.clear;
        playButton.enabled = false; 
        playButton.colors = color;
        quitButton.enabled = false;
        quitButton.colors = color;
    }

    public void NoClick() 
    {
        quitMenu.enabled = false; 
        var color = playButton.colors;
        color.normalColor = Color.black;
        playButton.enabled = true; 
        playButton.colors = color;
        quitButton.enabled = true;
        quitButton.colors = color;
    }
    
    public void ExitGame() 
    {
        Application.Quit(); // quit the game 
    }
}
