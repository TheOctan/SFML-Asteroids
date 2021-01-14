using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Entities;
using Asteroids.Extension;
using SFML.Graphics;
using SFML.Window;

namespace Asteroids.Core
{
    public class Game
    {
        private Sprite background;         // спрайт фона

        private List<Entity> entities;      // список всех сущностей
        private Player player;				// ссылка на игрока

        public Game()
        {
            background = new Sprite(Factory.backGround);    // ставим текстуру на задний фон
            entities = new List<Entity>();

            player = Factory.GetDefaultEntity(EntityType.Player) as Player;		// получаем игрока из фабрики и приводим к типу Player
            entities.Add(player);      // добавляем в список сущностей игрока

            for (int i = 0; i < 15; i++)
            {
                entities.Add(Factory.GetDefaultEntity(EntityType.Asteroid));    // добавляем в список сущностей 15 астеройдов
            }

            Program.window.KeyPressed += OnWindowKeyPressed;    // подпиываемся на обытие нажатия кнопки
        }

        private void OnWindowKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Space)   // если был нажат пробел
            {
                entities.Insert(0, Factory.GetEntity(EntityType.Bullet, player.position, player.Angle, 10));	// добавляем в список сущностей пулю в координатах игрока в том же направлении
            }
        }

        public void Update()
        {
            // управление игроком
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) player.Angle += 3;	// если нажата клавиша вправо -> поворачиваем по часовой стрелки корабль
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) player.Angle -= 3;    // если нажата клавиша влево <- поворачиваем против часовой стрелки корабль
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) player.Thrust = true;   // если нажата клавиша вверх, то газуем
            else player.Thrust = false;                                         // иначе нет


            // просчёт столкновений
            for(int i = 0; i < entities.Count; i++)
            {
                for (int j = 0; j < entities.Count; j++)
                {
                    // берём ссылки на сущности
                    var a = entities[i];
	                var b = entities[j];

                    if (a.IsCollide(b))         // если столкнулись два объекта
                    {
                        if (a.Name == "asteroid" && b.Name == "bullet")	// при этом астеройд и пуля
                        {
                            // уничтожаем объекты
                            a.IsLife = false;
                            b.IsLife = false;

                            entities.Add(Factory.GetEntity(EntityType.Explosion, a.position));  // добавляем в этом месте взрыв

                            for (int k = 0; k < 2; k++)
                            {
                                if (a.Radius == 15) continue;   // если это маленький астеройд, то пропускаем шаг

                                entities.Add(Factory.GetEntity(EntityType.SmallAsteroid, a.position, Program.rand.Next(0, 360), 15));   // добавляем осколок астеройда (повторяется дважды)
                            }
                        }
                        else if (a.Name == "player" && b.Name == "asteroid")	// при этом игрок и астеройд
                        {
                            b.IsLife = false;   // уничтожаем астреройд

                            entities.Add(Factory.GetEntity(EntityType.ShipsExplosion, a.position)); // добавляем взрыв корабля
                            player.Reset();				// срасываем игрока
                        }
                    }
                }
            }

            // спауни новые астеройды
            if (Program.rand.Next(0, 150) == 0) // шанс 1 к 150
            {
                entities.Add(Factory.GetDefaultEntity(EntityType.Asteroid));    // добавляем новый астеройд
            }

            for (int i = 0; i < entities.Count;)
            {
                Entity e = entities[i];     // берем ссылку на сущность
                e.Update();                 // обновляем её

	            if (!e.IsLife)				// если сущность не жива, то есть сдохла
		            entities.RemoveAt(i);	// то удаляем данную сущность по индексу
	            else i++;					// иначе двигаемся дальше
            }
        }

        public void Render(RenderTarget target)
        {
			target.Draw(background);			// отрисовываем задний фон

            foreach (var entity in entities)    // беребираем все сущности
            {
                target.Draw(entity);            // отрисовываем в заданную цель
            }
        }

    }
}
