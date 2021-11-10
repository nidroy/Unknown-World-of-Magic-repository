using System;
using System.Collections.Generic;
using System.Text;

namespace Unknown_World_of_Magic_server
{
    public class ManagingResponses
    {
        public static string serverResponse; // ответ сервера

        // установить ответ сервера
        public void SetServerResponse(string response)
        {
            serverResponse = response;
        }
    }
}
