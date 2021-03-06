﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domains.Domain
{
    public class GenreInfoTransferModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameRateTransferModel> Games { get; set; }
    }
}
