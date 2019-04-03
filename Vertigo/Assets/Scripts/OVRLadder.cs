using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRLadder : MonoBehaviour
{
    private OVRPlayerController _fps = null;

    private OVRLadderController _lc = null;

    private bool _activated = false;

    private bool _use = false;

    private bool _has_controllers = false;

    void Start()
    {

        GameObject _go = GameObject.FindGameObjectWithTag("OVRPlayerController");

        if (_go != null)
        {

            _fps = _go.GetComponent<OVRPlayerController>();

            _lc = _go.GetComponent<OVRLadderController>();

            if ((_fps == null) || (_lc == null))
            {

                Debug.LogWarning("Not found \"LadderController\" or / and \"OVRController\" components");

            }
            else
            {

                _activated = true;

            }

        }

    }



    void Update()
    {

        if (_activated && _has_controllers && Input.GetKeyDown(KeyCode.F) || OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        {

            if (_use)
            {

                _use = _lc.enabled = false;

                _fps.enabled = true;

                _fps._init();
               

            }
            else
            {

                _fps.enabled = false;

                _use = _lc.enabled = true;

                _lc._init();

            }

        }

    }


    void OnTriggerEnter()
    {

        if (GetComponent<Collider>().tag == "Ladder")
        {

            _has_controllers = true;

        }

    }

    void OnTriggerExit()
    {

        if (GetComponent<Collider>().tag == "Ladder")
        {

            _has_controllers = false;

            if (_activated)
            {

                _use = _lc.enabled = false;

                _fps.enabled = true;

                _fps._init();

                ///We Jump out of the Ladder.

                _fps._JumpOutLadder();



            }

        }

    }

}
