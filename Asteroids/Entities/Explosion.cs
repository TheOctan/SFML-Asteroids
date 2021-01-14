using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Entities
{
    public class Explosion : Entity
    {
	    public Explosion()
	    {
		    Name = "explosion";
	    }

	    public override void Update()
	    {
		    if (anim.IsEnd)		// если закончилась анимация
			    IsLife = false;	// убираем сущность
	    }
    }
}
