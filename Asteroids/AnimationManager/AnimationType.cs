using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.AnimationManager
{
	public enum AnimationType
    {
		Explosion,              // взрыв
        ShipsExplosion,         // взрыв корабля
        Rock,                   // камень
        SmallRock,              // маленький камень
        Bullet,                 // пуля
        Player,                 // игрок
		MovedPlayer				// двигающийся игрок
    }
}
