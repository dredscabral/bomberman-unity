using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompDrop : MonoBehaviour {

    public GameObject bombPrefab;
    private float timer = 6;
    float currCountdownValue = 0;
    float delta = .5f;
    bool extraBomb = false;
    int bombs = 0;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && currCountdownValue == 0)
        {

            Vector2 pos = transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);

            Instantiate(bombPrefab, pos, Quaternion.identity);

            if (extraBomb && bombs < 10)
            {
                bombs++;
                Debug.Log("numero de bombas" + bombs );
                StartCoroutine(StartCountdown(timer));

                if (bombs == 10)
                {
                    Debug.Log("zerei bombs e extra bomb");
                    bombs = 0;
                    extraBomb = false;
                    delta = .5f;
                }
            }            
            else
            {
                StartCoroutine(StartCountdown(timer));
            }
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ExtraBomb")
        {
            extraBomb = true;
            delta = .03125f;
            Destroy(col.gameObject);
        }
    }
}
