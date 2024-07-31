using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    [HideInInspector]
    public float nextActionTime;

    public float actionOffset = 10f;

    VariableManager variableManager;
    public GameObject GameObjectVariableManager;

    public GameObject player;

    public Spawner spawnerScript;
    public GameObject laserBlink;

    public GameObject laserActionPrefab;

    public GameObject collectedAllPrefab;

    public GameObject audioOffSet;

    void Start()
    {
        variableManager = GameObjectVariableManager.GetComponent<VariableManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            VariableManager.buttonsPressedThisStage++;
        }

        if (
            Input.GetKeyDown(KeyCode.E) & Time.time > nextActionTime
            && variableManager.inTransition == false
        )
        {
            var spawnVector3 = new Vector3(
                audioOffSet.transform.position.x,
                audioOffSet.transform.position.y,
                audioOffSet.transform.position.z
            );
            this.gameObject.layer = LayerMask.NameToLayer("Spacecraft");
            nextActionTime = Time.time + variableManager.actionCooldownTime;
            Invoke(nameof(LayerChange), 0.1f);
            Instantiate(laserActionPrefab, spawnVector3, Quaternion.identity);
            variableManager.score -= variableManager.laserAsteroidEnergyCost;
            VariableManager.actionsExecutedThisStage++;

            if (variableManager.blackCurtainActive == false)
            {
                StartCoroutine(BlinkDelay());
            }
        }
    }

    private IEnumerator BlinkDelay()
    {
        if (variableManager.stunned == false && variableManager.inTransition == false)
        {
            laserBlink.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(BlinkDelay1());
        }
    }

    private IEnumerator BlinkDelay1()
    {
        laserBlink.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(BlinkDelay2());
    }

    private IEnumerator BlinkDelay2()
    {
        if (variableManager.stunned == false && variableManager.inTransition == false)
        {
            laserBlink.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            BlinkDelay3();
        }
    }

    private void BlinkDelay3()
    {
        laserBlink.SetActive(false);
    }

    private void LayerChange()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Idle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            var collisionPoint = other.ClosestPoint(transform.position);
            Vector3 prefabSpawnPosition = new Vector3(
                collisionPoint.x,
                collisionPoint.y,
                collisionPoint.z
            );
            Instantiate(collectedAllPrefab, prefabSpawnPosition, Quaternion.identity);
            variableManager.score += variableManager.laserCollectionGain;
            VariableManager.sucessfullHitsThisStage++;
            VariableManager.laserCount--;
            VariableManager.lasersDestroyedThisStage++;

            if (variableManager.enableTutorial == false && VariableManager.timeLeft > 10)
            {
                spawnerScript.Invoke("CallRandomSpawner", variableManager.spawnCoolDown);
            }
        }
    }
}
