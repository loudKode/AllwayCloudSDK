# AllwayCloudSDK


`Download:`[https://github.com/loudKode/AllwayCloudSDK/releases](https://github.com/loudKode/AllwayCloudSDK/releases)<br>
`NuGet:`
[![NuGet](https://img.shields.io/nuget/v/DeQmaTech.AllwayCloudSDK.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/DeQmaTech.AllwayCloudSDK)<br>

**Features**
* Assemblies for .NET 4.5.2 and .NET Standard 2.0
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
Dim tkn = Await AllwayCloudSDK.GetToken.GET_LoginUser("USER", "PASS")
```
**set client**
```vb.net
Dim clnt As AllwayCloudSDK.IClient = New AllwayCloudSDK.AClient(tkn.SID, tkn.UID, tkn.PROFILE.AccessKey)
```
**list files/folders**
```vb.net
Dim RSLT = Await clnt.List("tste/here")
For Each itm In RSLT.FilesFoldersList
     DataGridView1.Rows.Add(itm.name, itm.Path, itm.Ext, itm.Type,(itm.size))
Next
```
**create new dir**
```vb.net
Dim RSLT = Await clnt.CreateNewFolder("/tste/002", "gogo")
```
**upload local file with progress tracking**
```vb.net
Dim UploadCancellationToken As New Threading.CancellationTokenSource()
Dim prog_ReportCls As New Progress(Of BackBlazeSDK.ReportStatus)(Sub(ReportClass As BackBlazeSDK.ReportStatus)
                   Label1.Text = String.Format("{0}/{1}",(ReportClass.BytesTransferred),(ReportClass.TotalBytes))
                   ProgressBar1.Value = CInt(ReportClass.ProgressPercentage)
                   Label2.Text = If(CStr(ReportClass.TextStatus)
                   End Sub)
Await clnt.Upload("C:\myimage.Jpg", SentType.FilePath, "myimage.Jpg", "testFolder/newdir", prog_ReportCls, UploadCancellationToken.Token)
```
