using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCom : MonoBehaviour {
    public Rise elevator;

    public void DisableTrap() {
        elevator.DisableTrap();
    }

    public void EnabledTrap() {
        elevator.EnabledTrap();
    }
}
