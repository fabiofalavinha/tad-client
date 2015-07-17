﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface ICollaboratorBirthDaysView : IControlView
    {
        void SetBirthdayList(IList<BirthdayList> list);
    }
}