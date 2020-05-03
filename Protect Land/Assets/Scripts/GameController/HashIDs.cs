﻿using UnityEngine;

public class HashIDs : MonoBehaviour
{
	public int dyingState;
    public int deaBool;
    public int locomotionState;
    public int shoutState;
    public int speedFloat;
    public int sneakingBool;
    public int shoutingBool;
    public int playerInSightBool;
    public int shotFloat;
    public int aimWeightFloat;
    public int angularSpeedFloat;
    public int openBool;

    void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        deaBool = Animator.StringToHash("Dead");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        shoutState = Animator.StringToHash("Shouting.Shout");
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        shoutingBool = Animator.StringToHash("Shouting");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
        shotFloat = Animator.StringToHash("Shot");
        aimWeightFloat = Animator.StringToHash("AimWeight");
        angularSpeedFloat = Animator.StringToHash("AngularSpeed");
        openBool = Animator.StringToHash("Open");
    }
}
