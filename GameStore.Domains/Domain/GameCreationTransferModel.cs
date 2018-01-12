using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domains.Domain
{
    public class GameCreationTransferModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }
        public Guid GenreId { get; set; }
        public Guid StudioId { get; set; }
        public ICollection<Guid> Producers { get; set; }
    }
}
