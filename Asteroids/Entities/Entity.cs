using Asteroids.AnimationManager;
using SFML.Graphics;
using SFML.System;

namespace Asteroids.Entities
{
    // абстрактный базовый класс для всех сущностей игры,
    // реализует интерфейс, чтобы можно было его отрисовывать

    public abstract class Entity : Drawable
    {
		protected const float degToRed = 0.017453f;		// константа преобразования градуса в радианы

	    public Vector2f position;			// поизиция
	    protected Vector2f acceleration;	// ускорение

	    public float Angle { get; set; }				// угол поворота
	    public float Radius { get; protected set; }		// радиус круглого хитбокса

	    public string Name { get; protected set; }      // имя сущности
        protected Animation anim;						// текущая анимаци

        public bool IsLife { get; set; }    // отвечает жива ли сущность

	    public Entity()
	    {
		    IsLife = true;
	    }

	    public void Settings(Animation anim, Vector2f position, float angle = 10, int radius = 1)
	    {
		    this.anim = anim;
		    this.position = position;
		    this.Angle = angle;
		    this.Radius = radius;
        }       // метод для настроек параметров

        public abstract void Update();      // абстрактный метод обновления логики сущности

        public void Draw(RenderTarget target, RenderStates states)
        {
	        anim.Position = position;		// устанавливае анимированный спрайт в текущую позицию
	        anim.Rotation = Angle + 90;		// устанавливаем угол поворота анимации

			target.Draw(anim);				// отрисовываем в заданную цель анимацию
        }
    }
}
