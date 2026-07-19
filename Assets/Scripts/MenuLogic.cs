using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneHandler.instance.LoadNextScene();
    }
}
