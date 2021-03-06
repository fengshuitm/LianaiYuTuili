﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.GameStruct.Model
{
    public class BacklogText
    {
        public string charaName;
        public string mainContent;
        public string voicePath;

        public BacklogText(string cName, string mContent, string vFile = "")
        {
            this.charaName = cName;
            this.mainContent = mContent;
            this.voicePath = vFile;
        }

        public override string ToString()
        {
            return "Name: " + charaName + "\nContent: " + mainContent + "\nVoicePath: " + voicePath; 
        }
    }
}
