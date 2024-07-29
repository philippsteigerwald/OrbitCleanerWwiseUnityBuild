using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReportWriter : MonoBehaviour
{
	
	public VariableManager variableManager;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
		public void AppendToReportEmtpy() // If we start a new game do empty row
	{
		CSVManager.AppendToReport // feed it the string that its expecting in the Method
				( 
					

				
					new string[36]
					{
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
				 		" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",
						" ",

						
					}
				);
		
					Debug.Log("<color=green>Report Updated Sucessfully!</color>");

	}

	
	public void AppendToReportTutorialAndID() // set player ID after the first level along with report
	{
		CSVManager.AppendToReport // feed it the string that its expecting in the Method
				( 
					

					new string[37]
					{
						
						variableManager.subjectID,
						variableManager.gameVersion,
						"Tutorial",
						" ",
						variableManager.score.ToString(),
						VariableManager.deltaRotationAngleThisStage.ToString(),
						variableManager.timeSpentInTutorial.ToString(),
						System.DateTime.UtcNow.ToString(),
						" ",
						" ",
						VariableManager.buttonsPressedThisStage.ToString(),
						VariableManager.actionsExecutedThisStage.ToString(),
						VariableManager.sucessfullHitsThisStage.ToString(),
						VariableManager.hitsTakenThisStage.ToString(),
						VariableManager.precisionScoreThisStage.ToString(),
						VariableManager.spamIndexThisStage.ToString(),
						VariableManager.centeringsUsedThisStage.ToString(),
						" ",
						VariableManager.astronautsSpawnedThisStage.ToString(),
						VariableManager.astronautsDestroyedThisStage.ToString(),
						VariableManager.astronautsStruckThisStage.ToString(),
						VariableManager.astronautSucessRateThisStage.ToString(),
						" ",
						VariableManager.aliensSpawnedThisStage.ToString(),
						VariableManager.aliensDestroyedThisStage.ToString(),
						VariableManager.aliensStruckThisStage.ToString(),
						VariableManager.alienSucessRateThisStage.ToString(),
						" ",
						VariableManager.lasersSpawnedThisStage.ToString(),
						VariableManager.lasersDestroyedThisStage.ToString(),
						VariableManager.lasersStruckThisStage.ToString(),
						VariableManager.laserSucessRateThisStage.ToString(),
						" ",
						VariableManager.asteroidsSpawnedThisStage.ToString(),
						VariableManager.asteroidsDestroyedThisStage.ToString(),
						VariableManager.asteroidsStruckThisStage.ToString(),
						VariableManager.asteroidSucessRateThisStage.ToString(),




					}
				);
		
					Debug.Log("<color=green>Report Updated Sucessfully!</color>");

	}
	
	public void AppendToReport() // set report without player ID
	{
		CSVManager.AppendToReport // feed it the string that its expecting in the Method
				( 
					new string[37]
					{
						" ",
						" ",
						VariableManager.levelCount.ToString(),
						VariableManager.scoreLostThisStage.ToString(),
						variableManager.score.ToString(),
						VariableManager.deltaRotationAngleThisStage.ToString(),
						" ",
						" ",
						" ",
						" ",
						VariableManager.buttonsPressedThisStage.ToString(),
						VariableManager.actionsExecutedThisStage.ToString(),
						VariableManager.sucessfullHitsThisStage.ToString(),
						VariableManager.hitsTakenThisStage.ToString(),
						VariableManager.precisionScoreThisStage.ToString(),
						VariableManager.spamIndexThisStage.ToString(),	
						VariableManager.centeringsUsedThisStage.ToString(),					
						" ",
						VariableManager.astronautsSpawnedThisStage.ToString(),
						VariableManager.astronautsDestroyedThisStage.ToString(),
						VariableManager.astronautsStruckThisStage.ToString(),
						VariableManager.astronautSucessRateThisStage.ToString(),
						" ",
						VariableManager.aliensSpawnedThisStage.ToString(),
						VariableManager.aliensDestroyedThisStage.ToString(),
						VariableManager.aliensStruckThisStage.ToString(),
						VariableManager.alienSucessRateThisStage.ToString(),
						" ",
						VariableManager.lasersSpawnedThisStage.ToString(),
						VariableManager.lasersDestroyedThisStage.ToString(),
						VariableManager.lasersStruckThisStage.ToString(),
						VariableManager.laserSucessRateThisStage.ToString(),
						" ",
						VariableManager.asteroidsSpawnedThisStage.ToString(),
						VariableManager.asteroidsDestroyedThisStage.ToString(),
						VariableManager.asteroidsStruckThisStage.ToString(),
						VariableManager.asteroidSucessRateThisStage.ToString(),



					}
				);
		
					Debug.Log("<color=green>Report Updated Sucessfully!</color>");

	}
	
	
	public void AppendToReportWithSum() // at the end sum everything up
	{
		CSVManager.AppendToReport // feed it the string that its expecting in the Method
				( 
					new string[37]
					{

						variableManager.subjectID,
						variableManager.gameVersion,
						"Final Sum",
						" ",
						variableManager.score.ToString(),
						variableManager.deltaRotationAngle.ToString(),
						variableManager.timeSpentInTutorial.ToString(),
						System.DateTime.UtcNow.ToString(),
						" ",
						" ",
						VariableManager.buttonsPressed.ToString(),
						VariableManager.actionsExecuted.ToString(),
						VariableManager.sucessfullHits.ToString(),
						VariableManager.hitsTaken.ToString(),
						VariableManager.precisionScore.ToString(),
						VariableManager.spamIndex.ToString(),
						VariableManager.centeringsUsed.ToString(),						
						" ",
						VariableManager.astronautsSpawned.ToString(),
						VariableManager.astronautsDestroyed.ToString(),
						VariableManager.astronautsStruck.ToString(),
						VariableManager.astronautSucessRate.ToString(),
						" ",
						VariableManager.aliensSpawned.ToString(),
						VariableManager.aliensDestroyed.ToString(),
						VariableManager.aliensStruck.ToString(),
						VariableManager.alienSucessRate.ToString(),
						" ",
						VariableManager.lasersSpawned.ToString(),
						VariableManager.lasersDestroyed.ToString(),
						VariableManager.lasersStruck.ToString(),
						VariableManager.laserSucessRate.ToString(),
						" ",
						VariableManager.asteroidsSpawned.ToString(),
						VariableManager.asteroidsDestroyed.ToString(),
						VariableManager.asteroidsStruck.ToString(),
						VariableManager.asteroidSucessRate.ToString(),
						



					}
				);
		
					Debug.Log("<color=green>Report Updated Sucessfully!</color>");

	}
}
