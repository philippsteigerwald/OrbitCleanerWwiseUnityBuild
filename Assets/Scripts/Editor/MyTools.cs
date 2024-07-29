
using UnityEngine;
using UnityEditor;

static class MyTools 
{

	// [MenuItem("My Tools/1. Add Defaults To Report %F2")]
	// static void DEV_AppendDefaultsToReport()
	// {
	// 	CSVManager.AppendToReport( // feed it the string that its expecting in the Method
	// 				new string[5]
	// 		{
	// 			"john",
	// 			Random.Range(0,11).ToString(),
	// 			Random.Range(0,11).ToString(),
	// 			Random.Range(0,11).ToString(),
	// 			Random.Range(0,11).ToString(),
	// 		}
	// 	);
	// 	EditorApplication.Beep();
	// 	Debug.Log("<color=green>Report Updated Sucessfully!</color>");
	// }
	


	
	
	[MenuItem("My Tools/2. Reset Report %F12")]
	static void DEV_ResetReport()
	{
		CSVManager.CreateReport();
		EditorApplication.Beep();
		Debug.Log("<color=orange>The Report has been reset...</color>");
		
	}
}
