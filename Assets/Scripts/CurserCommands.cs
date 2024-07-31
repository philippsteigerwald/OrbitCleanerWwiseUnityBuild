using UnityEngine;

public class CurserCommands : MonoBehaviour
{
    public AK.Wwise.Event mouseLocatorStart;
    public AK.Wwise.Event mouseLocatorStop;

    public AK.Wwise.Event click;

    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Cursor.lockState = CursorLockMode.Locked;

            click.Post(gameObject);

            VariableManager.centeringsUsedThisStage++;

            Invoke(nameof(UnlockCursor), 0.05f);
        }

        {
            if (Input.GetMouseButtonDown(1))
            {
                mouseLocatorStart.Post(gameObject);
            }

            if (Input.GetMouseButtonUp(1))
            {
                mouseLocatorStop.Post(gameObject);
            }
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
