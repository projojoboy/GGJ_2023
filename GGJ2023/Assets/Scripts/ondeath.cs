using UnityEngine;
using UnityEngine.SceneManagement;

public class ondeath : MonoBehaviour
{
    public GameObject deathscreen;
    void Start()
    {
        deathscreen.SetActive(false);
    }
    void DeathScreen()
    {
        deathscreen.SetActive(true);
        GetComponent<movement>().DisableMovement();
        GetComponent<punch>().enabled = false;
    }

    private void Update()
    {
        if (deathscreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
