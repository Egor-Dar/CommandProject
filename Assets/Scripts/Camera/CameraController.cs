using System;
using Base;
using Cinemachine;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace CameraScript
{
    public class CameraController : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private CinemachineVirtualCamera play;
        [SerializeField] private CinemachineVirtualCamera shop;
        private CinemachineVirtualCamera _currentCamera;
        private bool _isShop = false;

        private void Start()
        {
            SetCurrentCamera(play);
        }

        private void OnShop()
        {
            _isShop = !_isShop;
            SetCurrentCamera(_isShop ? shop : play);
        }
        private void SetCurrentCamera(CinemachineVirtualCamera camera)
        {
            if (_currentCamera != null) _currentCamera.Priority -= 1;
            _currentCamera = camera;
            _currentCamera.Priority += 1;
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (GameDelegates.ShopOpenClose)OnShop
            };
        }
    }
}
