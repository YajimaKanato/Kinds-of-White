using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonAction : MonoBehaviour
{
    public void InfoOpen(GameObject info)
    {
        SEManager.SEPlay("NormalButton");
        info.SetActive(true);
    }

    public void InfoClose(GameObject info)
    {
        SEManager.SEPlay("NormalButton");
        info.SetActive(false);
    }

    public void GoGame(string name)
    {
        SEManager.SEPlay("GoGame");
        SceneTransition(name);
    }

    public void GoBack(string name)
    {
        SEManager.SEPlay("BackButton");
        SceneTransition(name);
    }

    public void SceneTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Retry(string name)
    {
        SEManager.SEPlay("NormalButton");
        SceneManager.LoadScene(name);
    }

    public void Hint(Text text)
    {
        SEManager.SEPlay("NormalButton");
        text.text = "îíÇÃêîÅF" + FindFirstObjectByType<WhiteSetter>().WhiteNum;
    }

    public void Enter(ImnotRobotManager robot)
    {
        robot.PressedEnter();
        StartCoroutine(WaitCoroutine());
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        SceneTransition("Security");
        yield break;
    } 
}
