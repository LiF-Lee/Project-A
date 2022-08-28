using UnityEngine;
using WebSocket = NativeWebSocket.WebSocket;
using WebSocketState = NativeWebSocket.WebSocketState;

public class WebSocket_Client : MonoBehaviour
{
    private string IP = "192.168.31.145";
    private string Port = "8080";
    WebSocket ws;
    GameObject tPlayer;

    private async void Start()
    {
        ws = new WebSocket($"ws://{IP}:{Port}");

        ws.OnOpen += () =>
        {
            Debug.Log("Connection open!");
        };

        ws.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        ws.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        ws.OnMessage += (bytes) =>
        {
            //Debug.Log("OnMessage!");
            //Debug.Log(bytes);

            // getting the message as a string
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("OnMessage! " + message);
        };

        // Keep sending messages at every 0.3s
        InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        // waiting for messages
        await ws.Connect();
    }

    private void Update()
    {
        #if !UNITY_WEBGL || UNITY_EDITOR
            ws.DispatchMessageQueue();
        #endif
    }

    async void SendWebSocketMessage()
    {
        if (ws.State == WebSocketState.Open)
        {
            // Sending bytes
            //await ws.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            tPlayer = GameObject.FindWithTag("Player");
            if (tPlayer == null)
            {
                await ws.SendText("Player Dead");
            }
            else
            {
                await ws.SendText($"{tPlayer}");
            }
        }
    }

    private async void OnApplicationQuit()
    {
        await ws.Close();
    }
}
