using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    TextMeshProUGUI scoreGT;
    int score = 0;

    private void Awake()
    {
        scoreGT = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedWith = other.gameObject;
        if (collidedWith.layer == LayerMask.NameToLayer("Apples"))
        {
            Destroy(collidedWith);
            score += 100;
            scoreGT.text = "Score: " + score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
