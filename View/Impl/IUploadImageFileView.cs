using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TadManagementTool.View.Impl
{
    public interface IUploadImageFileView : IDialogView
    {
        IList<FileInfo> SelectImageFiles();
        IList<FileInfo> GetSelectedImageFiles();
        void RemoveSelectedImageFile(FileInfo imageFileInfo);
        void SetSelectedImageFiles(IList<FileInfo> imageFiles);
    }
}
