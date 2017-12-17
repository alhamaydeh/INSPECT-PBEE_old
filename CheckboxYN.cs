using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWizard
{


    public class CheckboxYN : System.Windows.Forms.CheckBox
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
