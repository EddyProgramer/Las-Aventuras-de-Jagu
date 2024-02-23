

//CODIGO PARA PODER RECIBIR LOS DATOS DESDE OTROS SCRIPTS




using UnityEngine;
using System;
using Proyecto26;
using System.Collections;



[Serializable]
public class UserPass
{
    public string emailUser;
    public string passwordUser;
    public int puntosUser;
    public int vidaUser;
    public float posNX;
    public float posNY;
}
   


public class DataManager : MonoBehaviour
{



    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase

    // Instancia estática de DataManager
    public static DataManager instance;

    /*[Serializable]
    public class UserPass
    {
        public string emailUser;

        public string passwordUser;
        public int puntosUser;

        public int vidaUser;
         
        public float posNX;
        public float posNY;
    
    }*/

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia de DataManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para guardar datos
    public void SaveData(UserPass newUser)
    {
        string jsonData = JsonUtility.ToJson(newUser); // Convertir objeto a JSON

        RestClient.Put(BASE_URL + "/Users/" + newUser.emailUser + ".json", jsonData).Then(response =>
        {
            Debug.Log("Data saved successfully!");
        }).Catch(err =>
        {
            Debug.LogError("Error saving data: " + err.Message);
        });
    }

   
public void LoadData(string emailUser, Action<UserPass> onDataLoaded)
{
    // Modifica la URL para usar el correo electrónico como clave
    RestClient.Get(BASE_URL + "Users/" + emailUser.Replace(".", "_") + ".json").Then(response =>
    {
        string jsonData = response.Text;
        if (string.IsNullOrEmpty(jsonData))
        {
            // Si no hay datos para el usuario, llama a la devolución de llamada con null
            onDataLoaded(null);
            Debug.Log("No se encontraron datos para el usuario: " + emailUser);
            return;
        }

        // Deserializar los datos del usuario
        UserPass loadedUser = JsonUtility.FromJson<UserPass>(jsonData);

        // Llamar a la función de devolución de llamada con los datos cargados
        onDataLoaded(loadedUser);
         Debug.Log("Datos cargados para el usuario: " + emailUser);
    }).Catch(err =>
    {
        Debug.LogError("Error loading data: " + err.Message);
        // En caso de error, pasar null a la función de devolución de llamada
        onDataLoaded(null);
    });


    
}

   
/**public void LoadData(string emailUser, Action<UserPass> onDataLoaded)
{
    // Modifica la URL para usar el correo electrónico como clave
    RestClient.Get(BASE_URL + "Users/" + emailUser.Replace(".", "_") + ".json").Then(response =>
    {
        string jsonData = response.Text;
        if (string.IsNullOrEmpty(jsonData))
        {
            // Si no hay datos para el usuario, llama a la devolución de llamada con null
            onDataLoaded(null);
            Debug.Log("No se encontraron datos para el usuario: " + emailUser);
            return;
        }

        // Deserializar los datos del usuario
        UserPass loadedUser = JsonUtility.FromJson<UserPass>(jsonData);

        // Llamar a la función de devolución de llamada con los datos cargados
        onDataLoaded(loadedUser);
        Debug.Log("Datos cargados para el usuario: " + emailUser);
    }).Catch(err =>
    {
        Debug.LogError("Error loading data: " + err.Message);
        // En caso de error, pasar null a la función de devolución de llamada
        onDataLoaded(null);
    });
}

// Función de devolución de llamada que se llama después de cargar los datos
public void OnDataLoaded(UserPass loadedUser)
{
    if (loadedUser != null)
    {
        Debug.Log("Datos cargados correctamente.");
        // Aquí podrías iniciar una corutina para esperar
        StartCoroutine(Esperar());
    }
    else
    {
        Debug.Log("No se pudieron cargar los datos.");
    }
}

// Corutina para esperar
private IEnumerator Esperar()
{
    Debug.Log("Iniciando espera...");
    yield return new WaitForSeconds(2f); // Esperar 2 segundos
    Debug.Log("Espera completada.");
    // Continuar con otras acciones después de la espera
}*/







}




