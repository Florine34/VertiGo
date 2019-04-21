using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class VerificationCode : MonoBehaviour
{
    // Start is called before the first frame update
    public string code;
    public OpenDoor door;
    public VRTK_InteractableObject linkedObject;

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
        /*Verification du bon code*/
        string entree = this.GetComponentInParent<AfficheTexte>().codeEntre;

        if(entree.Equals(code)){
            this.GetComponentInParent<AfficheTexte>().codeEntre = "OPEN";      
            door.Open();
        }
        else
        {
            this.GetComponentInParent<AfficheTexte>().codeEntre = "";
        }
        this.GetComponentInParent<AfficheTexte>().AfficherTexte();
        ;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Hello dans desac InteractableObjectUsed");
    }




 

}
