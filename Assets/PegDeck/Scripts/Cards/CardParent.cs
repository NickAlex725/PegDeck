using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CardParent : MonoBehaviour
{
    [Header("Parent")]
    [SerializeField] private float _lerpSpeed = 5f;
    [SerializeField] protected int _energyCost;
    [Space]
    [SerializeField] protected CardType _type;
    public int EnergyCost => _energyCost;
    public CardType CardType => _type;

    protected CardManager _cardManager;
    protected PeggleManager _peggleManager;
    protected Player _player;
    protected Enemy _target;
    protected int _attackGain;

    [Header("Unity Events")]
    public UnityEvent OnAtTargetPositionUE;
    public UnityEvent OnDoCardActionUE;

    public Action OnCardUpdate;

    private Animator _animator;
    private Vector3 _targetPosition;
    private bool _canUse = true;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _cardManager = FindObjectOfType<CardManager>();
        _peggleManager = FindObjectOfType<PeggleManager>();
        _target = FindObjectOfType<Enemy>();
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.enabled = false;
    }
    private void Update()
    {
        if(transform.position != _targetPosition)
        {
            if(Vector3.Distance(transform.position, _targetPosition) > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _lerpSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = _targetPosition;
                _canUse = true;

                OnAtTargetPositionUE?.Invoke();
                OnCardUpdate?.Invoke();
            }
        }
    }

    public virtual void CardAction()
    {
        if(_canUse == true)
        {
            _player.UseEnergy(_energyCost);
            //add base func here (animations, sound, ect)
            //DestoryCard();

            OnDoCardActionUE?.Invoke();
            OnCardUpdate?.Invoke();

            Vector3 discardPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            MoveTowardsPosition(discardPos);

            StartCoroutine(DelayDiscard(0.5f));
        }
    }
    private void AfterCardAction()
    {
        _cardManager.DiscardCard(this);
    }

    public void MoveTowardsPosition(Vector3 position)
    {
        _targetPosition = position;
        _canUse = false;

        OnCardUpdate?.Invoke();
    }
    public void HideCard()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    public void UnhideCard()
    {
        gameObject.SetActive(true);

        OnCardUpdate?.Invoke();
    }

    IEnumerator DelayDiscard(float delay)
    {
        yield return new WaitForSeconds(delay);

        AfterCardAction();
    }
}

public enum CardType { Attack, Defense, Energy, Special}
