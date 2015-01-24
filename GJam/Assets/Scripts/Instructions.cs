using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot]
public class Instructions {

    [XmlAttribute]
    public string ID = "";
    [XmlElement]
    public List<Instruction> AllInstructions = new List<Instruction>();



}
