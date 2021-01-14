using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Entities
{
    public class Bullet : Entity
    {
	    public Bullet()
	    {
		    Name = "bullet";
	    }

	    public override void Update()
	    {
            // разложение вектора ускорения по базису при помощи теоремы пифагора
		    // то есть находим проекцию на ось Ox при помощи косинуса
			// и проекцию на ось Oy при помощи синуса
			// где угол - это направление ускорения, отклонение от горизонтали
            acceleration.X = (float)Math.Cos(Angle * degToRed) * 6f;
		    acceleration.Y = (float)Math.Sin(Angle * degToRed) * 6f;

		    position += acceleration;		// прибавляем к позиции ускорение

		    if (position.X > Program.window.Size.X ||
		        position.X < 0 ||
		        position.Y > Program.window.Size.Y ||
		        position.Y < 0
		    )	// если пуля покинула пределы экрана
			    IsLife = false;		// то уничтожаем её
	    }
    }
}
