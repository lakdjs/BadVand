using System;
using Core;
using UnityEngine;

namespace LvlSystem
{
    public class LVL
    {
        public event Action<bool> OnLvlCompleted; 
        private FinishLvl _finishLvl;
        public LVL(FinishLvl finishLvl)
        {
            _finishLvl = finishLvl;
        }

        public void Bind()
        {
            _finishLvl.OnLvlFinished += LvlUp;
        }
        private void LvlUp(bool state)
        {
            PlayerPrefs.SetInt("LVL",PlayerPrefs.GetInt("LVL")+1);
            OnLvlCompleted?.Invoke(true);
        }
    }
}
