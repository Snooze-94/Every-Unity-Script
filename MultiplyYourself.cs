using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyYourself : MonoBehaviour {

    public int timesToMultiply;
    public float timesASecond;
    float timePassed = 0;
    int timesMultiplied = 0;


    private void Start()
    {
        timesASecond = 1 / timesASecond;
    }

    void Update () {
        timePassed += Time.deltaTime;

        print(timesASecond);

        if (timesMultiplied < timesToMultiply && timesMultiplied < 100 && timePassed >= timesASecond)
        {
            var instance = Instantiate(gameObject);
            Destroy(instance.GetComponent<MultiplyYourself>());
            instance.transform.localPosition = new Vector3(0, 0, 0);
            timesMultiplied++;
            timePassed = 0;
        }
        
	}
}
