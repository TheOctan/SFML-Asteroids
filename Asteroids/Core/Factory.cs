using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asteroids.AnimationManager;
using Asteroids.Entities;
using SFML.Graphics;
using SFML.System;

namespace Asteroids.Core
{
	// фабрика ресурсов
    public static class Factory
    {
		// подгружаем текстуры
	    public static Texture player			= new Texture("images/spaceship.png");
	    public static Texture backGround		= new Texture("images/background5.jpg");
	    public static Texture explosion			= new Texture("images/explosions/type_C.png");
		public static Texture shipsExplosion	= new Texture("images/explosions/type_B.png");
	    public static Texture rock				= new Texture("images/rock.png");
	    public static Texture smallRock			= new Texture("images/rock_small.png");
	    public static Texture bullet			= new Texture("images/fire_blue.png");

	    public static Animation GetAnimation(AnimationType type)
	    {
		    switch (type)
		    {
                case AnimationType.Explosion:		return new Animation(explosion, new IntRect(0, 0, 256, 256), 48, 0.5f);
                case AnimationType.ShipsExplosion:	return new Animation(shipsExplosion, new IntRect(0, 0, 192, 192), 64, 0.9f);
                case AnimationType.Rock:			return new Animation(rock, new IntRect(0, 0, 64, 64), 16, 0.2f);
                case AnimationType.SmallRock:		return new Animation(smallRock, new IntRect(0, 0, 64, 64), 16, 0.2f);
                case AnimationType.Bullet:			return new Animation(bullet, new IntRect(0, 0, 32, 64), 16, 0.8f);
                case AnimationType.Player:			return new Animation(player, new IntRect(40, 0, 40, 40), 1, 0);
                case AnimationType.MovedPlayer:		return new Animation(player, new IntRect(40, 40, 40, 40), 1, 0);

                default: return null;
            }
        }    // заготавливает анимацию по указанному типу

        public static Entity GetEntity(EntityType type, Vector2f position, float angle = 10, int radius = 1)
	    {
		    switch (type)
		    {
                case EntityType.Asteroid:	// большой астеройд
					Asteroid asteroid = new Asteroid();															// содаём сущность
					asteroid.Settings(GetAnimation(AnimationType.Rock), position, angle, radius);		// проводим настройки анимации, положения и так далее для всех сущностей
	                return asteroid;																			// и возвращаем

                case EntityType.SmallAsteroid:	// маленький астеройд
                    Asteroid smllAsteroid = new Asteroid();
                    smllAsteroid.Settings(GetAnimation(AnimationType.SmallRock), position, angle, radius);
                    return smllAsteroid;

                case EntityType.Bullet:		// пуля
					Bullet bullet = new Bullet();
					bullet.Settings(GetAnimation(AnimationType.Bullet), position, angle, radius);
	                return bullet;

                case EntityType.Explosion:	// взрыв
	                Explosion explosion = new Explosion();
					explosion.Settings(GetAnimation(AnimationType.Explosion), position, angle, radius);
	                return explosion;

                case EntityType.ShipsExplosion:  // взрыв корабля
                    Explosion shipsExplosion = new Explosion();
                    shipsExplosion.Settings(GetAnimation(AnimationType.Explosion), position, angle, radius);
                    return shipsExplosion;

                case EntityType.Player:		// игрок
					Player player = new Player();
					player.Settings(GetAnimation(AnimationType.Player), position, angle, radius);
	                return player;

				default: return null;
		    }
        }	// заготавливает сущность по указанному типу с инициализацией параметров

	    public static Entity GetDefaultEntity(EntityType type)
	    {
		    switch (type)
		    {
                case EntityType.Asteroid:   // большой астеройд
                    return GetEntity(
	                type,
	                new Vector2f(Program.rand.Next(0, (int)Program.window.Size.X), Program.rand.Next(0, (int)Program.window.Size.Y)), 
	                0, 20);

                case EntityType.SmallAsteroid:	// маленький астеройд
                    return GetEntity(
                    type,
                    new Vector2f(Program.rand.Next(0, (int)Program.window.Size.X), Program.rand.Next(0, (int)Program.window.Size.Y)),
                    0, 20);

                case EntityType.Bullet:			return GetEntity(type, new Vector2f(200, 200), 0, 10);		// пуля
                case EntityType.Explosion:		return GetEntity(type, new Vector2f(200, 200));				// взрыв
                case EntityType.ShipsExplosion: return GetEntity(type, new Vector2f(200, 200));				// взрыв корабля
                case EntityType.Player:			return GetEntity(type, new Vector2f(200, 200), 0, 20);		// игрок

				default: return null;
            }


        }	// заготавливает сущность по указанному типу c параметрами по умолчанию
    }
}
