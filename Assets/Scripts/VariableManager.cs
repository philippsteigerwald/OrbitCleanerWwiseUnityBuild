using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    public static float asteroidCount;
    public static float astronautCount;

    public static float laserCount;

    public static float alienCount;

    public static float objectCount;

    public static int asteroidsSpawnedThisStage;
    public static int astronautsSpawnedThisStage;
    public static int lasersSpawnedThisStage;
    public static int aliensSpawnedThisStage;

    public static int asteroidsDestroyed;
    public static int astronautsDestroyed;
    public static int lasersDestroyed;
    public static int aliensDestroyed;

    public static int asteroidsDestroyedThisStage;
    public static int astronautsDestroyedThisStage;
    public static int lasersDestroyedThisStage;
    public static int aliensDestroyedThisStage;

    public static int asteroidsSpawned;
    public static int astronautsSpawned;
    public static int lasersSpawned;
    public static int aliensSpawned;

    public static int asteroidsStruckThisStage;
    public static int astronautsStruckThisStage;
    public static int lasersStruckThisStage;
    public static int aliensStruckThisStage;

    public static int asteroidsStruck;
    public static int astronautsStruck;
    public static int lasersStruck;
    public static int aliensStruck;

    public static float alienSucessRate;
    public static float astronautSucessRate;
    public static float asteroidSucessRate;
    public static float laserSucessRate;

    public static float alienSucessRateThisStage;
    public static float astronautSucessRateThisStage;
    public static float asteroidSucessRateThisStage;
    public static float laserSucessRateThisStage;

    public static float precisionScore;
    public static float precisionScoreThisStage;

    public static float spamIndex;
    public static float spamIndexThisStage;

    public static int centeringsUsed;

    public static int centeringsUsedThisStage;

    private float initialRotation;
    private float rotationDeltaZ;

    public static float timeLeft;
    public static int buttonsPressed = 0;
    public static int actionsExecuted = 0;
    public static int sucessfullHits = 0;
    public static int hitsTaken = 0;
    public static int levelCount = 0;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public float spawnCoolDown;

    [HideInInspector]
    public string subjectID;

    [HideInInspector]
    public bool inTransition = false;

    [HideInInspector]
    public bool stunned = false;

    [HideInInspector]
    public bool inGame = false;

    [HideInInspector]
    public bool countdownOn = false;

    public static int buttonsPressedThisStage = 0;
    public static int actionsExecutedThisStage = 0;
    public static int hitsTakenThisStage = 0;
    public static int sucessfullHitsThisStage = 0;
    public static float deltaRotationAngleThisStage = 0;

    public static float scoreLostThisStage = 0;

    private static float scoreLastStage = 1000;

    [Header("Collider Interactions")]
    public int alienAstronautEnergyCost = 5; // for ColliderSpawner
    public int alienAstronautAsteroidLaserImpactEnergyCost = 10; // for spacecraft
    public int alienAstronautAsteroidCollectionEnergyGain = 15; // for ColliderSpawner
    public int laserAsteroidEnergyCost = 10; // for ColliderSpawner
    public int laserCollectionGain = 25; // for ColliderSpawner
    public int asteroidStunDuration = 5; // for ColliderSpawner

    public int playerV2Position;

    [Header("General Gameparameters")]
    private bool timerOn = false;

    public int startScore = 1000;
    public int levelDuration = 60;

    public float actionCooldownTime = 0.2f;

    public float nextInvertSwitch = 15f;
    public float transitionTime = 6;

    public float startTransition = 9;
    public int spawnDistanceCircular = 60;

    public int spawnDistanceCircularV2 = 55;

    public int spawnDistanceStraight = 60;
    public float spawnDelay;

    [HideInInspector]
    public int spawnCap;

    [Range(0, 100)]
    public int bottomSpawnAngleV2;

    [Range(0, 100)]
    public int topSpawnAngleV2;
    public int trajectoryVariance = 10;

    [Range(0, 3)]
    public float tutorialObjectSpeedStraight;

    [Range(1, 5)]
    public float tutorialObjectSpeedCircular;

    [Range(0, 2)]
    public float slowTutorialObjectSpeedCircular;

    public int rotationAngle = 80;

    public bool enableV2 = false;

    [HideInInspector]
    public bool enableTutorial = false;

    [HideInInspector]
    public bool blackCurtainActive = false;

    [HideInInspector]
    public bool groupOne;

    [HideInInspector]
    public bool groupTwo;

    [HideInInspector]
    public string gameVersion;

    public bool compileSettings = false;

    [Header("Action Stage 1 Spawner Parameters")]
    [Range(1, 4)]
    public int spawnCap_1;
    public float spawnCoolDown_1;

    [Range(0, 3)]
    public float objectSpeedStraight_1;

    [Range(1, 5)]
    public float objectSpeedCircle_1;

    public bool astronautActive_1;
    public bool alienActive_1;
    public bool laserActive_1;
    public bool asteroidActive_1;
    public bool invertRotationOn_1;

    public bool sameSpawns_1;

    [Header("Action Stage 2 Spawner Parameters")]
    [Range(1, 4)]
    public int spawnCap_2;
    public float spawnCoolDown_2;

    [Range(0, 3)]
    public float objectSpeedStraight_2;

    [Range(1, 5)]
    public float objectSpeedCircle_2;

    public bool astronautActive_2;
    public bool alienActive_2;
    public bool laserActive_2;
    public bool asteroidActive_2;
    public bool invertRotationOn_2;
    public bool sameSpawns_2;

    [Header("Action Stage 3 Spawner Parameters")]
    [Range(1, 4)]
    public int spawnCap_3;
    public float spawnCoolDown_3;

    [Range(0, 3)]
    public float objectSpeedStraight_3;

    [Range(1, 5)]
    public float objectSpeedCircle_3;

    public bool astronautActive_3;
    public bool alienActive_3;
    public bool laserActive_3;
    public bool asteroidActive_3;

    public bool invertRotationOn_3;
    public bool sameSpawns_3;

    [Header("Action Stage 4 Spawner Parameters")]
    [Range(1, 4)]
    public int spawnCap_4;
    public float spawnCoolDown_4;

    [Range(0, 3)]
    public float objectSpeedStraight_4;

    [Range(1, 5)]
    public float objectSpeedCircle_4;

    public bool astronautActive_4;
    public bool alienActive_4;
    public bool laserActive_4;
    public bool asteroidActive_4;
    public bool invertRotationOn_4;
    public bool sameSpawns_4;

    [Header("Action Stage 5 Spawner Parameters")]
    [Range(1, 4)]
    public int spawnCap_5;
    public float spawnCoolDown_5;

    [Range(0, 3)]
    public float objectSpeedStraight_5;

    [Range(1, 5)]
    public float objectSpeedCircle_5;

    public bool astronautActive_5;
    public bool alienActive_5;
    public bool laserActive_5;
    public bool asteroidActive_5;
    public bool invertRotationOn_5;
    public bool sameSpawns_5;

    [Header("Slow Stage 1 Spawner Parameters")]
    [Range(1, 4)]
    public int slowSpawnCap_1;
    public float slowSpawnCoolDown_1;

    [Range(0, 2)]
    public float slowObjectSpeedStraight_1;
    public bool slowAstronautActive_1;
    public bool slowAlienActive_1;
    public bool slowSameSpawns_1;

    [Header("Slow Stage 2 Spawner Parameters")]
    [Range(1, 4)]
    public int slowSpawnCap_2;
    public float slowSpawnCoolDown_2;

    [Range(0, 2)]
    public float slowObjectSpeedStraight_2;
    public bool slowAstronautActive_2;
    public bool slowAlienActive_2;
    public bool slowSameSpawns_2;

    [Header("Slow Stage 3 Spawner Parameters")]
    [Range(1, 4)]
    public int slowSpawnCap_3;
    public float slowSpawnCoolDown_3;

    [Range(0, 2)]
    public float slowObjectSpeedStraight_3;
    public bool slowAstronautActive_3;
    public bool slowAlienActive_3;
    public bool slowSameSpawns_3;

    [Header("Slow Stage 4 Spawner Parameters")]
    [Range(1, 4)]
    public int slowSpawnCap_4;
    public float slowSpawnCoolDown_4;

    [Range(0, 2)]
    public float slowObjectSpeedStraight_4;
    public bool slowAstronautActive_4;
    public bool slowAlienActive_4;
    public bool slowSameSpawns_4;

    [Header("Slow Stage 5 Spawner Parameters")]
    [Range(1, 4)]
    public int slowSpawnCap_5;
    public float slowSpawnCoolDown_5;

    [Range(0, 2)]
    public float slowObjectSpeedStraight_5;
    public bool slowAstronautActive_5;
    public bool slowAlienActive_5;
    public bool slowSameSpawns_5;

    [Header("Canvas Elements")]
    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    public TMP_Text timerText;
    public TMP_Text levelCountText;
    public TMP_Text TextBoxStart_v1;
    public TMP_Text subjectIDText;

    [Header("GameObjects")]
    public GameObject spawner;

    public GameObject player;

    public GameObject listener;

    public GameObject reflectRoom;

    public GameObject plane;

    public GameObject infoBackGround;

    [Header("Collider")]
    public GameObject astronautCollider;
    public GameObject asteroidCollider;
    public GameObject alienCollider;
    public GameObject laserCollider;

    public GameObject slowAstronautCollider;
    public GameObject slowAlienCollider;

    public GameObject blinkColliderCollection;

    [Header("UI GameObjects")]
    public GameObject tutorialUI;
    public GameObject tutorialObjects;

    public GameObject hideInV2CanvasElements;

    public GameObject hideInV1CanvasElements;

    public GameObject tutorialBackground;

    public GameObject allUIElements;

    public GameObject gameActionMode;
    public GameObject tutorialActionMode;
    public GameObject tutorialSlowMode;
    public GameObject gameSlowMode;
    public GameObject gameOverScreen;
    public GameObject consentScreen;

    public GameObject infoScreenV1;
    public GameObject infoScreenV2;

    public GameObject scoreTimerInfoFolder;

    [Header("Scripts")]
    public Spawner spawnerScript;
    public Player playerScript;

    public ReportWriter reportWriterScript;

    public OscQuaternionTransformerLineEndsFixed quaternionScript;

    public CircularMovement astronautPrefab;
    public CircularMovement alienPrefab;
    public StraightMovement asteroidPrefab;

    public StraightMovement laserPrefab;

    [Header("Sounds")]
    public AK.Wwise.Event levelTransition;
    public AK.Wwise.Event startLevelSound;
    public AK.Wwise.Event endSound;

    public AK.Wwise.Event killSoundLevelEnd;

    public AK.Wwise.Event welcomeSound;

    public AK.Wwise.Event levelCountdown;
    public AK.Wwise.Event tutorialAmbiance;

    [Header("Sprites")]
    public SpriteRenderer spriteRendererPlayer;
    public SpriteRenderer spriteRendererListener;
    public SpriteRenderer spriteRendererAstronaut;
    public SpriteRenderer spriteRendererAlien;
    public SpriteRenderer spriteRendererLaser;
    public SpriteRenderer spriteRendererAsteroid;

    public MeshRenderer spriteRendererPlane;

    private SphereCollider sphereCollider;

    [HideInInspector]
    public float timeSpentInTutorial;

    [HideInInspector]
    public string randomID;

    [HideInInspector]
    public float idNumber;

    [HideInInspector]
    public float lastAngle;

    [HideInInspector]
    public float deltaRotationAngle;

    void Awake()
    {
        gameOverScreen.SetActive(false);
        consentScreen.SetActive(false);
        enableTutorial = false;

        if (compileSettings == true)
        {
            consentScreen.SetActive(true);
        }

        Debug.Log("consentScreen.activeSelf" + consentScreen.activeSelf);

        if (consentScreen.activeSelf == false)
        {
            enableTutorial = true;
        }

        tutorialAmbiance.Post(gameObject);

        disableCollider();

        // Set Positions

        spawner.transform.position = player.transform.position;
        listener.transform.position = player.transform.position;
        reflectRoom.transform.position = player.transform.position;
        this.transform.position = player.transform.position;
        plane.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z - 10
        );

        laserPrefab.spawnerPosition = spawner.transform.position;
        alienPrefab.spawnerPosition = spawner.transform.position;
        astronautPrefab.spawnerPosition = spawner.transform.position;
        asteroidPrefab.spawnerPosition = spawner.transform.position;

        // Set some Variables that are the same throughought all game modes

        spawnerScript.spawnDistanceCircular = spawnDistanceCircular;
        spawnerScript.spawnDistanceStraight = spawnDistanceStraight;

        laserPrefab.spawnDelay = spawnDelay;
        alienPrefab.spawnDelay = spawnDelay;
        astronautPrefab.spawnDelay = spawnDelay;
        asteroidPrefab.spawnDelay = spawnDelay;

        alienPrefab.rotationAngle = rotationAngle;
        astronautPrefab.rotationAngle = rotationAngle;

        laserPrefab.speed = tutorialObjectSpeedStraight;
        alienPrefab.speed = tutorialObjectSpeedCircular;
        astronautPrefab.speed = tutorialObjectSpeedCircular;
        asteroidPrefab.speed = tutorialObjectSpeedStraight;

        Reconfiguration(); // Gets all the settings and distributes them to different scripts and objects depending on the gamemode

        lastAngle = Mathf.Abs(listener.transform.localEulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateObjectCount();

        Debug.Log("enabelTutorial = " + enableTutorial);
        Debug.Log("ingame = " + inGame);

        // UI ELements Update
        scoreText.text = score.ToString();
        endScoreText.text = score.ToString();
        levelCountText.text = levelCount.ToString();
        subjectIDText.text = subjectID;

        Debug.Log("in transition = " + inTransition);

        CalculateHeadRotation();

        if (blackCurtainActive == true && enableTutorial == true && objectCount != 0) // for Tutorial Blind Mode
        {
            Cursor.visible = false;
        }

        if ((blackCurtainActive == true && enableTutorial == true && objectCount == 0))
        {
            Cursor.visible = true;
        }

        if (levelCount > 5) // for endgame screen
        {
            inTransition = true;
        }

        if (inTransition == true)
        {
            KillAllGameobjects();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SkipStage();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && enableTutorial == true)
        {
            StartGame();
        }

        if (timeLeft < 4 && !countdownOn)
        {
            countdownOn = true;
            levelCountdown.Post(gameObject);
        }

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else // Timer abgelaufen und Level zu Ende
            {
                KillAllGameobjects();

                timerOn = false;
                timeLeft = 5; // to stop Countdown from playing over and over -> gets set in Level Transition for new stage
                countdownOn = false;

                disableCollider();

                LevelSelection();
            }
        }
    }

    public void Reconfiguration() // gets called at awake and after "start game" // Sets gamemodespecific settings
    {
        if (enableTutorial == true || inGame == true)
        {
            disableCollider();
            enableCollider(); // Sets correct Collider for the Gamemodes
        }

        KillAllGameobjects();

        player.transform.rotation = Quaternion.identity;
        spawnerScript.spawnDistanceCircular = spawnDistanceCircular; // because its changing sometimes for v2

        if (timerOn == false)
        {
            timerOn = true;
            timeLeft = 3600;
        }

        if (enableTutorial == true) // sets up the tutorial
        {
            spawnerScript.enableTutorial = true;
            tutorialObjects.SetActive(true);
            tutorialBackground.SetActive(true);
            //hideTextForGame.SetActive(true);
            tutorialUI.SetActive(true);
            laserPrefab.speed = tutorialObjectSpeedStraight;
            alienPrefab.speed = tutorialObjectSpeedCircular;
            astronautPrefab.speed = tutorialObjectSpeedCircular;
            asteroidPrefab.speed = tutorialObjectSpeedStraight;

            if (compileSettings == false) // dont want mode to show on compilesettings
            {
                if (enableV2 == false)
                {
                    tutorialActionMode.SetActive(true);
                }
                else
                {
                    tutorialSlowMode.SetActive(true);
                }
            }

            if (enableV2 == true)
            {
                astronautPrefab.speed = slowTutorialObjectSpeedCircular;
                alienPrefab.speed = slowTutorialObjectSpeedCircular;
            }
        }
        else // we are here because we started the game and tutorial is false / Turn off all tutorial features
        {
            spawnerScript.enableTutorial = false;
            tutorialObjects.SetActive(false);
            //hideTextForGame.SetActive(false);
            tutorialUI.SetActive(false);

            if (blackCurtainActive == false)
            {
                scoreTimerInfoFolder.SetActive(true);
            }
            score = startScore;
            scoreText.text = startScore.ToString();
        }

        // all V2 logic here

        if (enableV2 == true) // reduce UI to V2
        {
            playerScript.enablePlayerV2 = true; // stops stun??
            spawnerScript.enableSpawnerV2 = true;
            astronautPrefab.enableSpawnerV2 = true;
            alienPrefab.enableSpawnerV2 = true;
            player.transform.position = new Vector3(0, 0, playerV2Position);
            spawnDistanceCircular = spawnDistanceCircularV2;
            spawnerScript.spawnDistanceCircular = spawnDistanceCircular;
            plane.transform.position = new Vector3(
                player.transform.position.x,
                player.transform.position.y,
                player.transform.position.z - 10
            );
            plane.SetActive(true);
            gameVersion = "Slow Mode";
            hideInV1CanvasElements.SetActive(true);
            hideInV2CanvasElements.SetActive(false);

            GameObject[] uiElements = GameObject.FindGameObjectsWithTag("HideForV2");
            foreach (GameObject uiElement in uiElements)
                uiElement.SetActive(false);

            spawner.transform.position = player.transform.position;
            listener.transform.position = player.transform.position;
            reflectRoom.transform.position = player.transform.position;
            this.transform.position = player.transform.position;

            laserPrefab.spawnerPosition = spawner.transform.position;
            alienPrefab.spawnerPosition = spawner.transform.position;
            astronautPrefab.spawnerPosition = spawner.transform.position;
            asteroidPrefab.spawnerPosition = spawner.transform.position;
        }
        else
        {
            playerScript.enablePlayerV2 = false; // stops stun??
            spawnerScript.enableSpawnerV2 = false;
            astronautPrefab.enableSpawnerV2 = false;
            alienPrefab.enableSpawnerV2 = false;
            plane.SetActive(false);
            gameVersion = "Action Mode";
            hideInV1CanvasElements.SetActive(false);
            hideInV2CanvasElements.SetActive(true);
        }
    }

    public void StartGame()
    {
        if (blackCurtainActive == true)
        {
            allUIElements.SetActive(false);
            Cursor.visible = false;
        }

        if (compileSettings == false && enableV2 == true)
        {
            gameSlowMode.SetActive(true);
        }

        if (compileSettings == false && enableV2 == false)
        {
            gameActionMode.SetActive(true);
        }

        tutorialAmbiance.Stop(gameObject);

        enableTutorial = false;
        timerOn = false;
        inGame = true;

        // Tutorial Stats

        timeSpentInTutorial = 3600 - timeLeft;

        Reconfiguration();

        disableCollider();

        LevelSelection();
    }

    private void LevelSelection()
    {
        if (levelCount == 0) // we were in tutorial and now beginn level 1
        {
            Invoke(nameof(LevelTransition_1), startTransition);
            inTransition = true;
            CalculateAllSuccessRatiosThisStage();
            StatsCalculator();
            reportWriterScript.AppendToReportEmtpy();
            reportWriterScript.AppendToReportEmtpy();
            reportWriterScript.AppendToReportTutorialAndID();
            reportWriterScript.AppendToReportEmtpy();
            ResetStats();
            startLevelSound.Post(gameObject);
        }
        else if (levelCount == 1)
        {
            CalculateAllSuccessRatiosThisStage();

            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            // reports stats of level 1
            Invoke(nameof(LevelTransition_2), transitionTime);
            inTransition = true;
            tutorialAmbiance.Stop(gameObject);
            levelTransition.Post(gameObject);
        }
        else if (levelCount == 2)
        {
            CalculateAllSuccessRatiosThisStage();

            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();

            Invoke(nameof(LevelTransition_3), transitionTime);
            inTransition = true;
            tutorialAmbiance.Stop(gameObject);
            levelTransition.Post(gameObject);
        }
        else if (levelCount == 3)
        {
            CalculateAllSuccessRatiosThisStage();

            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            Invoke(nameof(LevelTransition_4), transitionTime);
            inTransition = true;
            tutorialAmbiance.Stop(gameObject);
            levelTransition.Post(gameObject);
        }
        else if (levelCount == 4)
        {
            CalculateAllSuccessRatiosThisStage();

            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();

            Invoke(nameof(LevelTransition_5), transitionTime);
            inTransition = true;
            tutorialAmbiance.Stop(gameObject);
            levelTransition.Post(gameObject);
        }
        else if (levelCount == 5)
        {
            CalculateAllSuccessRatiosThisStage();

            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            inTransition = true;
            reportWriterScript.AppendToReportEmtpy();
            tutorialAmbiance.Stop(gameObject);
            EndGame();
        }
    }

    public void LevelTransition_1()
    {
        Debug.Log("Iam in level 1");

        tutorialAmbiance.Post(gameObject);
        levelCount++;
        enableCollider();

        if (enableV2 == false)
        {
            spawnCap = spawnCap_1;
            spawnCoolDown = spawnCoolDown_1;
            spawnerScript.invertRotationOn = invertRotationOn_1;

            spawnerScript.asteroidActive = asteroidActive_1;
            spawnerScript.astronautActive = astronautActive_1;
            spawnerScript.laserActive = laserActive_1;
            spawnerScript.alienActive = alienActive_1;

            spawnerScript.sameSpawns = sameSpawns_1;

            laserPrefab.speed = objectSpeedStraight_1;
            alienPrefab.speed = objectSpeedCircle_1;
            astronautPrefab.speed = objectSpeedCircle_1;
            asteroidPrefab.speed = objectSpeedStraight_1;
        }
        else
        {
            spawnCap = slowSpawnCap_1;
            spawnCoolDown = slowSpawnCoolDown_1;

            spawnerScript.astronautActive = slowAstronautActive_1;
            spawnerScript.alienActive = slowAlienActive_1;

            spawnerScript.sameSpawns = sameSpawns_1;

            alienPrefab.speed = slowObjectSpeedStraight_1;
            astronautPrefab.speed = slowObjectSpeedStraight_1;
        }

        inTransition = false;

        timerOn = true;
        timeLeft = levelDuration;

        spawnerScript.Invoke("CallRandomSpawner", 2);

        Invoke("startCoroutineForIterator", 2);
    }

    private void LevelTransition_2()
    {
        Debug.Log("Iam in level 2");
        tutorialAmbiance.Post(gameObject);

        levelCount++;
        enableCollider();

        if (enableV2 == false)
        {
            spawnCap = spawnCap_2;
            spawnCoolDown = spawnCoolDown_2;
            spawnerScript.invertRotationOn = invertRotationOn_2;

            spawnerScript.asteroidActive = asteroidActive_2;
            spawnerScript.astronautActive = astronautActive_2;
            spawnerScript.laserActive = laserActive_2;
            spawnerScript.alienActive = alienActive_2;

            spawnerScript.sameSpawns = sameSpawns_2;

            laserPrefab.speed = objectSpeedStraight_2;
            alienPrefab.speed = objectSpeedCircle_2;
            astronautPrefab.speed = objectSpeedCircle_2;
            asteroidPrefab.speed = objectSpeedStraight_2;
        }
        else
        {
            spawnCap = slowSpawnCap_2;
            spawnCoolDown = slowSpawnCoolDown_2;

            spawnerScript.astronautActive = slowAstronautActive_2;
            spawnerScript.alienActive = slowAlienActive_2;

            spawnerScript.sameSpawns = sameSpawns_2;

            alienPrefab.speed = slowObjectSpeedStraight_2;
            astronautPrefab.speed = slowObjectSpeedStraight_2;
        }

        inTransition = false;
        timerOn = true;
        timeLeft = levelDuration;

        spawnerScript.Invoke("CallRandomSpawner", 2); // Inital Spawn with 2 seconds delay.
        Invoke("startCoroutineForIterator", 2); // Initiate spawn loop
    }

    private void LevelTransition_3()
    {
        Debug.Log("Iam in level 3");
        tutorialAmbiance.Post(gameObject);

        levelCount++;
        enableCollider();

        if (enableV2 == false)
        {
            spawnCap = spawnCap_3;
            spawnCoolDown = spawnCoolDown_3;
            spawnerScript.invertRotationOn = invertRotationOn_3;

            spawnerScript.asteroidActive = asteroidActive_3;
            spawnerScript.astronautActive = astronautActive_3;
            spawnerScript.laserActive = laserActive_3;
            spawnerScript.alienActive = alienActive_3;

            spawnerScript.sameSpawns = sameSpawns_3;

            laserPrefab.speed = objectSpeedStraight_3;
            alienPrefab.speed = objectSpeedCircle_3;
            astronautPrefab.speed = objectSpeedCircle_3;
            asteroidPrefab.speed = objectSpeedStraight_3;
        }
        else
        {
            spawnCap = slowSpawnCap_3;
            spawnCoolDown = slowSpawnCoolDown_3;

            spawnerScript.astronautActive = slowAstronautActive_3;
            spawnerScript.alienActive = slowAlienActive_3;

            spawnerScript.sameSpawns = sameSpawns_3;

            alienPrefab.speed = slowObjectSpeedStraight_3;
            astronautPrefab.speed = slowObjectSpeedStraight_3;
        }

        inTransition = false;

        timerOn = true;
        timeLeft = levelDuration;

        spawnerScript.Invoke("CallRandomSpawner", 2);
        Invoke("startCoroutineForIterator", 2);
    }

    private void LevelTransition_4()
    {
        Debug.Log("Iam in level 4");
        tutorialAmbiance.Post(gameObject);

        levelCount++;
        enableCollider();

        if (enableV2 == false)
        {
            spawnCap = spawnCap_4;
            spawnCoolDown = spawnCoolDown_4;
            spawnerScript.invertRotationOn = invertRotationOn_4;

            spawnerScript.asteroidActive = asteroidActive_4;
            spawnerScript.astronautActive = astronautActive_4;
            spawnerScript.laserActive = laserActive_4;
            spawnerScript.alienActive = alienActive_4;

            spawnerScript.sameSpawns = sameSpawns_4;

            laserPrefab.speed = objectSpeedStraight_4;
            alienPrefab.speed = objectSpeedCircle_4;
            astronautPrefab.speed = objectSpeedCircle_4;
            asteroidPrefab.speed = objectSpeedStraight_4;
        }
        else
        {
            spawnCap = slowSpawnCap_4;
            spawnCoolDown = slowSpawnCoolDown_4;

            spawnerScript.astronautActive = slowAstronautActive_4;
            spawnerScript.alienActive = slowAlienActive_4;

            spawnerScript.sameSpawns = sameSpawns_4;

            alienPrefab.speed = slowObjectSpeedStraight_4;
            astronautPrefab.speed = slowObjectSpeedStraight_4;
        }

        inTransition = false;

        timerOn = true;
        timeLeft = levelDuration;

        spawnerScript.Invoke("CallRandomSpawner", 2);
        Invoke("startCoroutineForIterator", 2);
    }

    private void LevelTransition_5()
    {
        Debug.Log("Iam in level 5");
        tutorialAmbiance.Post(gameObject);

        levelCount++;
        enableCollider();

        if (enableV2 == false)
        {
            spawnCap = spawnCap_5;
            spawnCoolDown = spawnCoolDown_5;
            spawnerScript.invertRotationOn = invertRotationOn_5;

            spawnerScript.asteroidActive = asteroidActive_5;
            spawnerScript.astronautActive = astronautActive_5;
            spawnerScript.laserActive = laserActive_5;
            spawnerScript.alienActive = alienActive_5;

            spawnerScript.sameSpawns = sameSpawns_5;

            laserPrefab.speed = objectSpeedStraight_5;
            alienPrefab.speed = objectSpeedCircle_5;
            astronautPrefab.speed = objectSpeedCircle_5;
            asteroidPrefab.speed = objectSpeedStraight_5;
        }
        else
        {
            spawnCap = slowSpawnCap_5;
            spawnCoolDown = slowSpawnCoolDown_5;

            spawnerScript.astronautActive = slowAstronautActive_5;
            spawnerScript.alienActive = slowAlienActive_5;

            spawnerScript.sameSpawns = sameSpawns_5;

            alienPrefab.speed = slowObjectSpeedStraight_5;
            astronautPrefab.speed = slowObjectSpeedStraight_5;
        }

        inTransition = false;

        timerOn = true;
        timeLeft = levelDuration;

        spawnerScript.Invoke("CallRandomSpawner", 2);
        Invoke("startCoroutineForIterator", 2);
    }

    private void EndGame()
    {
        levelCount++;
        inTransition = true;
        Cursor.visible = true;
        disableCollider();
        endSound.Post(gameObject);
        DeactivateBlackCurtain();
        gameOverScreen.SetActive(true);
        UpdateStats();
        CalculateAllSuccessRatios();
        reportWriterScript.AppendToReportWithSum();
    }

    public void SkipStage() // never goes into Startgame to skip transition
    {
        disableCollider();

        timerOn = false;

        if (levelCount == 0) // always press the button please
        {
            timeSpentInTutorial = 3600 - timeLeft;

            inGame = true;
            enableTutorial = false;
            Reconfiguration();
            timerOn = false;
            tutorialAmbiance.Stop(gameObject);

            StatsCalculator();
            CalculateAllSuccessRatiosThisStage();
            reportWriterScript.AppendToReportEmtpy();
            reportWriterScript.AppendToReportEmtpy();
            reportWriterScript.AppendToReportTutorialAndID();
            reportWriterScript.AppendToReportEmtpy();
            ResetStats();
            LevelTransition_1();

            if (blackCurtainActive == true)
            {
                ActivateBlackCurtain();
                allUIElements.SetActive(false);
            }
        }
        else if (levelCount == 1)
        {
            KillAllGameobjects();

            CalculateAllSuccessRatiosThisStage();
            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            LevelTransition_2();
        }
        else if (levelCount == 2)
        {
            KillAllGameobjects();

            CalculateAllSuccessRatiosThisStage();
            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            LevelTransition_3();
        }
        else if (levelCount == 3)
        {
            KillAllGameobjects();

            CalculateAllSuccessRatiosThisStage();
            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            LevelTransition_4();
        }
        else if (levelCount == 4)
        {
            KillAllGameobjects();

            CalculateAllSuccessRatiosThisStage();
            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            LevelTransition_5();
        }
        else if (levelCount == 5)
        {
            KillAllGameobjects();

            CalculateAllSuccessRatiosThisStage();
            UpdateStats();
            reportWriterScript.AppendToReport();
            ResetStats();
            reportWriterScript.AppendToReportEmtpy();

            EndGame();
        }
        else
        {
            return;
        }
    }

    public void KillAllGameobjects()
    {
        GameObject[] astronauts = GameObject.FindGameObjectsWithTag("Astronaut");
        foreach (GameObject astronaut in astronauts)
            GameObject.Destroy(astronaut);

        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
            GameObject.Destroy(asteroid);

        GameObject[] alienes = GameObject.FindGameObjectsWithTag("Alien");
        foreach (GameObject alien in alienes)
            GameObject.Destroy(alien);

        GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
        foreach (GameObject laser in lasers)
            GameObject.Destroy(laser);

        asteroidCount = 0;
        laserCount = 0;
        astronautCount = 0;
        alienCount = 0;
    }

    private void UpdateStats() // call this
    {
        buttonsPressed += buttonsPressedThisStage; // this adds to the combined score after every level
        actionsExecuted += actionsExecutedThisStage;
        hitsTaken += hitsTakenThisStage;
        sucessfullHits += sucessfullHitsThisStage;
        deltaRotationAngle += deltaRotationAngleThisStage;
        scoreLostThisStage = (scoreLastStage - score) * -1;

        asteroidsSpawned += asteroidsSpawnedThisStage;
        lasersSpawned += lasersSpawnedThisStage;
        astronautsSpawned += astronautsSpawnedThisStage;
        aliensSpawned += aliensSpawnedThisStage;

        asteroidsDestroyed += asteroidsDestroyedThisStage;
        lasersDestroyed += lasersDestroyedThisStage;
        astronautsDestroyed += astronautsDestroyedThisStage;
        aliensDestroyed += aliensDestroyedThisStage;

        asteroidsStruck += asteroidsStruckThisStage;
        lasersStruck += lasersStruckThisStage;
        astronautsStruck += astronautsStruckThisStage;
        aliensStruck += aliensStruckThisStage;

        centeringsUsed += centeringsUsedThisStage;

        StatsCalculator();
    }

    private void ResetStats()
    {
        deltaRotationAngleThisStage = 0; // this resets score for every level so we get a score per level
        buttonsPressedThisStage = 0;
        actionsExecutedThisStage = 0;
        sucessfullHitsThisStage = 0;
        hitsTakenThisStage = 0;
        scoreLastStage = score;
        asteroidsSpawnedThisStage = 0;
        lasersSpawnedThisStage = 0;
        astronautsSpawnedThisStage = 0;
        aliensSpawnedThisStage = 0;
        asteroidSucessRateThisStage = 0;
        laserSucessRateThisStage = 0;
        astronautSucessRateThisStage = 0;
        alienSucessRateThisStage = 0;
        asteroidsDestroyedThisStage = 0;
        lasersDestroyedThisStage = 0;
        astronautsDestroyedThisStage = 0;
        aliensDestroyedThisStage = 0;
        asteroidsStruckThisStage = 0;
        lasersStruckThisStage = 0;
        astronautsStruckThisStage = 0;
        aliensStruckThisStage = 0;
        centeringsUsedThisStage = 0;
    }

    public void CheckID()
    {
        randomID = GUIUtility.systemCopyBuffer;

        if ((randomID.All(char.IsDigit) && randomID.Length == 7 && compileSettings == true))
        {
            char checkOne = '1';
            char checkTwo = '2';

            subjectID = randomID; // ID exists and we use the old one

            if (!string.IsNullOrEmpty(randomID) && randomID[0] == checkOne) // check what gamemode something has been played before and then go straight to tutorial
            {
                enableV2 = true;
                enableTutorial = true;
                Debug.Log("I have played Game Mode 1 and enableV2 is now " + enableV2);
                consentScreen.SetActive(false);
                infoScreenV2.SetActive(true);

                Reconfiguration();
                welcomeSound.Post(gameObject);
            }

            if (!string.IsNullOrEmpty(randomID) && randomID[0] == checkTwo)
            {
                enableTutorial = true;
                Debug.Log("I have played Game Mode 2 and enableV2 is now " + enableV2);
                consentScreen.SetActive(false);
                infoScreenV1.SetActive(true);

                Reconfiguration();
                welcomeSound.Post(gameObject);
            }
        }
    }

    public void GenerateRandomID()
    {
        randomID = GUIUtility.systemCopyBuffer;

        if ((randomID.All(char.IsDigit) && randomID.Length == 7))
        {
            subjectID = GUIUtility.systemCopyBuffer;
            Debug.Log("There was an old ID in clipboard, the ID is:");
            Debug.Log(subjectID);
        }
        else // wenn außerhalb der Range, also keine ID dann erstelle neue
        {
            randomID = Random.Range(100000, 999999).ToString(); // make a new ID and preceed with corresponding signifier

            if (groupOne == true)
            {
                float signifier = 1;
                subjectID = signifier.ToString() + randomID;
            }
            else if (groupTwo == true)
            {
                float signifier = 2;
                subjectID = signifier.ToString() + randomID;
            }

            subjectIDText.text = subjectID;
            Debug.Log("there was no ID in Clipboard the new ID is:");
            Debug.Log(subjectID);
        }
    }

    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void disableCollider()
    {
        stunned = true;
        blinkColliderCollection.SetActive(false);
        astronautCollider.SetActive(false);
        asteroidCollider.SetActive(false);
        alienCollider.SetActive(false);
        laserCollider.SetActive(false);
        slowAlienCollider.SetActive(false);
        slowAstronautCollider.SetActive(false);
    }

    public void enableCollider()
    {
        stunned = false;

        if (enableV2 == true)
        {
            slowAlienCollider.SetActive(true);
            slowAstronautCollider.SetActive(true);
        }
        else
        {
            astronautCollider.SetActive(true);
            asteroidCollider.SetActive(true);
            alienCollider.SetActive(true);
            laserCollider.SetActive(true);
        }

        blinkColliderCollection.SetActive(true);
    }

    static float UpdateObjectCount()
    {
        objectCount = alienCount + astronautCount + asteroidCount + laserCount;
        return objectCount;
    }

    private IEnumerator spawnIterator()
    {
        for (int i = 0; i < spawnCap - 1; i++)
        {
            yield return new WaitForSeconds(spawnCoolDown);
            spawnerScript.CallRandomSpawner();
        }
    }

    private void startCoroutineForIterator()
    {
        StartCoroutine(spawnIterator());
    }

    private void CalculateHeadRotation() // only for headtracking
    {
        float rotationAngle = Mathf.Abs(listener.transform.localEulerAngles.y); // change to quaternionScript.transform.rotation.z; for quaternion values (-1/1)

        if (rotationAngle >= lastAngle - 5 && rotationAngle <= lastAngle + 5)
        {
            float angleZ = rotationAngle - Mathf.Abs(lastAngle);
            deltaRotationAngleThisStage =
                Mathf.Abs(deltaRotationAngleThisStage) + Mathf.Abs(angleZ);
        }

        lastAngle = Mathf.Abs(rotationAngle);

        Debug.Log("deltaRotationAngleThisStage is " + deltaRotationAngleThisStage);

        Debug.Log("deltaRotationAngle is " + deltaRotationAngle);
    }

    public float CalculateSucessRatioThisStageAstronaut(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            astronautSucessRateThisStage = (float)destroyed / (float)nullcheck;
        }

        return astronautSucessRateThisStage;
    }

    public float CalculateSucessRatioThisStageAlien(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            alienSucessRateThisStage = (float)destroyed / (float)nullcheck;
        }

        return alienSucessRateThisStage;
    }

    public float CalculateSucessRatioThisStageLaser(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            laserSucessRateThisStage = (float)destroyed / (float)nullcheck;
        }

        return laserSucessRateThisStage;
    }

    public float CalculateSucessRatioThisStageAsteroid(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            asteroidSucessRateThisStage = (float)destroyed / (float)nullcheck;
        }

        return asteroidSucessRateThisStage;
    }

    public void CalculateAllSuccessRatiosThisStage()
    {
        CalculateSucessRatioThisStageAlien(
            aliensSpawnedThisStage,
            aliensDestroyedThisStage,
            aliensStruckThisStage
        );
        CalculateSucessRatioThisStageAstronaut(
            astronautsSpawnedThisStage,
            astronautsDestroyedThisStage,
            astronautsStruckThisStage
        );
        CalculateSucessRatioThisStageAsteroid(
            asteroidsSpawnedThisStage,
            asteroidsDestroyedThisStage,
            asteroidsStruckThisStage
        );
        CalculateSucessRatioThisStageLaser(
            lasersSpawnedThisStage,
            lasersDestroyedThisStage,
            lasersStruckThisStage
        );
    }

    public float CalculateSucessRatioAstronaut(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            astronautSucessRate = (float)destroyed / (float)nullcheck;
        }

        return astronautSucessRate;
    }

    public float CalculateSucessRatioAlien(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            alienSucessRate = (float)destroyed / (float)nullcheck;
        }

        return alienSucessRate;
    }

    public float CalculateSucessRatioLaser(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            laserSucessRate = (float)destroyed / (float)nullcheck;
        }

        return laserSucessRate;
    }

    public float CalculateSucessRatioAsteroid(int spawned, int destroyed, int struck)
    {
        float nullcheck = spawned - (spawned - (destroyed + struck));

        if (nullcheck != 0)
        {
            asteroidSucessRate = (float)destroyed / (float)nullcheck;
        }

        return asteroidSucessRate;
    }

    public void CalculateAllSuccessRatios()
    {
        CalculateSucessRatioAlien(aliensSpawned, aliensDestroyed, aliensStruck);
        CalculateSucessRatioAstronaut(astronautsSpawned, astronautsDestroyed, astronautsStruck);
        CalculateSucessRatioAsteroid(asteroidsSpawned, asteroidsDestroyed, asteroidsStruck);
        CalculateSucessRatioLaser(lasersSpawned, lasersDestroyed, lasersStruck);
    }

    public void ActivateBlackCurtain()
    {
        blackCurtainActive = true;
        Cursor.visible = false;
        spriteRendererPlayer.enabled = false;
        spriteRendererListener.enabled = false;
        spriteRendererAstronaut.enabled = false;
        spriteRendererAlien.enabled = false;
        spriteRendererLaser.enabled = false;
        spriteRendererAsteroid.enabled = false;
        spriteRendererPlane.enabled = false;
        GameObject[] uiElements = GameObject.FindGameObjectsWithTag("DisableInBlindMode");
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.GetComponent<TextMeshProUGUI>().enabled = false;
        }

        KillAllGameobjects();
        infoBackGround.SetActive(false);
        inTransition = true;
        StartCoroutine(InTransitionToFalseDelay());
    }

    public void DeactivateBlackCurtain()
    {
        blackCurtainActive = false;

        if (spriteRendererPlayer != null)
        {
            spriteRendererPlayer.enabled = true;
        }
        if (spriteRendererListener != null)
        {
            spriteRendererListener.enabled = true;
        }

        if (spriteRendererPlane != null)
        {
            spriteRendererPlane.enabled = true;
        }

        if (infoBackGround != null)
        {
            infoBackGround.SetActive(true);
        }

        if (player != null)
        {
            player.SetActive(true);
        }

        Cursor.visible = true;
        spriteRendererAstronaut.enabled = true;
        spriteRendererAlien.enabled = true;
        spriteRendererLaser.enabled = true;
        spriteRendererAsteroid.enabled = true;

        GameObject[] uiElements = GameObject.FindGameObjectsWithTag("DisableInBlindMode");
        foreach (GameObject uiElement in uiElements)
        {
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
            uiElement.GetComponent<TextMeshProUGUI>().enabled = true;
        }

        KillAllGameobjects();

        inTransition = true;
        StartCoroutine(InTransitionToFalseDelay());
    }

    private IEnumerator InTransitionToFalseDelay()
    {
        yield return new WaitForSeconds(1.5f);

        InTransitionToFalse();
    }

    private void InTransitionToFalse()
    {
        inTransition = false;
    }

    private void StatsCalculator()
    {
        if (buttonsPressedThisStage > 0)
        {
            spamIndexThisStage = actionsExecutedThisStage / buttonsPressedThisStage;
            Debug.Log("im in here for spam index");
            Debug.Log("spamIndexThisStage is " + spamIndexThisStage);
        }
        if (actionsExecutedThisStage > 0)
        {
            precisionScoreThisStage =
                (float)sucessfullHitsThisStage / (float)actionsExecutedThisStage;
        }

        if (actionsExecuted > 0)
        {
            precisionScore = (float)sucessfullHits / (float)actionsExecuted;
        }
        if (buttonsPressed > 0)
        {
            spamIndex = (float)actionsExecuted / (float)buttonsPressed;
        }
    }
}
