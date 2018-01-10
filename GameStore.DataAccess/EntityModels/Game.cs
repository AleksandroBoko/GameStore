using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DataAccess.EntityModels
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Guid GenreId { get; set; }
        public virtual Genre GameGenre { get; set; }

        public Guid StudioId { get; set; }
        public virtual Studio GameStudio { get; set; }

        public int Rate { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Producer> Producers { get; set; }
    }
}
