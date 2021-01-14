using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.Entities;

namespace Asteroids.Extension
{
    public static class Collider
    {
        public static bool IsCollide(this Entity origin, Entity other)
        {
			// определение пересечения окружностей
            return Math.Pow(other.position.X - origin.position.X, 2) + // по теореме пифагора находим расстояние между центрами окружностей
                   Math.Pow(other.position.Y - origin.position.Y, 2) < // и если оно меньше суммы радиусов этих окружностей
                   Math.Pow(other.Radius + origin.Radius, 2);		   // то было столкновние
        }
    }
}
