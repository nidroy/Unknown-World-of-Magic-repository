using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Unknown_World_of_Magic_server
{
    public class Client
    {
        static int port = 8005; // порт для приема входящих запросов
        public static string[] command { get; set; } // команда

        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание команд...");

                // заполняем словарь
                Client client = new Client();
                client.FillingDictionary();

                while (true)
                {
                    Socket handler = listenSocket.Accept();

                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                 
                    command = builder.ToString().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                    // генерируем ответ 
                    string message;
                    message = Dictionary.dictionary[command[0]].Execute();

                    // отправляем ответ
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);

                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        // заполнение словаря
        public void FillingDictionary()
        {
            #region классы
            
            Location location = new Location();
            Characteristics characteristics = new Characteristics();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Database database = new Database();

            #endregion

            #region разработчик

            Dictionary dictionary = new Dictionary
                (new CommandSetInitialLocation(location),
                new CommandSetNextLocation(location),
                new CommandSetPreviousLocation(location),
                new CommandIncreaseStrength(characteristics),
                new CommandIncreaseAgility(characteristics),
                new CommandIncreaseIntelligence(characteristics),
                new CommandGetWarriorAttributes(),
                new CommandGetAssassinAttributes(),
                new CommandGetWizardAttributes(),
                new CommandGetBanditAttributes(),
                new CommandGetLeshiiAttributes(),
                new CommandSetPlayerName(player),
                new CommandPlayerAttack(player),
                new CommandRestoringHealthPoints(player),
                new CommandRestoringActionPoints(player),
                new CommandIncreaseExperiencePoints(player),
                new CommandResetExperiencePoints(player),
                new CommandIncreaseLevel(player),
                new CommandIncreaseGold(player),
                new CommandEnemyAttack(enemy),
                new CommandGetPlayers(database),
                new CommandGetAttributes(database),
                new CommandSaveGame(database),
                new CommandCreatePlayer(database)
                );

            #endregion

            #region заполнение словаря

            dictionary.FillingDictionary();

            #endregion
        }
    }

}
