using Measure.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Services
{
    public interface IMeasureRepository
    {
        Task<bool> CreateAsync(MeasureModel measure);
    }
}
