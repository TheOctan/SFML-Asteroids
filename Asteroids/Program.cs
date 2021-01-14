using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Core;
using SFML.Graphics;
using SFML.Window;

namespace Asteroids
{
    class Program
    {
        public static Random rand;
	    public static RenderWindow window;
	    private static Game game;

        static void Main(string[] args)
        {
            rand = new Random();

			window = new RenderWindow(new VideoMode(1200, 800), "Asteroids", Styles.Close);		// создаём окно размером 1200x800 с названием Asteroids
            window.SetMouseCursorVisible(false);                                                // делаем невидиомой курсор мыши
	        window.SetKeyRepeatEnabled(false);													// отключаем залипание клавиш
			window.SetFramerateLimit(60);														// устанавливаем ограничение в 60 FPS

            Image icon = new Image("images/Asteroids.png");         // загружаем
            window.SetIcon(icon.Size.X, icon.Size.Y, icon.Pixels);	// и устанавливаем иконку на окно

            window.Closed += OnWindowClosed;                        // подписываемся на событие закрития окна

            game = new Game();

	        while (window.IsOpen)                                   // бесеконечный цикл пока открыто окно
            {
                window.DispatchEvents();            // обрабатываем события окна

                game.Update();						// обновляем игровую логику

                window.Clear();                     // очищаем экран
                game.Render(window);				// рендерим игру
                window.Display();					// и отображаем на экран
            }
        }

        private static void OnWindowClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
