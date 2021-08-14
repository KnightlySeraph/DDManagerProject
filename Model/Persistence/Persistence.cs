using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Microsoft.Win32.SafeHandles;
using System.Runtime.Serialization;
using Microsoft.Win32;

namespace DDManagerSolution.Model
{
    static class Persistence
    {
        public static void SaveEncounter(Encounter encounter)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Encounter Files (*.ddenc)|*.ddenc";
            sfd.DefaultExt = ".ddenc";

            bool? result;

            result = sfd.ShowDialog();

            if (!result.Value)
            {
                return;
            }            

            string path = sfd.FileName;

            using (XmlWriter writer = XmlWriter.Create(path, new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = Encoding.UTF8,
                CloseOutput = true
            }))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Encounter));
                serializer.WriteObject(writer, encounter);
            }           
            
        }

        public static Encounter LoadEncounter()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Encounter Files (*.ddenc)|*.ddenc";

            bool? result = ofd.ShowDialog();

            if (!result.Value)
                return null;

            string path = ofd.FileName;

            Encounter enc = null;

            using (XmlReader reader = XmlReader.Create(path))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Encounter));
                enc = (Encounter)serializer.ReadObject(reader);
            }

            return enc;
        }
    }
}
