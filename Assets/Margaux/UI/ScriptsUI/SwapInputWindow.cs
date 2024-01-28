using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapInputWindow : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent = null;
    [SerializeField] GameObject pauseMenu = null;
    [SerializeField] GameObject scoreText = null;
    [SerializeField] InputAction pause = null;
    [SerializeField] Controls controls = null;

    public InputAction Pause => pause;

    private void Awake()
    {
        controls = new Controls();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StatePauseMenuOnClick(InputAction.CallbackContext _context)
    {
        if (pauseMenu != null)
        {
            Debug.Log("SetActive");
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);

            if (pauseMenu.activeSelf)
            {
                Debug.Log("Pause");
                scoreText.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }
    private void OnEnable()
    {
        pause = controls.Runner.Pause;
        pause.Enable();
        pause.performed += StatePauseMenuOnClick;
    }
}
    
