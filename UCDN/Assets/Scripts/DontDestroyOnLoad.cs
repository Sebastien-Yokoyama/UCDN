using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Declare a public game object to hold the player object.
    public GameObject player;

    // Declare a private bool to check if the player object exists.
    private bool playerExists;

    // Declare a private int to hold the current scene index.
    private int currentSceneIndex;

    // Declare a private int to hold the previous scene index.
    private int previousSceneIndex;

    void Awake()
    {
        // Check if a player object exists in the scene.
        if (player != null)
        {
            playerExists = true;

            // Use the DontDestroyOnLoad function to preserve the player object across scenes.
            DontDestroyOnLoad(player);
        }
    }

    void Start()
    {
        // Get the current scene index.
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(string sceneName)
    {
        // Load the specified scene by name.
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        // Load the specified scene by index.
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadPreviousScene()
    {
        // Load the previous scene by index.
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void ExitGame()
    {
        // Quit the application.
        Application.Quit();
    }

    void OnEnable()
    {
        // Register the OnSceneLoaded function to the SceneManager.sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unregister the OnSceneLoaded function from the SceneManager.sceneLoaded event.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Get the current scene index.
        currentSceneIndex = scene.buildIndex;

        // Set the previous scene index to the current scene index.
        previousSceneIndex = currentSceneIndex - 1;

        // Check if the player object exists.
        if (playerExists)
        {
            // Check if the player object is not already in the scene.
            if (!GameObject.Find(player.name))
            {
                // Instantiate the player object in the scene.
                Instantiate(player);
            }
        }
    }
}

