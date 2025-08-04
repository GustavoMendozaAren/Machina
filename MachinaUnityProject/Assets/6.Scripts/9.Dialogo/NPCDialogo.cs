using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteraccionExtraNPC
{
    Quest,
    Tienda,
    Crafting
}

[CreateAssetMenu]
public class NPCDialogo : ScriptableObject
{
    [Header("INFO")]
    public string Nombre;
    //public Sprite Icono;
    public bool ContieneInteraccionExtra;
    public InteraccionExtraNPC InteraccionExtra;
    public bool IsEspetial;
    public string MisionID;
    public int CantidadProgreso;

    [Header("SALUDO")]
    [TextArea] public string Saludo;

    [Header("CHAT")]
    public DialogoTexto[] Conversacion;

    [Header("DESPEDIDA")]
    [TextArea] public string Despedida;
}


[Serializable]
public class DialogoTexto
{
    [TextArea] public string Oracion;
}
