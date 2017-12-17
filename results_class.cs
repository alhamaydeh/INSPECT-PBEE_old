using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    [Serializable]
    public class results_class
    {
        public decimal story_shear;
        public decimal drift_ratio;
        public decimal story_drift;
        public decimal displacment;
        public decimal velocity;
        public decimal acceleration;
        public decimal story_velocity_drift;
        public decimal damage_index;
        public decimal scale_factor;
        public bool not_failure;
    }
}
