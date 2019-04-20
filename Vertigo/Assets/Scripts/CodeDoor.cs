using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class CodeDoor : MonoBehaviour
{
   
    public VRTK_InteractableObject linkedObject;
    public int chiffre;


    protected virtual void OnEnable()
    {
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            linkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }
    }

    protected virtual void OnDisable()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        this.GetComponentInParent<AfficheTexte>().codeEntre += chiffre;
        this.GetComponentInParent<AfficheTexte>().AfficherTexte();
            ;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Hello dans desac InteractableObjectUsed");
    }



}
