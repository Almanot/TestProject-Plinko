using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Text countText;
    private int ballCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballCount++;
            UpdateCountText();
            Destroy(collision.gameObject);
        }
    }

    public void ResetCount()
    {
        ballCount = 0;
        UpdateCountText();
    }

    private void UpdateCountText()
    {
        countText.text = ballCount.ToString();
    }
}
