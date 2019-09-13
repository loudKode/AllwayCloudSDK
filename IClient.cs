using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AllwayCloudSDK.JSON;

namespace AllwayCloudSDK
{
	public interface IClient
	{
		Task<JSON_PROFILE> UserInfo();

		Task<JSON_List> List(string Path, AwCutilities.SortByEnum? SortBy = 0);

		Task<JSON_CreateNewFolder> CreateNewFolder(string DestinationFolder, string FolderName);

		Task Upload(object FilePath, AClient.SentType TheFileType, string FileName, string DestinationFolder, IProgress<ReportStatus> ReportCls = null, CancellationToken token = default(CancellationToken));

		Task<JSON_DeleteFile> DeleteFile(string DestinationFile);

		Task<JSON_DeleteFile> DeleteFolder(string DestinationFolder);

		Task<JSON_GetDownloadUrl> GetDownloadUrl(string DestinationFile);

		Task<Dictionary<string, string>> GetMultipleDownloadUrl(List<string> DestinationFiles);

		Task DownloadFile(string FileUrl, string FileSaveDir, string FileName, IProgress<ReportStatus> ReportCls = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<Stream> DownloadFileAsStream(string FileFullPath, IProgress<ReportStatus> ReportCls = null, int TimeOut = 60, CancellationToken token = default(CancellationToken));

		Task<JSON_Rename> RenameFile(string DestinationFile, string NewName);

		Task<JSON_Rename> RenameFolder(string DestinationFolder, string NewName);
	}
}
