﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kooboo.Data.Context;

namespace Kooboo.Model.Components.Table
{
    public interface IAction
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Color { get; set; }
        ButtonActionType ActionType { get; }

        RenderContext Context { get; set; }
        bool IsValid();
        VueField GetField();
        void SetData(List<Attribute> attributes);
    }
}
