/* 
 * DOPPLER EFFECT C# SCRIPT FOR UNITY & WWISE
 * 
 * Add this to a game object and then pass through dopplerPitch to an RTPC in Wwise, then season to taste :)
 * Make sure to center your RTPC around 1.0 - dopplerPitch is a multiplier!
 * I'd recommend starting out with a range of 0.0 to 2.0, with 0.0 = -300 cents and 2.0 = +300 cents
 * Also, note that you may need to search for a different listener object - this is set up to find a First Person Controller...
 * 
 * Script created with TLC by Kenneth C M Young - www.AudBod.com - @kcmyoung
 */
using UnityEngine;
using System.Collections;
public class Doppler : MonoBehaviour
{

    public float SpeedOfSound = 343.3f;
    public float DopplerFactor = 1.0f;
    Vector3 emitterLastPosition = Vector3.zero;
    Vector3 listenerLastPosition = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the player object handy for the rest of the script!
        var player = GameObject.Find("Player");
        // get velocity of source/emitter manually
        Vector3 emitterSpeed = (emitterLastPosition - transform.position) / Time.fixedDeltaTime;
        emitterLastPosition = transform.position;

        // get velocity of listener/player manually
        Vector3 listenerSpeed = (listenerLastPosition - player.transform.position) / Time.fixedDeltaTime;
        listenerLastPosition = player.transform.position;

        // do doppler calc - see http://i.imgur.com/h5BMRmr.png or http://redmine.spatdif.org/projects/spatdif/wiki/Doppler_Extension (OpenAL's implementation of doppler)
        var distance = (player.transform.position - transform.position); // source to listener vector
        var listenerRelativeSpeed = Vector3.Dot(distance, listenerSpeed) / distance.magnitude;
        var emitterRelativeSpeed = Vector3.Dot(distance, emitterSpeed) / distance.magnitude;
        listenerRelativeSpeed = Mathf.Min(listenerRelativeSpeed, (SpeedOfSound / DopplerFactor));
        emitterRelativeSpeed = Mathf.Min(emitterRelativeSpeed, (SpeedOfSound / DopplerFactor));
        var dopplerPitch = (SpeedOfSound + (listenerRelativeSpeed * DopplerFactor)) / (SpeedOfSound + (emitterRelativeSpeed * DopplerFactor));
        // pass the dopplerPitch through to an RTPC in Wwise (or do whatever you want with the value!)
        AkSoundEngine.SetRTPCValue("DopplerParam", dopplerPitch); // "DopplerParam" is the name of the RTPC in the Wwise project :)
                                                                  // uncomment the line below to see the numbers that are being passed through so you can adjust your RTPC values if necessary.
                                                                  Debug.Log (dopplerPitch);

    }

}