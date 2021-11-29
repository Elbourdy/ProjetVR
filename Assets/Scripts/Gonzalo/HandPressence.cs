using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPressence : MonoBehaviour
{
    bool foundDevices = false;
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    public GameObject spawnedHandModel;
    private Animator handAnimator;

    void Start()
    {
        StartCoroutine(GetDevices(1.0f));
    }

    IEnumerator GetDevices(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        Debug.Log("Enumerating XR Devices...");
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        Debug.Log("Done!");
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(Controller => Controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not found controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }
    void UpdateHandAnimator()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue); 
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }        
        
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float gripValue))
        {
            handAnimator.SetFloat("Grip", triggerValue); 
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }



    void Update()
    {
        /*if (foundDevices)
            return;
        foundDevices = true;

        */
        if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
            UpdateHandAnimator();
        }

    }

}
