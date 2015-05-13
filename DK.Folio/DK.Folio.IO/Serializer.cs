using DK.Folio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DK.Folio.IO
{
    /// <summary>
    /// Serialize and deserialize portfolios
    /// </summary>
    public static class Serializer
    {

        /// <summary>
        /// See: https://msdn.microsoft.com/en-us/library/3z3z5s6h%28v=vs.110%29.aspx for serialzie/dersialize details
        /// </summary>

        ///
        public static void Serialize(ApplicationData data, string filePath)
        {
            // Each overridden field, property, or type requires 
            // an XmlAttributes instance.
            XmlAttributes attrs = new XmlAttributes();

            // Creates an XmlElementAttribute instance to override the 
            // field that returns Book objects. The overridden field
            // returns Expanded objects instead.
            XmlElementAttribute attr = new XmlElementAttribute();
            attr.ElementName = "CashTransaction";
            attr.Type = typeof(CashTransaction);

            // Adds the element to the collection of elements.
            attrs.XmlElements.Add(attr);

            // Creates the XmlAttributeOverrides instance.
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();

            // Adds the type of the class that contains the overridden 
            // member, as well as the XmlAttributes instance to override it 
            // with, to the XmlAttributeOverrides.
            attrOverrides.Add(typeof(Account), "Transactions", attrs);

            Type[] types = new Type[]{ typeof(Transaction), typeof(CashTransaction) };

            // Creates the XmlSerializer using the XmlAttributeOverrides.
            XmlSerializer s = new XmlSerializer(typeof(ApplicationData), attrOverrides, types, null, null);            

            // Writing the file requires a TextWriter instance.
            TextWriter writer = new StreamWriter(filePath);

            // Serializes the object.
            s.Serialize(writer, data);
            writer.Close();
        }

        public static void Deserialize()
        {
            
        }

    }
}
