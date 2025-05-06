using UnityEngine;
using UnityEngine.SceneManagement; // Dont forget this
public class sceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad); // This way we can load any scene
        }
    }
}
