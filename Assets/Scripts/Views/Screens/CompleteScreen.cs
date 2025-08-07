using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteScreen : BaseView
{
    [SerializeField] private Button _repeatBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private TMP_Text _scoreAmountText;

    public event Action RepearClicked;
    public event Action ExitClicked;


    private void Start()
    {
        _repeatBtn.onClick.AddListener(() =>
        {
            if (RepearClicked != null)
            {
                RepearClicked();
            }
        });

        _exitBtn.onClick.AddListener(() =>
        {
            if (ExitClicked != null)
            {
                ExitClicked();
            }
        });
    }

    public void ChangeScoreAmount(int amount)
    {
        _scoreAmountText.text = amount.ToString();
    }
}
