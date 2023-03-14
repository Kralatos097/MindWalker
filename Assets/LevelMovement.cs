using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public float startTime;
    
    [Space]
    public float speed;
    
    [Space]
    public float speedingTime;
    public float particleSpeedTarget;
    public int moveFOV = 70;

    [Space] public TextMeshProUGUI text;
    
    private bool _lvlStarted = false;
    private float startTimeCnt = 0;
    private float speedingTimeCnt;
    private float camFovDiff;

    private Camera cam;
    private ParticleSystem speedLine;
    private float particleSpeedDiff;

    void Start()
    {
        cam = Camera.main;
        speedLine = cam.transform.GetComponentInChildren<ParticleSystem>();

        camFovDiff = moveFOV - cam.fieldOfView;
        particleSpeedDiff = particleSpeedTarget - speedLine.main.startSpeed.constant;
        
        //Invoke("LaunchLevel", startTime);
        
        startTimeCnt = startTime;
    }

    void Update()
    {
        if (_lvlStarted)
        {
            if(speedingTimeCnt <= speedingTime)
            {
                cam.fieldOfView += (camFovDiff * Time.deltaTime)/speedingTime;
                var speedLineMain = speedLine.main;
                speedLineMain.startSpeed = speedLineMain.startSpeed.constant + (particleSpeedDiff * Time.deltaTime)/speedingTime;
                speedingTimeCnt += Time.deltaTime;
            }
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            if (startTimeCnt <= 0)
            {
                text.text = "GO";
                LaunchLevel();
                Invoke("HideText", .75f);
            }
            else
            {
                startTimeCnt -= Time.deltaTime;
                text.text = Mathf.CeilToInt(startTimeCnt).ToString();
            }
        }
}

    private void LaunchLevel()
    {
        _lvlStarted = true;
    }

    private void HideText()
    {
        text.gameObject.SetActive(false);
    }
}
