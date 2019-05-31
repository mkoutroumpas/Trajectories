using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {

    private int _launchDelay = 5;

	void Start () {
        // Simple launch

        GameObject sphere = GameObject.Find("Sphere");

        LaunchableObject launchableObject = sphere.GetComponent<LaunchableObject>();

        StartCoroutine(Launch(launchableObject));

        //TODO: possibly add more, complex launches here

        //TODO: reset scene upon finishing up
    }
	
	void Update () {
		
	}

    private IEnumerator Launch(LaunchableObject launchableObject)
    {
        yield return new WaitForSeconds(_launchDelay);

        launchableObject.OnLaunch();

        yield return new WaitForSeconds(_launchDelay);
    }
}
