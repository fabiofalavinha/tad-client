﻿namespace TadManagementTool.Presenter
{
    public interface IEventEnrollmentPresenter : IPresenter
    {
        void OnCancel();
        void OnOk();
        void OnRemoveEvent();
        void OnSelectEventBackColor();
        void OnSelectEventFontColor();
    }
}
