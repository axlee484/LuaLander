using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    private SceneManager sceneManager;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }
    void Start()
    {
        sceneManager = SceneManager.Instance;
    }
    private void OnStartButtonClick()
    {
        sceneManager.LoadScene(SCENE_TYPE.GAME_SCENE);
    }
    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
