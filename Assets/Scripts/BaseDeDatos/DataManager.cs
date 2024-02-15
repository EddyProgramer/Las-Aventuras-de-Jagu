

//CODIGO PARA PODER RECIBIR LOS DATOS DESDE OTROS SCRIPTS




using UnityEngine;
using System;
using Proyecto26;
using Newtonsoft.Json;


public class DataManager : MonoBehaviour
{


   

    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase

    // Instancia estática de DataManager
    public static DataManager instance;

    [Serializable]
    public class User
    {
        public string id;
        public int puntosTotal;

        public int vidaGuardar;
         
        public float posicionGX;
        public float posicionGY;
    
    }

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
    public void SaveData(User newUser)
    {
        string jsonData = JsonUtility.ToJson(newUser); // Convertir objeto a JSON

        RestClient.Put(BASE_URL + "/usuario/" + newUser.id + ".json", jsonData).Then(response =>
        {
            Debug.Log("Data saved successfully!");
        }).Catch(err =>
        {
            Debug.LogError("Error saving data: " + err.Message);
        });
    }

   



 // Método para cargar datos utilizando JSON.NET



 
    public void LoadData(string userId, Action<User> onDataLoaded)
    {
        RestClient.Get(BASE_URL + "/usuario/" + userId + ".json").Then(response =>
        {
            string jsonData = response.Text;
            User loadedUsers = JsonConvert.DeserializeObject<User>(jsonData);
            
            // Llamar a la función de devolución de llamada con los datos cargados
            onDataLoaded(loadedUsers);
        }).Catch(err =>
        {
            Debug.LogError("Error loading data: " + err.Message);
            // En caso de error, pasar null a la función de devolución de llamada
            onDataLoaded(null);
        });
    }

      // Definir un evento que se activará cuando se carguen los datos


    // Resto del código...

    // Método para cargar datos
  /*  public void LoadData(string userId)
    {
        RestClient.Get(BASE_URL + "/usuario/" + userId + ".json").Then(response =>
        {
            string jsonData = response.Text;
            User loadedUser = JsonConvert.DeserializeObject<User>(jsonData);
            
            // Disparar el evento con los datos cargados
            DataLoaded?.Invoke(loadedUser);
        }).Catch(err =>
        {
            Debug.LogError("Error loading data: " + err.Message);
            // En caso de error, pasar null al evento
            DataLoaded?.Invoke(null);
        });
    }*/




}




