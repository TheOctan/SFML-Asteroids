using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.AnimationManager;
using Asteroids.Core;
using Asteroids.Extension;
using SFML.System;

namespace Asteroids.Entities
{
    public class Player : Entity
    {
		public bool Thrust { get; set; }	// отвечает, ускоряется ли ракета
		public bool IsDamage { get; set; }	// отвечает, был игрок ранен
	    private float maxSpeed;

	    public Player()
	    {
			Name = "player";
		    Thrust = false;
		    IsDamage = false;
		    maxSpeed = 15f;
	    }

	    public void Reset()
	    {
			position = new Vector2f(Program.window.Size.X / 2, Program.window.Size.Y / 2);
			acceleration = new Vector2f();
	    }

        public override void Update()
	    {
		    if (Thrust)		// если ускоряется ракета
		    {
                // разложение вектора ускорения по базису при помощи теоремы пифагора
                // то есть находим проекцию на ось Ox при помощи косинуса
                // и проекцию на ось Oy при помощи синуса
                // где угол - это направление ускорения, отклонение от горизонтали
                acceleration.X += (float)Math.Cos(Angle * degToRed) * 0.2f;
                acceleration.Y += (float)Math.Sin(Angle * degToRed) * 0.2f;

			    anim = Factory.GetAnimation(AnimationType.MovedPlayer);		// устанавливаем анимацию полёта
		    }
		    else
		    {
			    acceleration *= 0.99f;      // иначе постепенно замедляем ход
                anim = Factory.GetAnimation(AnimationType.Player);		// устанавливаем анимацию по умалчанию
            }

		    float currentSpeed = acceleration.Length();		// текущая скорость равная длине вектора ускорения

		    if (currentSpeed > maxSpeed)					// если текущая скорость превысила максимальню скорость
		    {
			    acceleration *= maxSpeed / currentSpeed;	// то замедляем ускорение на отношение максимальной скорости к текущей
		    }

		    position += acceleration;               // прибавляем к позиции ускорение

            if (position.X > Program.window.Size.X) position.X = 0;     // если астеройл вылетел за пределы экрана справа, перемещаем в левую границу
            if (position.X < 0) position.X = Program.window.Size.X;     // если астеройл вылетел за пределы экрана слева, перемещаем в правую границу

            if (position.Y > Program.window.Size.Y) position.Y = 0;     // если астеройл вылетел за пределы экрана снизу, перемещаем в верхнюю границу
            if (position.Y < 0) position.Y = Program.window.Size.Y;		// если астеройл вылетел за пределы экрана сверху, перемещаем в нижнюю границу
        }
    }
}
