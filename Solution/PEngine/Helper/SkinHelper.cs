using Newtonsoft.Json;
using PEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Helper
{
    public class SkinHelper
    {
        private static SkinMetaModel skinMeta;
        public static bool SkinNeedUpdated { get; set; } = true;
        public static SkinMetaModel SkinMeta
        {
            get
            {
                if (SkinNeedUpdated)
                {
                    var skinName = StaticHelper.Meta.Skin;
                    var skinInfoPath = $"Skins/{skinName}/skin.json";

                    if (!File.Exists(skinInfoPath))
                    {
                        return null;
                    }

                    skinMeta = JsonConvert.DeserializeObject<SkinMetaModel>(
                            File.ReadAllText(skinInfoPath)
                        );

                    SkinNeedUpdated = false;
                    cachedHTML.Clear();
                }

                return skinMeta;
            }
        }

        private static Dictionary<string, string> cachedHTML = new Dictionary<string, string>();
        // Dictionary<string, string> should be replaced with custom parameter manager
        public static string LoadHTML(string partName, Dictionary<string, string> parameters = null)
        {
            string skinPartData;

            if (cachedHTML.ContainsKey(partName))
            {
                skinPartData = cachedHTML[partName];
            }
            else
            {
                var skinName = StaticHelper.Meta.Skin;
                var skinPartPath = $"Skins/{skinName}/{partName}.html";

                if (!File.Exists(skinPartPath))
                {
                    return null;
                }

                skinPartData = File.ReadAllText(skinPartPath);
                cachedHTML.Add(partName, skinPartData);
            }

            if (parameters != null)
            {
                foreach (var paramName in parameters)
                {
                    // Performance Optimization is Required at This Place
                    skinPartData = skinPartData.Replace($"%{paramName.Key}%", paramName.Value, StringComparison.Ordinal);
                }
            }

            return skinPartData;
        }
    }
}
