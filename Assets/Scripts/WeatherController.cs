using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for Controllering the weather particle effects along with changing skybox
 * Trees are currently just placed in a preset location that is out of water and below mountains
 */
public class WeatherController : MonoBehaviour
{
    public GameObject Leaves;
    public GameObject Snow;

    public enum Weather { Snowy, Fall };
    public Weather currentWeather;
    public Material nightSkyBox;
    public Material daySkyBox;

    // Start is called before the first frame update
    void Start()
    {
        currentWeather = Weather.Fall;
        RenderSettings.skybox = nightSkyBox;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (currentWeather == Weather.Snowy)
            {
                currentWeather = Weather.Fall;
            }

            else if (currentWeather == Weather.Fall)
            {
                currentWeather = Weather.Snowy;
            }
        }

        if (Input.GetKeyDown("tab"))
        {
            if (RenderSettings.skybox == nightSkyBox)
            {
                RenderSettings.skybox = daySkyBox;
            }

            else if (RenderSettings.skybox == daySkyBox)
            {
                RenderSettings.skybox = nightSkyBox;
            }
        }

        if (currentWeather == Weather.Snowy)
        {
            Snow.SetActive(true);
            Leaves.SetActive(false);
        }

        if (currentWeather == Weather.Fall)
        {
            Leaves.SetActive(true);
            Snow.SetActive(false);
        }
    }
}
