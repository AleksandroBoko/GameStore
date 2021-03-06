﻿using GameStore.Domains.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Services.Services
{
    public interface IStudioService:IService<StudioModel>
    {
        ICollection<StudioInfoTransferModel> GetStudioInfoTransferAll();
        ICollection<StudioRateInfo> GetAllStudiosRatings();
    }
}
