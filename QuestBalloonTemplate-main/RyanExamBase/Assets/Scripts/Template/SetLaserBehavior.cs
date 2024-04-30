using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to the LaserPointer script's behavior property.
/// LaserPointer is part of the SampleFramework module in the SDK, used in the UIHelpers prefab.
/// Add this script to the LaserPointers object to customize the laser's behavior.
/// </summary>
public class SetLaserBehavior : MonoBehaviour
{
    LaserPointer laserPointer;

    [SerializeField]
    private LaserPointer.LaserBeamBehavior laserBehavior = LaserPointer.LaserBeamBehavior.OnWhenHitTarget;

    // Start is called before the first frame update
    void Start()
    {
        laserPointer = this.GetComponent<LaserPointer>();
        laserPointer.laserBeamBehavior = laserBehavior;
    }
}
