using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    private int _initialLaunchDelay = 5;
    private int _restartSceneDelay = 15;
    private int _nextLaunchDelay = 3;

    void Start () {
        QualitySettings.vSyncCount = 0;

        GameObject sphere = GameObject.Find("Sphere");

        LaunchableObject launchableObject = sphere.GetComponent<LaunchableObject>();

        StartCoroutine(MultipleLaunch(launchableObject, new List<Vector3>()
        {
            new Vector3(-30, 50, 30),
            new Vector3(40, 30, -30),
            new Vector3(10, 10, 10),
            new Vector3(-5, 30, -5),
            new Vector3(10, 20, 20),
            new Vector3(-20, 20, 20),
            ////new Vector3(-10, 20, 10) // Add a third or fourth launch, etc.
        }));
    }

    void Update () {
		
	}

    private IEnumerator SingleLaunch(LaunchableObject launchableObject, Vector3 force = default(Vector3))
    {
        yield return new WaitForSeconds(_initialLaunchDelay);

        launchableObject.OnLaunch(force);

        yield return new WaitForSeconds(_nextLaunchDelay);
    }

    private IEnumerator MultipleLaunch(LaunchableObject launchableObject, List<Vector3> forces = null)
    {
        yield return new WaitForSeconds(_initialLaunchDelay);

        foreach (var force in forces)
        {
            if (force != null)
            {
                launchableObject.OnLaunch(force);

                yield return new WaitForSeconds(_nextLaunchDelay);
            }
        }
    }
}
