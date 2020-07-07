using Measure.Services;
using Measure.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Data
{
    public class MeasureRepository : IMeasureRepository
    {
        public Task<bool> CreateAsync(MeasureModel measure)
        {
            throw new NotImplementedException();
        }
    }
}
