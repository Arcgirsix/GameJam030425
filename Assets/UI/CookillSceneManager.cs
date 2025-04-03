using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Cookill.SceneManagement
{
    public class CookillSceneManager : MonoBehaviour
    {
        public int thisScene;
        [SerializeField] private List<GameObject> menu;

        public void SceneSelection(int sceneIndex)
        {
            thisScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);

        }

        public void CloseGame()
        {
            Application.Quit();
        }
    }
}
