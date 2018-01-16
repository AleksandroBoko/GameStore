using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.EntityModels
{
    public class Producer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
