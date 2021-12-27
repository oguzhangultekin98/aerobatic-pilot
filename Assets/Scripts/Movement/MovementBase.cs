using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float maxSpeed;
        [SerializeField] protected float speedMultiplier;

        public float SpeedMultiplier
        {
            get => speedMultiplier;
            set => speedMultiplier = value;
        }
    }
