using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace MENU
{
    public class MainMenuUI : BaseBehavior
    {
        [SerializeField] private CanvasGroup title;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private GameObject settingsCreditsPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        
        public float animationDuration = 0.5f;
        private Vector3 hiddenScale = Vector3.zero;
        private Vector3 visibleScale = Vector3.one;
        
        private float INITIAL_DELAY = 1f;
        private const float DELAY_BETWEEN_BUTTONS = 0.3f;
        
        private List<Button> _buttons = new List<Button>();
        private List<Sequence> _animationSequence = new List<Sequence>();

        private void Awake()
        {
            settingsCreditsPanel.transform.localScale = hiddenScale;
            settingsPanel.transform.localScale = hiddenScale;
            creditsPanel.transform.localScale = hiddenScale;
            _buttons.Add(playButton);
            _buttons.Add(quitButton);
            _buttons.Add(settingsButton);
            AnimateTitle();
            AnimateButtons();
        }

        private void AnimateTitle()
        {
            title.alpha = 0f;
            title.DOFade(1f, 1.8f).SetEase(Ease.InQuint);
        }

        private void AnimationButton(int index, float delay)
        {
            if (_animationSequence.Count >= index)
            {
                _animationSequence.Add(DOTween.Sequence());
            }
            else
            {
                if (_animationSequence[index].IsPlaying())
                {
                    _animationSequence[index].Kill(true);
                }
            }

            var seq = _animationSequence[index];
            var button = _buttons[index];
            seq.Append(button.transform.DOScale(1, 0.1f));
            seq.Append(button.transform.DOPunchScale(Vector3.one * 0.6f, 0.8f, 6, 0.3f).SetEase(Ease.OutCirc));
            seq.PrependInterval(delay);
        }
        
        private void AnimateButtons()
        {

            for (int i = 0; i < 3; i++)
            {
                _buttons[i].transform.localScale = Vector3.zero;
                AnimationButton(i, INITIAL_DELAY + DELAY_BETWEEN_BUTTONS * i);
            }
        }
        
        public void OpenSettingsCreditsPanel()
        {
            settingsCreditsPanel.transform.localScale = hiddenScale;
            settingsCreditsPanel.transform.DOScale(visibleScale, animationDuration).SetEase(Ease.OutBack);
        }
        
        public void CloseSettingsCreditsPanel()
        {
            settingsCreditsPanel.transform.DOScale(hiddenScale, animationDuration).SetEase(Ease.InBack);
            settingsCreditsPanel.transform.localScale = hiddenScale;
        }
        
        public void OpenSettingsPanel()
        {
            settingsPanel.transform.localScale = hiddenScale;
            settingsPanel.transform.DOScale(visibleScale, animationDuration).SetEase(Ease.OutBack);
        }
        
        public void CloseSettingsPanel()
        {
            settingsPanel.transform.DOScale(hiddenScale, animationDuration).SetEase(Ease.InBack);
            settingsPanel.transform.localScale = hiddenScale;
        }
        
        public void OpenCreditsPanel()
        {
            creditsPanel.transform.localScale = hiddenScale;
            creditsPanel.transform.DOScale(visibleScale, animationDuration).SetEase(Ease.OutBack);
        }
        
        public void CloseCreditsPanel()
        {
            creditsPanel.transform.DOScale(hiddenScale, animationDuration).SetEase(Ease.InBack);
            creditsPanel.transform.localScale = hiddenScale;
        }
        
    }
}
