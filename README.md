## AllwayCloudSDK ##

`Download:`[https://github.com/loudKode/AllwayCloudSDK/releases](https://github.com/loudKode/AllwayCloudSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.AllwayCloudSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.AllwayCloudSDK)<br>


**Features**

* Assemblies for .NET 4.5.2 and .NET Standard 2.0 and .NET Core 2.1
* Just one external reference (Newtonsoft.Json)
* Easy installation using NuGet
* Upload/Download tracking support
* Proxy Support
* Upload/Download cancellation support

# Functions:
* UserInfo
* List
* CreateNewFolder
* Upload
* DeleteFile
* DeleteFolder
* GetDownloadUrl
* GetMultipleDownloadUrl
* DownloadFile
* DownloadFileAsStream
* RenameFile
* RenameFolder


# Example:
**get token**
```vb.net

    Async Sub GetToken()
        Dim tkn = Await AllwayCloudSDK.GetToken.Login("user", "pass")
        DataGridView1.Rows.Add(tkn.PROFILE.DisplayName, tkn.PROFILE.TotalStorage, tkn.PROFILE.UsedStorage, tkn.SID, tkn.UID)
    End Sub
```
```vb.net
    Sub SetClient()
        Dim MyClient As AllwayCloudSDK.IClient = New AllwayCloudSDK.AClient("tkn.SID", "tkn.UID", "access token")
    End Sub
```
```vb.net
    Sub SetClientWithOptions()
        Dim Optians As New AllwayCloudSDK.ConnectionSettings With {.CloseConnection = True, .TimeOut = TimeSpan.FromMinutes(30), .Proxy = New AllwayCloudSDK.ProxyConfig With {.ProxyIP = "172.0.0.0", .ProxyPort = 80, .ProxyUsername = "myname", .ProxyPassword = "myPass", .SetProxy = True}}
        Dim MyClient As AllwayCloudSDK.IClient = New AllwayCloudSDK.AClient("tkn.SID", "tkn.UID", "access token", Optians)
    End Sub
```
```vb.net
    Async Sub ListMyFilesAndFolders()
        Dim result = Await MyClient.List("path", SortByEnum.dir)
        For Each vid In result.FilesList
            DataGridView1.Rows.Add(vid.name, vid.Path, vid.size, vid.ModifiedDate)
        Next
        For Each vid In result.FoldersList
            DataGridView1.Rows.Add(vid.name, vid.Path, vid.size, vid.ModifiedDate)
        Next
    End Sub
```
```vb.net
    Async Sub DeleteFileOrFolder()
        Dim result = Await MyClient.DeleteFile("file path")
        Dim resultD = Await MyClient.DeleteFolder("folder path")
    End Sub
```
```vb.net
    Async Sub CreateNewFolder()
        Dim result = Await MyClient.CreateNewFolder("parent folder path", "new folder name")
    End Sub
```
```vb.net
    Async Sub RenameFile()
        Dim result = Await MyClient.RenameFile("file path", "new file name")
        Dim resultD = Await MyClient.RenameFolder("folder path", "new folder name")
    End Sub
```
```vb.net
    Async Sub Upload_Local_WithProgressTracking()
        Dim UploadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of AllwayCloudSDK.ReportStatus)(Sub(ReportClass As AllwayCloudSDK.ReportStatus)
                                                                           Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                           ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                           Label2.Text = CStr(ReportClass.TextStatus)
                                                                       End Sub)
        Await MyClient.Upload("J:\DB\myvideo.mp4", SentType.FilePath, "myvideo.mp4", "tste/here", _ReportCls, UploadCancellationToken.Token)
    End Sub
```
```vb.net
    Async Sub Download_File_WithProgressTracking()
        Dim DownloadCancellationToken As New Threading.CancellationTokenSource()
        Dim _ReportCls As New Progress(Of AllwayCloudSDK.ReportStatus)(Sub(ReportClass As AllwayCloudSDK.ReportStatus)
                                                                           Label1.Text = String.Format("{0}/{1}", (ReportClass.BytesTransferred), (ReportClass.TotalBytes))
                                                                           ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                                                                           Label2.Text = CStr(ReportClass.TextStatus)
                                                                       End Sub)
        Dim FUrl = Await MyClient.GetDownloadUrl("file path")
        Await MyClient.DownloadFile(FUrl.DOWNLOAD_LINK, "J:\DB\", "myvideo.mp4", _ReportCls, DownloadCancellationToken.Token)
    End Sub
```
