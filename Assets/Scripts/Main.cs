using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour {

    private int _launchDelay = 5;

	void Start () {
        // Simple launch
        LaunchableObject launchableObject = gameObject.GetComponentInChildren<LaunchableObject>();

        StartCoroutine(Launch(launchableObject));

        //TODO: possible add more complex launches

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
