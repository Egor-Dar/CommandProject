using System;
using System.Collections.Generic;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;

namespace Player
{
    public class SkinController : ISkinned, IEventSubscriber
    {
        private PlayerPlayableData _data;
        private SkinChanger _skinChanger;
        private List<ModelLink> _links;
        private int _skinIndex; //Not current skin index
        public SkinController(PlayerPlayableData data)
        {
            EventInitializer.Subscribe(this);
            _data = data;
            _links = _data.GetSkins();
            _skinChanger = new SkinChanger();
            _skinChanger.SetSkin(data.GetDefaultSkin(), data.GetAnimator());
        }

        public ModelLink GetCurrentModel() => _skinChanger.GetCurrentModel();
        public void ListNextSkin()
        {
            _skinIndex++;
            if (_links.Count-1 < _skinIndex) _skinIndex = 0;
            _skinChanger.SetSkin(_links[_skinIndex], _data.GetAnimator());
        }
        public void ListPreviousSkin()
        {
            _skinIndex--;
            if (0 > _skinIndex) _skinIndex = _links.Count-1;
            _skinChanger.SetSkin(_links[_skinIndex], _data.GetAnimator());
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (StoreDelegates.ListNextSkin)ListNextSkin,
                (StoreDelegates.ListPreviousSkin)ListPreviousSkin
            };
        }
    }
}
