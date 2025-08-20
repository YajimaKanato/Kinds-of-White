using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonAction : MonoBehaviour
{
    public void InfoOpen(GameObject info)
    {
        info.SetActive(true);
    }

    public void InfoClose(GameObject info)
    {
        info.SetActive(false);
    }

    public void SceneTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Hint(Text text)
    {
        text.text = "���̐��F" + FindFirstObjectByType<WhiteSetter>().WhiteNum;
    }

    public void Enter(ImnotRobotManager robot)
    {
        robot.PressedEnter();
        StartCoroutine(WaitCoroutine());
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneTransition("Security");
        yield break;
    } 
}
