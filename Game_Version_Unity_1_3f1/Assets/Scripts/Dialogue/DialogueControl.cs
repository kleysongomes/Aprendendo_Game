using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        en,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;  //Janela do dialogo
    public Image profileSprite;     //sprite do perfil
    public Text speechText;         //texto da fala
    public Text actorNameText;      //nome do NPC

    [Header("Settings")]
    public float typingSpeed;       //Velocidade da fala


    //Variaveis de controle
    public bool isShowing;         //janela visível ou não
    public int index;              //contador de falas
    private string[] sentences;

    public static DialogueControl instance;

    private void Awake() //chama antes do start
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray()) // Ler letra por letra
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed); //Velocidade da execução do loop
        }
    }

    //Pula para a próxima fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //Exibe a fala
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
