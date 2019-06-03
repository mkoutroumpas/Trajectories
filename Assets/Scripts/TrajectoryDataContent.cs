using System;
using UnityEngine;
using UnityEngine.UI;

public class TrajectoryDataContent : MonoBehaviour
{
    private int _lineCount;

    private void Update()
    {

    }

    public void OnLaunchEvent(string data)
    {
        if (!string.IsNullOrEmpty(data))
        {
            Text text = GetComponent<Text>();

            if (text == null)
                return;

            if (_lineCount == 0)
            {
                text.text = string.Empty;
            }

            text.text += data + Environment.NewLine;

            _lineCount++;
        }
    }
}
