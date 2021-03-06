﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LitJson;

namespace Assets.Script.GameStruct.Model
{
    public class Girl
    {
        public string name, cla, club, horoscope;
        public List<string> like, dislike, intro;
        public int height, weight, dayOfBirth, monthOfBirth;

        public Girl(JsonData data)
        {
            name = (string)data["姓名"];
            cla = (string)data["班级"];
            club = (string)data["社团"];
            height = (int)data["身高"];
            weight = (int)data["体重"];
            monthOfBirth = (int)data["生日"][0];
            dayOfBirth = (int)data["生日"][1];
            horoscope = (string)data["星座"];

            like = new List<string>();
            foreach(JsonData da in data["喜欢"])
            {
                like.Add((string)da);
            }

            dislike = new List<string>();
            foreach (JsonData da in data["讨厌"])
            {
                dislike.Add((string)da);
            }

            intro = new List<string>();
            foreach (JsonData da in data["简介"])
            {
                intro.Add((string)da);
            }

        }
    }
}
