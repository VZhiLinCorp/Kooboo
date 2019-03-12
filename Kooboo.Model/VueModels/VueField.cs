﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kooboo.Model.ValidateRules;

namespace Kooboo.Model
{
    public class VueField
    {
        public string Name { get; set; }

        public object Value { get; set; }//type

        public List<Rule> ValidateRules { get; set; } = new List<Rule>();

        public int TabCount { get; set; }

        public string GetDataValue()
        {
            var sb = new StringBuilder();
            var valueStr = Kooboo.Lib.Helper.JsonHelper.Serialize(Value);

            sb.Append(valueStr);
            sb.Append(",");
            //sb.AppendTabs(TabCount, Value);
            return sb.ToString();

            //todo get value string
            sb.AppendTabs(TabCount - 1, "{");
            sb.AppendTabs(TabCount, string.Format("value:\"{0}\",", Value));

            if(ValidateRules.Count>0)
            {
                sb.AppendTabs(TabCount,"validate:{");

                var ruleTabCount = TabCount + 1;
                sb.AppendTabs(ruleTabCount, "rules:[");
                for (var i = 0; i < ValidateRules.Count; i++)
                {

                    var rule = ValidateRules[i];
                    sb.AppendTabs(ruleTabCount+1, rule.GetRule()+",");
                }
                sb.AppendTabs(ruleTabCount, "]");

                sb.AppendTabs(TabCount,"},");
                sb.AppendTabs(TabCount, "isValid:true,");
                sb.AppendTabs(TabCount, "errors: []");
            }
            sb.AppendTabs(TabCount - 1, "{");

            return sb.ToString();
        }
        //private string GetRule()
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendLine("validate:{");

        //    #region rules
        //    sb.AppendLine("rules:[");

        //    for(var i=0;i<ValidateRules.Count;i++)
        //    {
        //        if (i > 0)
        //        {
        //            sb.Append(",");
        //            sb.AppendLine();
        //        }
                    
        //        var rule = ValidateRules[i];
        //        sb.Append(rule.GetRule());
        //    }

        //    sb.AppendLine("]");

        //    #endregion
        //    sb.AppendLine("},");
        //    sb.AppendLine("isValid:true,");
        //    sb.AppendLine("errors: []");

        //    return sb.ToString();
        //}

        
    }
}