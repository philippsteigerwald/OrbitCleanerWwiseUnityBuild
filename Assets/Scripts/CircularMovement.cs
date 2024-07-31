using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody _rigidbody;

    [HideInInspector]
    public float spawnDelay;

    [HideInInspector]
    public float rotationAngle;

    [HideInInspector]
    public Vector3 spawnerPosition;

    [HideInInspector]
    public bool enableSpawnerV2 = false;

    [HideInInspector]
    public bool enableTutorialSpawnerV2;

    Vector3 finalDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (enableSpawnerV2 == true)
        {
            rotationAngle = 90;
        }

        if (this.transform.position.x < 0)
        {
            ChangeRotation();
        }
    }

    private void Start()
    {
        transform.Rotate(Vector3.left * -90);

        this.gameObject.SetActive(false);

        Invoke(nameof(ActivateAfterDelay), spawnDelay);

        var moveDirection = spawnerPosition - this.transform.position; // this is for straightMovement

        finalDirection = moveDirection;
    }

    void Update()
    {
        Vector3 distanceToShip = this.transform.position;

        AkSoundEngine.SetRTPCValue("circularSpeed", speed);
        AkSoundEngine.SetRTPCValue("distanceToShip", distanceToShip.magnitude);

        if (enableSpawnerV2 == true) // increase volume in V2
        {
            int volume = 2;

            AkSoundEngine.SetRTPCValue("V2Volume", volume);
        }

        Vector3 direction = spawnerPosition - transform.position;
        direction = Quaternion.Euler(0, rotationAngle, 0) * direction;
        float distanceThisFrame = speed * 10 * Time.deltaTime;
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    public void ChangeRotation()
    {
        rotationAngle *= -1;
    }

    private void ActivateAfterDelay() // This is to make use of the cue sound so the astronaut only starts moving after the cue has played and so moves from the correct position.
    {
        this.gameObject.SetActive(true);
    }
}
