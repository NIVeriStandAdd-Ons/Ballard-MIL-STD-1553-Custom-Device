using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using Microsoft.Win32;

public partial class CoreType
    {
    //Function used to check XML File aginst XSD Schema.
    static public CoreType ValidateAgainstXMLSchema(string XMLFilepath, string SchemaXMLFilepath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, SchemaXMLFilepath);
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(XMLFilepath, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                  document.Validate(null);

                reader.Close();

                return (CoreType)null;

            }
            catch (XmlSchemaValidationException ex)
            {
            throw new ApplicationException("\n\nError: 5000, Message: Ballard Arinc-429 Custom-Device, Reading XML.\n\nLine Number: #" + ex.LineNumber + ", Line Position: #"+ex.LinePosition +".\n\nMessage: "+ex.Message);
            }
        }
    //Function used to perform actual XML Deserialization.
    static public CoreType DeserializeXML(string XMLFilepath)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CoreType));
            Stream reader1 = new FileStream(XMLFilepath, FileMode.Open);
            CoreType readData = (CoreType)serializer.Deserialize(reader1);
            reader1.Close();
            return readData;

        }
        catch (Exception ex)
        {
            throw new ApplicationException("\n\nError: 5001, Message: Ballard Arinc-429 Custom-Device, XML Deserialization: " + ex.Message);
        }
    }
}
