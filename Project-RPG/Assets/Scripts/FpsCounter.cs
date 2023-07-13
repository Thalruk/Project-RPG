using UnityEngine;
using System.Collections;

public class FpsCounter : MonoBehaviour
{
    private float count;

    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 25, 100, 25), "FPS: " + Mathf.Round(count));
    }
}