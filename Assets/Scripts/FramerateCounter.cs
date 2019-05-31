using UnityEngine;
using UnityEngine.UI;

public class FramerateCounter : MonoBehaviour
{
    public Text text;
    private float fps, deltaTime;

    void Start()
    {
        deltaTime = 0.0f;
    }

    void Update()
    {
        fps = Mathf.FloorToInt(1.0f / deltaTime);
        text.text = fps.ToString();

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }
}
