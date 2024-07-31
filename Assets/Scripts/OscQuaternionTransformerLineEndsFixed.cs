using System.Collections;
using System.Collections.Generic;
using OscSimpl;
using UnityEngine;

public class OscQuaternionTransformerLineEndsFixed : MonoBehaviour
// Only used in case of Headtracking via OSC
{
    // Quaternion values
    private float qw;
    private float qx;
    private float qy;
    public float qz;

    public Quaternion headTrackerRotation; // The current Quaternion value of the head tracker

    //Quaternion baselineRotation; // The baseline Quaternion value
    //public float lerpSpeed = 20.0f; // The speed of the interpolation



    void Start()
    {
        headTrackerRotation = Quaternion.identity;
    }

    private void UpdateHeadRotation() // rotates the Object
    {
        this.transform.rotation = headTrackerRotation;

        this.transform.Rotate(Vector3.left * -90); 
    }

    public void SetRotationValue(OscMessage message)
    {
        // Extract quaterion out of OSC message
        message.TryGet(0, out qw);
        message.TryGet(1, out qx);
        message.TryGet(2, out qy);
        message.TryGet(3, out qz);
        headTrackerRotation = new(0, -qz, 0, qw);
        UpdateHeadRotation();
    }
}
