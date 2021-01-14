using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Asteroids.AnimationManager
{
    // наследуется от класса трансофрмации, чтобы его можно было трансформировать
    // реализует интерфейс, который позволяет отрисовывать данный класс
    public class Animation : Transformable, Drawable       
    {
        private float frame;                // текущий кадр
        private float speed;                // скорость анимации
        private Sprite sprite;              // спрайт

        private List<IntRect> frames;       // список кадров

		public bool IsEnd => frame + speed >= frames.Count;     // отвечает конец ли анимации

        public Animation()
        {

        }
        public Animation(Texture texture, IntRect rect, int count, float speed)
        {
            frame = 0f;
            this.speed = speed;
			frames = new List<IntRect>();

            for (int i = 0; i < count; i++)
            {
                frames.Add(new IntRect(rect.Left + i * rect.Width, rect.Top, rect.Width, rect.Height));   // добавляем кадры со смещение равным ширине кадра width
            }

	        sprite = new Sprite()                               // создаём спрайт
            {
		        Texture = texture,                              // с заданной текстурой
                Origin = new Vector2f(rect.Width / 2, rect.Height / 2),   // с центром равной половине ширины и половине высоты
                TextureRect = frames[0]                         // устанавливаем первый кадр
            };
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
	        states.Transform *= Transform;		// перемножаем внешнуюю трансформацию на текущую трансформацию

	        frame += speed;     // сдвигаем текущий кадр

	        if (frame >= frames.Count)  // если текущий кадр перевалил общее колисество кадров
		        frame -= frames.Count;  // откатываем назад на общее количество кадров

	        if (frames.Count > 0)       // если количество кадров не равно нулю, то есть больше чем ноль
		        sprite.TextureRect = frames[(int) frame];   // устанавливаем текущий кадр для спрайта (с округлением номера текущего кадра к целому числу)

            target.Draw(sprite, states);        // отрисовываем в заданную цель спрайт и передаё параметры состояние трансформации
        }
    }
}
