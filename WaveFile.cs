using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace SampleWizard
{
    public class WaveFile
    {
        public int Header_Lines { get; set; }
        public int Prefix_Per_Line { get; set; }
        public int Points_Per_Line { get; set; }
        public string File_Name { get; set; }
        public bool isTimeAndValues { get; set; }
        public double deltaT { get; set; }
        public string Text { get; set; }
        public List<double> values = null;
        private double mx;
        public int ID { get; set; }
        public int EQID { get; set; }
        public double Max
        {
            get
            {
                if (values == null)
                    throw new NullReferenceException("Please get values first !");
                if (values.Count == 0)
                    return 0.0;
                return mx;
            }
            set
            {
                mx = value;
            }
        }
        public WaveFile()
        {
            deltaT = 0.02;
        }
        public WaveFile(string FileName) 
        {
            deltaT = 0.02;
            
            this.File_Name = FileName;
            StreamReader rd =null;
            try
            {
               rd = new StreamReader(File.OpenRead(File_Name));
             Text = rd.ReadToEnd();
                rd.Close();

            }
            catch
            {
                try { rd.Close(); }
                catch { }
                throw new ErrorOpeningFileException(FileName);
            }
               
        }

        public void FEMA_Delta(ref double deltaT)
        {

            string text = Text.Replace("\r\n", "\n");
            text = text.Replace(',', ' ');
            List<string> lines = split(text, '\n');
            deltaT = Convert.ToDouble(lines[0]);
        }


        public List<double> FEMA_Modify(double factor)
        {
            for (int i = 0; i < values.Count; i++)
            {
                values[i] *= factor;
            }
            return values;
        }
        public List<double> getValues(ref double deltaT)
        {
            values = new List<double>();
            deltaT = this.deltaT;
            int index = 0;
            string text = Text.Replace("\r\n", "\n");
            text = text.Replace(',', ' ');
            List<string> lines = split(text,'\n');
            index += Header_Lines;
            if (index >= lines.Count) 
                return values;
            for (int i = index; i < lines.Count; i++)
                lines[i] = lines[i].Substring(Prefix_Per_Line);
            double temp=0;
            #region Time And Value file format
            if (isTimeAndValues)
            {
                double t1 = 0, t2 = 0;
                if (lines.Count - index < 2) 
                    throw new TimeValueFormatException("You should have at least 2 points to detect deltaT");
                List<string> parts = split(lines[index],' ');
                if (parts.Count < 2) 
                    throw new TimeValueFormatException("line " + index + " :  you should have at least 2 values :" + lines[index]);
                if (!Double.TryParse(parts[0], out t1)) 
                    throw new TimeValueFormatException("line " + index + " Cant covert " + parts[0] + " to double");
                if (!Double.TryParse(parts[1], out temp)) 
                    throw new TimeValueFormatException("line " + index + " Cant covert " + parts[1] + " to double");
                values.Add(temp);
                index++;
                parts = split(lines[index],' ');
                if (parts.Count < 2) 
                    throw new TimeValueFormatException("line " + index + " :  you should have at least 2 values :" + lines[index]);
                if (!Double.TryParse(parts[0], out t2)) 
                    throw new TimeValueFormatException("line " + index + " Cant covert " + parts[0] + " to double");
                if (!Double.TryParse(parts[1], out temp)) 
                    throw new TimeValueFormatException("line " + index + " Cant covert " + parts[1] + " to double");
                values.Add(temp);
                index++;
                this.deltaT = deltaT = t2 - t1;

                for(;index<lines.Count;index++)
                {

                    parts = split(lines[index],' ');
                    if (parts.Count < 2) 
                        throw new TimeValueFormatException("line " + index + " :  you should have at least 2 values :" + lines[index]);

                    if (!Double.TryParse(parts[1], out temp)) 
                        throw new TimeValueFormatException("line " + index + " Cant covert " + parts[1] + " to double");
                    values.Add(temp);

                }
            }
            #endregion
            #region Value Serise format 
            else
            {
                while(index<lines.Count)
                {
                    List<string> parts = split(lines[index],' ');
                    for(int i=0;i<parts.Count&&i<Points_Per_Line;i++)
                    {
                        if (!Double.TryParse(parts[i], out temp))
                            throw new ValueSeriesFormatException("line " + index + " Cant covert " + parts[i] + " to double");
                        values.Add(temp);
                    }
                    index++;
                }
            }
            #endregion

            #region getMax
            if(values.Count>0)
            {
                mx = Math.Abs(values[0]);
                for(int i=0;i<values.Count;i++)
                {
                    if(Math.Abs(values[i])>mx)
                    {
                        mx = Math.Abs(values[i]);
                    }
                }
            }
            #endregion
            return values;
        }

        public void FEMA_max()
        {
            if (values.Count > 0)
            {
                mx = Math.Abs(values[0]);
                for (int i = 0; i < values.Count; i++)
                {
                    if (Math.Abs(values[i]) > mx)
                    {
                        mx = Math.Abs(values[i]);
                    }
                }
            }
        }
       public bool writeToFile(string fileName,ref int lines)
        {
            if (values == null)
                throw new NullReferenceException("You should get values frist !");
            bool res = true;
            StringBuilder builder = new StringBuilder();
            lines = values.Count; 
           // if (values.Count == 0)
             //   return false;
            StreamWriter writer = new StreamWriter(fileName);
          //  builder.Append(deltaT);
           // builder.Append("\r\n");
          // max = Math.Abs(values[0]);
           for (int i = 0; i < values.Count;i++ )
            {
              //  if (Math.Abs(values[i]) > max)
                //    max = Math.Abs(values[i]);
                builder.Append(values[i]);
                builder.Append("\r\n");
            }
            writer.Write(builder.ToString());
            writer.Flush();
            writer.Close();
            return res; 
        }
        private List<string> split(string str,char ch)
        {
            string[] parts = str.Split(ch);
            List<string> res = new List<string>();
            for (int i = 0; i < parts.Length;i++)
            {
                if(parts[i].Trim()!=String.Empty)
                {
                    res.Add(parts[i]);
                }
            }
            
            return res;
        }
        public override string ToString()
        {
            return Path.GetFileName(File_Name);
        }
    }
    [Serializable]
    public class ErrorOpeningFileException : Exception
    {

        public ErrorOpeningFileException()
            : base()
        {

        }
        public ErrorOpeningFileException(string msg)
            : base(msg)
        {

        }
        public ErrorOpeningFileException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ErrorOpeningFileException(string message, Exception innerException)
            : base(message, innerException) { }

        public ErrorOpeningFileException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected ErrorOpeningFileException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
    [Serializable]
    public class TimeValueFormatException : Exception
    {

        public TimeValueFormatException()
            : base()
        {

        }
        public TimeValueFormatException(string msg)
            : base(msg)
        {

        }
        public TimeValueFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public TimeValueFormatException(string message, Exception innerException)
            : base(message, innerException) { }

        public TimeValueFormatException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected TimeValueFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
    [Serializable]
    public class ValueSeriesFormatException : Exception
    {

        public ValueSeriesFormatException()
            : base()
        {

        }
        public ValueSeriesFormatException(string msg)
            : base(msg)
        {

        }
        public ValueSeriesFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public ValueSeriesFormatException(string message, Exception innerException)
            : base(message, innerException) { }

        public ValueSeriesFormatException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected ValueSeriesFormatException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

    }
}
