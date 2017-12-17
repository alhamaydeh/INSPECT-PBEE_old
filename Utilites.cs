using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SampleWizard
{
    public class Utilites
    {
        public static void BackUpSkipping(string sourceDirectory, string targetDirectory,string fileToSkip)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            BackUpAllSkipping(diSource, diTarget, fileToSkip);
        }

        public static void BackUpAllSkipping(DirectoryInfo source, DirectoryInfo target,string fileToSkip)
        {
            // Check if the target directory exists; if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
              //  Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                if (fi.Name.Contains(fileToSkip))
                    continue;
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                BackUpAllSkipping(diSourceSubDir, nextTargetSubDir, fileToSkip);
            }
        }
        public static bool FileInUse(string path)
        {
            try
            {
                //Just opening the file as open/create
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    //If required we can check for read/write by using fs.CanRead or fs.CanWrite
                }
                return false;
            }
            catch (IOException ex)
            {
                //check if message is for a File IO
                string __message = ex.Message.ToString();
                if (__message.Contains("The process cannot access the file"))
                    return true;
                else
                    throw;
            }
        }
        public static String[] RemoveIndices(String[] IndicesArray, int RemoveAt)
        {
            String[] newIndicesArray = new String[IndicesArray.Length - 1];

            int i = 0;
            int j = 0;
            while (i < IndicesArray.Length)
            {
                if (i != RemoveAt)
                {
                    newIndicesArray[j] = IndicesArray[i];
                    j++;
                }

                i++;
            }

            return newIndicesArray;
        }
        public static void DeepSerialize<T>(T obj, string fileName)
        {
            //            MemoryStream memoryStream = new MemoryStream();
            FileStream str = new FileStream(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(str, obj);
            str.Close();
        }
        public static T DeepDeserialize<T>(string fileName)
        {
            //            MemoryStream memoryStream = new MemoryStream();
            FileStream str = new FileStream(fileName, FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T returnValue = (T)binaryFormatter.Deserialize(str);
            str.Close();
            return returnValue;
        }  
    }
}
