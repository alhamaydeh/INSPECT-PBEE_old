using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWizard
{


    public class RadioButtonYN : System.Windows.Forms.RadioButton
    {

        public string YesNo
        {

            get
            {

                if (this.Checked)

                    return "1";

                else

                    return "0";

            }

            set
            {

                if (value == "1")

                    this.Checked = true;

                else

                    this.Checked = false;

            }

        }

    }
}
