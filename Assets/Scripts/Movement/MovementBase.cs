using UnityEngine;
namespace OG.Movement
{
    public abstract class MovementBase : MonoBehaviour
    {
        [SerializeField] protected float maxSpeed;
        [SerializeField] protected float speedMultiplier;

        [SerializeField] protected TransformInterpolator transformInterpolator;

        public float SpeedMultiplier
        {
            get => speedMultiplier;
            set => speedMultiplier = value;
        }
    }
}