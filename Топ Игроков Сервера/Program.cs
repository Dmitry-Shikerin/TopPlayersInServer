using System;
using System.Collections.Generic;
using System.Linq;

namespace Топ_Игроков_Сервера
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.Work();
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, Уровень:{Level}, Сила:{Power}");
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();

        private int _playersCountInTop;

        public Server() 
        {
            _players = Create();
            _playersCountInTop = 3;
        }

        public void Work()
        {
            const string CommandTopPlayersByLevel = "1";
            const string CommandTopPlayersByPower = "2";
            const string CommandCompleteProgramm = "Exit";

            bool isWork = true;

            while ( isWork )
            {
                ShowAllPlayers();

                Console.WriteLine();
                Console.WriteLine($"{CommandTopPlayersByLevel} - Топ игроков по уровню");
                Console.WriteLine($"{CommandTopPlayersByPower} - Топ игроков по силе");
                Console.WriteLine($"{CommandCompleteProgramm} - Завершить программу");
                string userInput = Console.ReadLine();

                switch ( userInput )
                {
                    case CommandTopPlayersByLevel:
                        SortByLevel();
                        break;

                    case CommandTopPlayersByPower:
                        SortByPower();
                        break;

                    case CommandCompleteProgramm:
                        Console.WriteLine("Программа завершена");
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear(); 
            }
        }

        private void SortByLevel()
        {
            var sortredPlayerByLevel = _players.OrderByDescending(player => player.Level).Take(_playersCountInTop);

            foreach (Player player in sortredPlayerByLevel)
            {
                player.ShowInfo();
            }
        }

        private void SortByPower()
        {
            var sortredPlayerByPower = _players.OrderByDescending(player => player.Power).Take(_playersCountInTop);

            foreach (Player player in sortredPlayerByPower)
            {
                player.ShowInfo();
            }
        }

        private List<Player> Create()
        {
            List<Player> players = new List<Player>() 
            { 
                new Player("Валера", 14, 78),
                new Player("Алеша", 34, 47),
                new Player("Кирил", 75, 63),
                new Player("Дима", 57, 18),
                new Player("Катя", 42, 96),
                new Player("Андрей", 3, 53),
                new Player("Виталя", 79, 94),
                new Player("Виолетта", 56, 37),
                new Player("Света", 81, 25),
                new Player("Нарцис", 34, 64),
            };

            return players;
        }

        private void ShowAllPlayers()
        {
            Console.WriteLine("Список всех игроков");

            foreach (Player player in _players)
            {
                player.ShowInfo();
            }
        }
    }
}
