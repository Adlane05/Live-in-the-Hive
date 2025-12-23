using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // ✅ Subscribe properly
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // ✅ Prevent duplicate callbacks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Only run in End scene
        if (scene.name != "End")
            return;

        // Only if THIS object is Inventory
        if (gameObject.name != "Inventory")
            return;

        // ✅ Works even if inactive
        gameObject.SetActive(true);
    }
}
