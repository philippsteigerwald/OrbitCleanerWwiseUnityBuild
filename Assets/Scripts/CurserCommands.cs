using UnityEngine;


public class CurserCommands : MonoBehaviour
{

	public AK.Wwise.Event mouseLocatorStart;
    public AK.Wwise.Event mouseLocatorStop;

	public AK.Wwise.Event click;




 
	void Start()
	{
	   
	}
	void Update()
	{
		//if (Input.GetMouseButtonDown(1))
		if (Input.GetKeyDown("space"))
		
		{	

			Cursor.lockState = CursorLockMode.Locked;

			click.Post(gameObject);

			VariableManager.centeringsUsedThisStage++;
			
			Invoke(nameof(UnlockCursor),0.05f);
			
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

		//Vector3 mouseOnScreen = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		//this.transform.position = new Vector3(mouseOnScreen.x,0, mouseOnScreen.z);
		//transform.position = new Vector3(mouseOnScreen.x, 0, 0);
	}
	
	private void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;  
	}
	



}