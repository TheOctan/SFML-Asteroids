using SFML.System;

namespace Asteroids.Entities
{
    public class Asteroid : Entity
    {
        public Asteroid()
        {
            acceleration = new Vector2f(		// генерируем случайным образом ускорение
                Program.rand.Next(-4, 4),		// по X
                Program.rand.Next(-4, 4)		// по Y
                );

	        Name = "asteroid";
        }

        public override void Update()
        {
	        position += acceleration;			// прибавляем к позиции ускорение

			if (position.X > Program.window.Size.X) position.X = 0;		// если астеройл вылетел за пределы экрана справа, перемещаем в левую границу
	        if (position.X < 0) position.X = Program.window.Size.X;		// если астеройл вылетел за пределы экрана слева, перемещаем в правую границу

	        if (position.Y > Program.window.Size.Y) position.Y = 0;     // если астеройл вылетел за пределы экрана снизу, перемещаем в верхнюю границу
            if (position.Y < 0) position.Y = Program.window.Size.Y;		// если астеройл вылетел за пределы экрана сверху, перемещаем в нижнюю границу
        }
    }
}
