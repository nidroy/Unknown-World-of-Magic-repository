using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Server : MonoBehaviour
{
    // адрес и порт сервера, к которому будем подключаться
    static int port = 8005; // порт сервера
    static string address = "127.0.0.1"; // адрес сервера

    /// <summary>
    /// отправка сообщения на сервер и полуение ответа
    /// </summary>
    /// <param name="message">сообщение отправляемое на сервер</param>
    /// <returns>ответ сервера</returns>
    public string SendingMessage(string message)
    {
        string response = ""; // ответ сервера

        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);

            // получаем ответ
            data = new byte[256]; // буфер для ответа
            StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            response = builder.ToString();

            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        return response;
    }

}
