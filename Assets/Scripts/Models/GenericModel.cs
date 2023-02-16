using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GenericModel", menuName = "Tools/Persistence", order = 0)]
public class GenericModel: Persistence
{
    //Aca crean los parametros que necesiten guardar; imagenes posiciones etc
    //lo guardan en este escriptable de manera local y en un onaplicationquit se guarda todo en un json
    //y secarga con load al escriptable y del scriptable ya lo llevan donde lo necesiten

    //public List<GameObject> seeds; 
    //public List<GameObject> plants;
    public GameObject Player;

    //public InventoryManager inventoryManager;

    //map seeds
    //map plants 
    //inventary 
    //powerUps
    //achievements 
}
