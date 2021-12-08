using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Unknown_World_of_Magic_server
{
    public class Client
    {
        static int port = 8005; // порт для приема входящих запросов
        public static string response { get; set; } // ответ
        public static string command { get; set; } // команда

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

                    // выполнение полученной команды
                    Client client = new Client();
                    command = builder.ToString();
                    client.ExecutingCommand();

                    // отправляем ответ
                    string message = response;
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
        public void ExecutingCommand()
        {
            #region классы

            Location location = new Location(); // локация
            Characteristics characteristics = new Characteristics(); // характеристики
            IGetAttributes warrior = new Warrior(); // воин
            IGetAttributes assassin = new Assassin(); // ассасин
            IGetAttributes wizard = new Wizard(); // маг
            IGetAttributes bandit = new Bandit(); // разбойник
            IGetAttributes leshii = new Leshii(); // леший
            Player player = new Player(); // игрок
            Enemy enemy = new Enemy(); // враг

            #endregion

            #region разработчик

            Developer developer = new Developer( 
                new CommandSetInitialLocation(location),
                new CommandSetNextLocation(location),
                new CommandSetPreviousLocation(location),
                new CommandIncreaseStrength(characteristics),
                new CommandIncreaseAgility(characteristics),
                new CommandIncreaseIntelligence(characteristics),
                new CommandGetWarriorAttributes(warrior),
                new CommandGetAssassinAttributes(assassin),
                new CommandGetWizardAttributes(wizard),
                new CommandGetBanditAttributes(bandit),
                new CommandGetLeshiiAttributes(leshii),
                new CommandSetPlayerName(),
                new CommandPlayerAttack(player),
                new CommandRestoringHealthPoints(player),
                new CommandRestoringActionPoints(player),
                new CommandIncreaseExperiencePoints(player),
                new CommandResetExperiencePoints(player),
                new CommandIncreaseLevel(player),
                new CommandIncreaseGold(player),
                new CommandEnemyAttack(enemy)
                );

            #endregion

            #region выполнение команд

            #region локации

            developer.ExecutingSetInitialLocation();
            developer.ExecutingSetNextLocation();
            developer.ExecutingSetPreviousLocation();

            #endregion

            #region характеристик

            developer.ExecutingIncreaseStrength();
            developer.ExecutingIncreaseAgility();
            developer.ExecutingIncreaseIntelligence();

            #endregion

            #region получения атрибутов персонажа

            developer.ExecutingGetWarriorAttributes();
            developer.ExecutingGetAssassinAttributes();
            developer.ExecutingGetWizardAttributes();
            developer.ExecutingGetBanditAttributes();
            developer.ExecutingGetLeshiiAttributes();

            #endregion

            #region игрока

            developer.ExecutingSetPlayerName();
            developer.ExecutingPlayerAttack();
            developer.ExecutingRestoringHealthPoints();
            developer.ExecutingRestoringActionPoints();
            developer.ExecutingIncreaseExperiencePoints();
            developer.ExecutingResetExperiencePoints();
            developer.ExecutingIncreaseLevel();
            developer.ExecutingIncreaseGold();

            #endregion

            #region врага

            developer.ExecutingEnemyAttack();

            #endregion

            #endregion
        }
    }
}
