using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OffersParser

{
    // Класс, отвечающий за парсинг xml
    public static class XmlParser
    {
        // Список для хранения id предложений для последующего вывода на экран
        public static List<string> Ids = new List<string>();
        // Список для хранения деталей предложений
        public static List<string> jsones = new List<string>();
        // Список с объектными моделями предложений
        public static List<Offer> offers = new List<Offer>();
        // В данном методе задаётся кодировка для указанного xml-документа, загружается сам файл и начинается его парсинг
        public static void Parse()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("https://yastatic.net/market-export/_/partner/help/YML.xml");
            XmlElement xRoot = xmlDocument.DocumentElement;
            Fill(xRoot);
        }
        // Данный метод отвечает за обход узлов xml-документа, поиск нужного и добавления необходимых данных в коллекции
        public static void Fill(XmlElement xRoot)
        {
            foreach (XmlNode xmlNode in xRoot)
            {
                foreach (XmlNode childnode in xmlNode.ChildNodes)
                {
                    if (childnode.Name == "offers")
                    {
                        foreach (XmlNode childnode2 in childnode.ChildNodes)
                        {
                            Offer offer = new Offer();
                            XmlNode attr = childnode2.Attributes.GetNamedItem("id");
                            if (attr != null)
                            {
                                offer.id = attr.Value;
                                offer.json = JsonConvert.SerializeXmlNode(childnode2);
                                Ids.Add(offer.id);
                                jsones.Add(offer.json);
                                offers.Add(offer);
                            }
                        }
                    }
                }
            }
        }
    }
}