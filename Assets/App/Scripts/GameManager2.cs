using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using System;

public class GameManager2 : MonoBehaviour
{

    public Question[] question;
    int Zufall;
    int Correct;
    int R; //Richtig
    int F; //Falsch
    private static List<Question> unansweredQ;


    private Question currentQ;

    [SerializeField]
    private Text QText;
    [SerializeField]
    private Text[] B = new Text[4];
    [SerializeField]
    private GameObject Aw;
    [SerializeField]
    private Text AwText;

    void Start()
    {

        Aw.SetActive(false);
        if (unansweredQ == null || unansweredQ.Count == 0)
        {
            unansweredQ = question.ToList<Question>();
        }

        GetRandomQ();
    }

    void GetRandomQ()
    {
        int randomQIndex = UnityEngine.Random.Range(0, unansweredQ.Count);
        currentQ = unansweredQ[randomQIndex];
        unansweredQ.RemoveAt(randomQIndex);

        QText.text = currentQ.question;
        string Richtiges = currentQ.Answere[0];

        for (int num = 0; num < 4; num++)
        {

            Zufall = UnityEngine.Random.Range(0, ((currentQ.Answere.Length))-1); 
             B[num].text = currentQ.Answere[Zufall];
            var h = currentQ.Answere.ToList();
            if (Richtiges == currentQ.Answere[Zufall])
            {
                Correct = num;
            }
            h.RemoveAt(Zufall);
            currentQ.Answere = h.ToArray();
        }


    }

    public void IsCorrect()
    {
         if (Correct.ToString() == (EventSystem.current.currentSelectedGameObject.name))
       {
            Debug.Log("YEYYYY");
            R = R + 1;
            GetRandomQ();
       }
        else 
       {
            Debug.Log("Nochmal !!!");
            F = F + 1;
       }
   
        if (R == 5)
        {
            Aw.SetActive(true); 
            if (F > 0){
            AwText.text = "Du hast leider " + F + " Fehler gemacht.";
            }
            else
            {
            AwText.text = "Alles Richtig weiter so !";
            }
        }
    }


}
