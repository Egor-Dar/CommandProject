using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerAction : MonoBehaviour, IInteractable, IEventSubscriber, IEventHandler
    {
        [SerializeField] private PlayerPlayableData data;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float runSpeed;
        [SerializeField] private float speedJoystick;
        [SerializeField] private Transform endPoint;
        private Coroutine _seterNewSpeed;
        private IAnimatable _animatable;
        private ISkinned _skinned;
        private bool _isPaused = false;
        private PlayerDelegates.GetEndPoint _getEndPoint;


        private void SetPosition(Transform newTransform) => transform.position = newTransform.position;
        private void OnStart()
        {
            _isPaused = !_isPaused;
            _animatable.Paused(_isPaused);
        }

        private void Start()
        {
            _animatable = new AnimatorController(data);
            _skinned = new SkinController(data);
            endPoint = _getEndPoint.Invoke();
            OnStart();
        }

        private void FixedUpdate()
        {
            if (_isPaused) return;
            if (Vector3.Distance(transform.position, endPoint.position) <= 15){_animatable.Paused(true); runSpeed = 0.5f;}
            else runSpeed = 0.2f;
            characterController.Move(Vector3.back * runSpeed);
        }

        private void Movement(float speed)
        {
            if (_isPaused) return;
            characterController.Move(Vector3.right * speed * speedJoystick);
        }
        public void SetBonus(IBonus bonus) => bonus.StartUse(_skinned.GetCurrentModel(), data.GetAnimator());

        private void End()
        {
            _animatable.End();
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerDelegates.Death)End,
                (PlayerDelegates.Movement)Movement,
                (PlayerDelegates.SetTransform)SetPosition,
                (GameDelegates.OnStart)OnStart
            };
        }

        public void InvokeEvents()
        {

        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref _getEndPoint, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref _getEndPoint, unsubscribers);
        }
    }

    public interface IInteractable
    {
        public void SetBonus(IBonus bonus);
    }
}
