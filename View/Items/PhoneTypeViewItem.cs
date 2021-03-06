﻿using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class PhoneTypeViewItem
    {
        public PhoneType Wrapper { get; private set; }

        public PhoneTypeViewItem(PhoneType phoneType)
        {
            Wrapper = phoneType;
        }

        public override string ToString()
        {
            return Wrapper.Translate();
        }
    }
}
