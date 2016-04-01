﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GameData
{
    public interface XMLFile
    {
    }
    public class GameData
    {
        public int id;

        protected static Dictionary<int, T> GetDataMap<T>()
        {
            Dictionary<int, T> _dataMap;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var type = typeof(T);
            var fileNameField = type.GetField("fileName");
            ALog.logWarning("Load File:" + fileNameField.Name);
            if (fileNameField != null)
            {
                var fileName = fileNameField.GetValue(null) as String;
                var result = GameDataLoader.Instance.FormatData(fileName, typeof(Dictionary<int, T>), type);
                ALog.logWarning("Load File:" + fileName);
                _dataMap = result as Dictionary<int, T>;
            }
            else
            {
                _dataMap = new Dictionary<int, T>();
            }
            sw.Stop();
            ALog.info(String.Concat(type, " time: ", sw.ElapsedMilliseconds));
            return _dataMap;
        }
    }

    public abstract class GameData<T> : GameData where T : GameData<T>
    {
        public static implicit operator bool(GameData<T> c)
        {
            return c != null;
        }

        private static Dictionary<int, T> m_dataMap;

        public static Dictionary<int, T> dataMap
        {
            get
            {
                if (m_dataMap == null)
                    m_dataMap = GetDataMap<T>();
                return m_dataMap;
            }
            set { m_dataMap = value; }
        }
        public static T Get(int id)
        {
            if (dataMap != null && dataMap.ContainsKey(id))
                return dataMap[id];
            else
            {
                var fileNameField = typeof(T).GetField("fileName");
                if (fileNameField != null)
                {
                    var fileName = fileNameField.GetValue(null) as String;
                    string error = string.Format("Config=> 文件名：" + fileName + " error id: " + id.ToString());
                    ALog.logWarning(error);
                }
            }
            return null;
        }
        public static T Get(uint id)
        {
            return Get((int)id);
        }
        private static string getFileName(string filename)
        {
            return Setting.ResourcePath + Setting.CONFIG_SUB_FOLDER + filename; ;
        }
        public static List<T> dataList
        {
            get
            {
                if (mDataList == null)
                {
                    mDataList = new List<T>();
                    foreach (var d in dataMap)
                        mDataList.Add(d.Value);
                    mDataList.Sort(SortByID);
                }
                return mDataList;
            }
        }
        public static int SortByID(T a, T b)
        {
            if (a.id > b.id)
                return 1;
            if (a.id == b.id)
                return 0;
            if (a.id < b.id)
                return -1;
            return 0;
        }

        static List<T> mDataList;

        public static void SaveGameData()
        {
            var fileNameField = typeof(T).GetField("fileName");
            if (fileNameField != null)
            {
                var fileName = fileNameField.GetValue(null) as String;
                var fullName = getFileName(fileName);
                AResource.SaveGameData(dataMap, fullName);
                ALog.info("保存成功=>" + Fun.EnsureFileNameWithExtenision_XML(fileName));
            }
        }
    }
}
