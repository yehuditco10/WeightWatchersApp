using Measure.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Services
{
    public interface IMeasureRepository
    {
        Task<int> CreateAsync(MeasureModel measure);
        Task<int> UpdateStatus(int measureId, eStatus status);
    }
}
