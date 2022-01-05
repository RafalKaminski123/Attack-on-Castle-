using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDA.Core
{
    public class LoadingSystem : MonoBehaviour
    {
        private int sceneToLoad;
        private int sceneToUnload;

        public void StartLoadingScene(int sceneIndex)
        {
            sceneToLoad = sceneIndex;
            sceneToUnload = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            var loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            yield return new WaitUntil(() => loadingOperation.isDone);
            StartUnloadingScene();
            sceneToLoad = -1;
        }

        private void StartUnloadingScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
            StartCoroutine(UnloadScene());
        }

        private IEnumerator UnloadScene()
        {
            var unloadingOperation = SceneManager.UnloadSceneAsync(sceneToUnload);
            yield return new WaitUntil(() => unloadingOperation.isDone);
            sceneToUnload = -1;
        }
    }
}
