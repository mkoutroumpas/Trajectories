using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    private int _initialLaunchDelay = 3;
    private int _restartSceneDelay = 15;
    private int _nextLaunchDelay = 3;

    void Start () {
        GameObject sphere = GameObject.Find("Sphere");

        LaunchableObject launchableObject = sphere.GetComponent<LaunchableObject>();

        ////StartCoroutine(SingleLaunch(launchableObject));

        StartCoroutine(MultipleLaunch(launchableObject, new List<Vector3>()
        {
            new Vector3(-30, 50, 30),
            new Vector3(40, 30, -30)
        }));

        ////StartCoroutine(SingleLaunch(launchableObject, new Vector3(-10, 50, -30)));

        //TODO: possibly add more, complex launches here

        //TODO: reset scene upon finishing up
    }
	
	void Update () {
		
	}

    private IEnumerator SingleLaunch(LaunchableObject launchableObject, Vector3 force = default(Vector3))
    {
        yield return new WaitForSeconds(_initialLaunchDelay);

        launchableObject.OnLaunch(force);

        yield return new WaitForSeconds(_nextLaunchDelay);

        ////SceneManager.LoadScene(0);
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
