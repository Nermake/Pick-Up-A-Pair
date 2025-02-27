using Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Animator _animator;
        
        private CardPresenter _presenter;

        public void SetPresenter(CardPresenter presenter) => _presenter = presenter;

        public void SetSprite(Sprite sprite) => _image.sprite = sprite;

        public void FlipCard() => _animator.SetBool("flip", true);
        public void HideCard() => _animator.SetBool("flip", false);

        public void AnimationStart() => _presenter.LockClick();
        public void AnimationShowCard() => _presenter.ShowCard();
        public void AnimationEnd() => _presenter.CheckPair();
        
        public void OnClick() => _presenter.OnCardClicked();
    }
}