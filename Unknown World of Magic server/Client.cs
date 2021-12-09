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
                Dictionary dictionary = new Dictionary();
                dictionary.FillingDictionary();

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
                    string clientCommand = command[0];

                    // выполнение команды
                    Client client = new Client();
                    client.ExecuteCommand();

                    // генерируем ответ 
                    string message;
                    message = Dictionary.dictionary[clientCommand];

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

        // выполнение команды
        public void ExecuteCommand()
        {
            #region классы
            
            Location location = new Location();
            Characteristics characteristics = new Characteristics();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Dictionary dictionary = new Dictionary();

            #endregion

            #region разработчик

            Developer developer = new Developer
                (new CommandSetInitialLocation(location, dictionary),
                new CommandSetNextLocation(location, dictionary),
                new CommandSetPreviousLocation(location, dictionary),
                new CommandIncreaseStrength(characteristics, dictionary),
                new CommandIncreaseAgility(characteristics, dictionary),
                new CommandIncreaseIntelligence(characteristics, dictionary),
                new CommandGetWarriorAttributes(dictionary),
                new CommandGetAssassinAttributes(dictionary),
                new CommandGetWizardAttributes(dictionary),
                new CommandGetBanditAttributes(dictionary),
                new CommandGetLeshiiAttributes(dictionary),
                new CommandSetPlayerName(player, dictionary),
                new CommandPlayerAttack(player, dictionary),
                new CommandRestoringHealthPoints(player, dictionary),
                new CommandRestoringActionPoints(player, dictionary),
                new CommandIncreaseExperiencePoints(player, dictionary),
                new CommandResetExperiencePoints(player, dictionary),
                new CommandIncreaseLevel(player, dictionary),
                new CommandIncreaseGold(player, dictionary),
                new CommandEnemyAttack(enemy, dictionary)
                );

            #endregion

            #region выполнение команд

            developer.ExecuteSetInitialLocation();
            developer.ExecuteSetNextLocation();
            developer.ExecuteSetPreviousLocation();
            developer.ExecuteIncreaseStrength();
            developer.ExecuteIncreaseAgility();
            developer.ExecuteIncreaseIntelligence();
            developer.ExecuteGetWarriorAttributes();
            developer.ExecuteGetAssassinAttributes();
            developer.ExecuteGetWizardAttributes();
            developer.ExecuteGetBanditAttributes();
            developer.ExecuteGetLeshiiAttributes();
            developer.ExecuteSetPlayerName();
            developer.ExecutePlayerAttack();
            developer.ExecuteRestoringHealthPoints();
            developer.ExecuteRestoringActionPoints();
            developer.ExecuteIncreaseExperiencePoints();
            developer.ExecuteResetExperiencePoints();
            developer.ExecuteIncreaseLevel();
            developer.ExecuteIncreaseGold();
            developer.ExecuteEnemyAttack();

            #endregion
        }
    }

}
