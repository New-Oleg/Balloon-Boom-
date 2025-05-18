using DG.Tweening;
using UnityEngine;

namespace MyTimer
{
    public class Timer
    {
        private Tween timerTween;

        public void Start(float duration, System.Action onComplete)
        {
            Kill(); // отменить предыдущий
            timerTween = DOVirtual.DelayedCall(duration, () => onComplete?.Invoke());
        }

        public void Kill()
        {
            timerTween?.Kill();
        }

        public void Pause() => timerTween?.Pause();
        public void Resume() => timerTween?.Play();
    }
}