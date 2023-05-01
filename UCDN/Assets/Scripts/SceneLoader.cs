using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Transform playerPrefab; // The player prefab to be moved between scenes
    public string newSceneName; // The name of the scene to be loaded

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the current scene
            Scene currentScene = SceneManager.GetActiveScene();

            // Load the new scene additively
            SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);

            // Get the new scene
            Scene newScene = SceneManager.GetSceneByName(newSceneName);

            // Check if a player object already exists in the new scene
            GameObject[] rootObjects = newScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.CompareTag("Player")) // or use obj.name == "Player" if you prefer
                {
                    Debug.LogWarning("A player object already exists in the new scene!");
                    Destroy(obj); // or move it to a different location
                    break;
                }
            }

            // Move the player to the new scene
            SceneManager.MoveGameObjectToScene(playerPrefab.gameObject, newScene);

            // Set the player's position in the new scene
            playerPrefab.position = new Vector3(0f, 2f, 0f);

            // Unload the current scene
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}