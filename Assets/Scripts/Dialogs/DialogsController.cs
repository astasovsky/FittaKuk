using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog
{
    public string[] replicas;
}
public class DialogsController : MonoBehaviour
{
    enum NPS {
        //Первый уровень
        Worker,
        Protests,
        Ant,
        Vegan,
        Crow,
        Hedgehog,
        
        //Второй уровень
        Seller,
        Activist,
        Newsboy,

        //Третий уровень
        Mother,
        Ball,
        Cat
        
    };
    [SerializeField] NPS _NPS = NPS.Worker;
    [SerializeField] Dialog[] _dialogs;
    [SerializeField] Text _text;

    int NPCNumber;
    int currentDialogNumber = 0;
    int currentReplica = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentReplica < _dialogs[currentDialogNumber].replicas.Length)
            {
                _text.text = _dialogs[currentDialogNumber].replicas[currentReplica];
                currentReplica++;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                SendDialogEnding();
                this.gameObject.SetActive(false);
                LoadDialog.IsDialog = false;
                PlayerController.CanMove = true;
            }
        }
    }
    private void OnEnable()
    {
        switch (_NPS)
        {
            case NPS.Worker:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(0);
                break;
            case NPS.Protests:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(1);
                break;
            case NPS.Ant:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(2);
                break;
            case NPS.Vegan:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(3);
                break;
            case NPS.Crow:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(4);
                break;
            case NPS.Hedgehog:
                currentDialogNumber = DialogLogicLevel1.GetCurrentDialogNumber(5);
                break;
            case NPS.Seller:
                currentDialogNumber = DialogLogicLevel2.GetCurrentDialogNumber(0);
                break;
            case NPS.Activist:
                currentDialogNumber = DialogLogicLevel2.GetCurrentDialogNumber(1);
                break;
            case NPS.Newsboy:
                currentDialogNumber = DialogLogicLevel2.GetCurrentDialogNumber(2);
                break;
            case NPS.Mother:
                currentDialogNumber = 0;
                break;
            case NPS.Ball:
                currentDialogNumber = 0;
                break;
            case NPS.Cat:
                currentDialogNumber = 0;
                break;
        }
        currentReplica = 1;
        _text.text = _dialogs[currentDialogNumber].replicas[0];
    }

    void SendDialogEnding()
    {
        switch (_NPS)
        {
            case NPS.Worker:
                DialogLogicLevel1.SetDialogEnding(0, currentDialogNumber);
                break;
            case NPS.Protests:
                DialogLogicLevel1.SetDialogEnding(1, currentDialogNumber);
                break;
            case NPS.Ant:
                DialogLogicLevel1.SetDialogEnding(2, currentDialogNumber);
                break;
            case NPS.Vegan:
                DialogLogicLevel1.SetDialogEnding(3, currentDialogNumber);
                break;
            case NPS.Crow:
                DialogLogicLevel1.SetDialogEnding(4, currentDialogNumber);
                break;
            case NPS.Hedgehog:
                DialogLogicLevel1.SetDialogEnding(5, currentDialogNumber);
                break;
            case NPS.Seller:
                DialogLogicLevel2.SetDialogEnding(0, currentDialogNumber);
                break;
            case NPS.Activist:
                DialogLogicLevel2.SetDialogEnding(1, currentDialogNumber);
                break;
            case NPS.Newsboy:
                DialogLogicLevel2.SetDialogEnding(2, currentDialogNumber);
                break;
        }
    }
}
