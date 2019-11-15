﻿using PEngine.Models;
using PEngine.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Helper
{
    public static class StaticHelper
    {
        private static BlogMetaModel meta;
        public static bool MetaNeedUpdated { get; set; } = true;
        public static BlogMetaModel Meta 
        {
            get
            {
                if (MetaNeedUpdated &&
                    BlogContextFactory.Context.Metadata.Any())
                {
                    meta = BlogContextFactory.Context.Metadata.First();
                    MetaNeedUpdated = false;
                }

                return meta;
            }
        }
    }
}
