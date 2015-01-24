using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
public class Instruction {

    [XmlAttribute]
    public string Name = "";
    [XmlAttribute]
    public string Description = "";

}
