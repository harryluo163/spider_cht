using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Xml;

namespace SpiderApp
{
    public class XmlOperation
    {

        public XmlDocument XmlDoc { get; set; }
        private string xmlPath { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public XmlOperation(string path, string Gen)
        {
            XmlDoc = LoadXml(path, Gen);
        }

        /// <summary>
        /// 加载一个Xml文档(使用了file)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private XmlDocument LoadXml(string path, string Gen)
        {
            try
            {
                xmlPath = path;
                XmlDocument xmlDoc = new XmlDocument();
                if (!File.Exists(path))
                {


                    return CreateXml(path, Gen);
                }
                xmlDoc.Load(path);
                return xmlDoc;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        /// <summary>
        /// 创建xml文件
        /// </summary>
        /// <param name="path"></param>
        private XmlDocument CreateXml(string path, string Gen)
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration dec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.AppendChild(dec);
            //添加一个名为Gen的根节点
            XmlElement xml = xmlDoc.CreateElement("", Gen, "");
            xmlDoc.AppendChild(xml);
            xmlDoc.Save(path);
            return xmlDoc;
        }

        /// <summary>
        /// 读取摸一个节点的信息
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="attributeValue">属性值</param>
        /// <param name="attributeName">属性名</param>
        /// <returns>返回的是innerText</returns>
        public string Read(string nodeName, string attributeName, string attributeValue)
        {
            string result = "";
            XmlNodeList xmlNodes = Read(nodeName);
            for (int i = 0; i < xmlNodes.Count; i++)
            {
                XmlElement element = (XmlElement)xmlNodes[i];
                if (element.GetAttribute(attributeName).Equals(attributeValue))
                {
                    result = element.InnerText;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// 通过节点名称读取节点列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private XmlNodeList Read(string nodeName)
        {
            return XmlDoc.GetElementsByTagName(nodeName);
        }


        /// <summary>
        /// 写入节点
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">节点的值</param>
        public void Write(string nodeName, string value)
        {
            Write(nodeName, value, null);
        }


        /// <summary>
        /// 写入节点
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="value">节点的值</param>
        /// <param name="attributes">属性的字典</param>
        public void Write(string nodeName, string value, Dictionary<string, string> attributes)
        {

            XmlNode node = XmlDoc.DocumentElement;//得到根节点
            XmlElement element = XmlDoc.CreateElement(nodeName);
            if (attributes != null)
            {
                foreach (KeyValuePair<string, string> pair in attributes)
                {
                    element.SetAttribute(pair.Key, pair.Value);
                }
            }
            element.InnerText = value;
            try
            {
                if (node != null)
                {
                    node.AppendChild(element);
                }
                else
                {
                    XmlDoc.AppendChild(element);
                }
            }
            catch (Exception e)
            {

            }
            XmlDoc.Save(xmlPath);
        }


        /// <summary>
        /// 删除节点的信息
        /// </summary>
        /// <param name="nodeName">节点的名称</param>
        public void Delete(string nodeName)
        {
            XmlNodeList nodeList = Read(nodeName);
            if (nodeList == null)
            {

                return;
            }
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].ParentNode != null)
                {
                    nodeList[i].ParentNode.RemoveChild(nodeList[i]);
                }
                else
                {
                    XmlDoc.RemoveChild(nodeList[i]);
                }
            }
            XmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 根据属性删除节点信息
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public void Delete(string nodeName, string attributeName, string attributeValue)
        {
            XmlNodeList nodeList = Read(nodeName);
            if (nodeList == null)
            {

                return;
            }
            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlElement element = (XmlElement)nodeList[i];
                if (element.GetAttribute(attributeName).Equals(attributeValue))
                {
                    if (nodeList[i].ParentNode != null)
                    {
                        nodeList[i].ParentNode.RemoveChild(nodeList[i]);
                    }
                    else
                    {
                        XmlDoc.RemoveChild(nodeList[i]);
                    }
                }
            }
            XmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            XmlDoc.Save(xmlPath);
            XmlDoc = null;
            xmlPath = null;
        }
    }
}
