using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public static Action<Quest> EventoQuestCompletado;

    [Header("INFO")]
    public string Nombre;
    public string ID;
    public int CantidadObjetivo;

    [Header("DESCRIPCION")]
    [TextArea] public string Descripcion;

    [Header("RECOMPENSAS")]
    public int RecompensaOro;
    //public float RecompensaExp;

    [HideInInspector] public int CantidadActual;
    [HideInInspector] public bool QuestCompletadoCheck;
    [HideInInspector] public bool QuestAceptado;

    public void AniadirProgreso(int cantidad)
    {
        CantidadActual += cantidad;
        VerificarQuestCompletado();
    }
    
    private void VerificarQuestCompletado()
    {
        if (CantidadActual >= CantidadObjetivo)
        {
            CantidadActual = CantidadObjetivo;
            QuestCompletado();
        }
    }

    private void QuestCompletado()
    {
        if (QuestCompletadoCheck)
            return;

        QuestCompletadoCheck = true;
        EventoQuestCompletado?.Invoke(this);
    }

    public void ResetQuest()
    {
        QuestAceptado = false;
        QuestCompletadoCheck = false;
        CantidadActual = 0;
    }
}
