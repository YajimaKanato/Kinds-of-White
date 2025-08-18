using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        text.text = "îíÇÃêîÅF" + FindFirstObjectByType<WhiteSetter>().WhiteNum;
    }

    public void Enter(ImnotRobotManager robot)
    {
        robot.PressedEnter();
        SceneTransition("White");
    }
}
