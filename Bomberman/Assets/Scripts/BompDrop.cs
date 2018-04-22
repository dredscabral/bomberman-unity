using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompDrop : MonoBehaviour {

    public GameObject bombPrefab;
    private float timer = 6;
    float currCountdownValue = 0;
    float delta = .5f;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && currCountdownValue == 0)
        {

            Vector2 pos = transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);

            Instantiate(bombPrefab, pos, Quaternion.identity);

            StartCoroutine(StartCountdown(timer));
        }
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(delta);
            currCountdownValue--;
        }
    }
}
