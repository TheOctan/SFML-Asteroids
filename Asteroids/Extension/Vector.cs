using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Asteroids.Extension
{
    public static class Vector
    {
	    public static float Length(this Vector2f v)
	    {
		    return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
	    }	   // расширяющий метод для нахождения длины вектора
    }
}
