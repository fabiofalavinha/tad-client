using System.Collections.Generic;
using System.IO;

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
