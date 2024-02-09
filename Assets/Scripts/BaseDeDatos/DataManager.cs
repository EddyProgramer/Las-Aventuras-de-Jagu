/*using UnityEngine;
using System;
using Proyecto26;

public class DataManager : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase

    [Serializable]
    public class User
    {
        public int id;
        public string name;
      //  public string username;
      
    }

    // Método para guardar datos
    public void SaveData()
    {
        User newUser = new User
        {
            id = 50,
            name = "John Doe",
         
        };

        string jsonData = JsonUtility.ToJson(newUser); // Convertir objeto a JSON

        RestClient.Put(BASE_URL + "/usuario/" + newUser.id + ".json", jsonData).Then(response =>
        {
            Debug.Log("Data saved successfully!");
        }).Catch(err =>
        {
            Debug.LogError("Error saving data: " + err.Message);
        });
    }

    // Método para cargar datos
    public void LoadData()
    {
        RestClient.Get(BASE_URL + "/users/1.json").Then(response =>
        {
            string jsonData = response.Text;
            User loadedUser = JsonUtility.FromJson<User>(jsonData); // Convertir JSON a objeto

            Debug.Log("Data loaded successfully:");
            Debug.Log("ID: " + loadedUser.id);
            Debug.Log("Name: " + loadedUser.name);
           // Debug.Log("Username: " + loadedUser.username);
       
        }).Catch(err =>
        {
            Debug.LogError("Error loading data: " + err.Message);
        });
    }
}*/







//CODIGO PARA PODER RECIBIR LOS DATOS DESDE OTROS SCRIPTS




using UnityEngine;
using System;
using Proyecto26;

public class DataManager : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase

    // Instancia estática de DataManager
    public static DataManager instance;

    [Serializable]
    public class User
    {
        public int id;
        public int puntosTotal;

        public int vidaGuardar;

    
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

    // Método para cargar datos
    public void LoadData(int userId)
    {
        RestClient.Get(BASE_URL + "/usuario/" + userId + ".json").Then(response =>
        {
            string jsonData = response.Text;
            User loadedUser = JsonUtility.FromJson<User>(jsonData); // Convertir JSON a objeto

            Debug.Log("Data loaded successfully:");
            Debug.Log("ID: " + loadedUser.id);
            Debug.Log("Puntos: " + loadedUser.puntosTotal);
             Debug.Log("Cantidad Vida: " + loadedUser.vidaGuardar);
        }).Catch(err =>
        {
            Debug.LogError("Error loading data: " + err.Message);
        });
    }
}
