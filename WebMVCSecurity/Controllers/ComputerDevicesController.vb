Imports System.Data.Entity
Imports System.IO
Imports System.Net
Imports ClosedXML.Excel
Imports Microsoft.AspNet.Identity

Namespace Controllers
    <Authorize(Roles:="Admin")>
    Public Class ComputerDevicesController
        Inherits System.Web.Mvc.Controller

        Private db As New DatabaseContext

        ' GET: ComputerDevices
        Function Index() As ActionResult
            Dim searchString As String = Session("searchName")
            Dim includeDeleted As Boolean = Session("deletedSearch")
            Dim listDevices As List(Of ComputerDevice) = Nothing
            If includeDeleted = True Then
                If String.IsNullOrEmpty(searchString) Then
                    listDevices = db.ComputerDevice.ToList()
                ElseIf String.IsNullOrEmpty(searchString) = False Then
                    listDevices = (From c In db.ComputerDevice Where c.name.ToString().ToLower().Contains(searchString.ToLower())).ToList()
                End If
            ElseIf includeDeleted = False Then
                If String.IsNullOrEmpty(searchString) Then
                    listDevices = (From c In db.ComputerDevice Where c.include_deleted = False).ToList()
                ElseIf String.IsNullOrEmpty(searchString) = False Then
                    listDevices = (From c In db.ComputerDevice Where c.include_deleted = False And c.name.ToString().ToLower().Contains(searchString.ToLower())).ToList()

                End If

            End If

            Return View(listDevices)
        End Function


        ' GET: ComputerDevices/Create
        Function Create() As ActionResult
            Return View()
        End Function


        ' POST: ComputerDevices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim computerDevice As ComputerDevice = db.ComputerDevice.Find(id)
            db.ComputerDevice.Remove(computerDevice)
            db.SaveChanges()
            StoreActionEvent("Delete computer device id: " + id)
            Return RedirectToAction("Index")
        End Function

        <HttpPost()>
        <ActionName("Save")>
        Function SaveData(ByVal computerDevices As List(Of ComputerDevice)) As ActionResult
            Dim maxSort As Integer = getMaxSort()

            computerDevices.ToList().ForEach(Function(item)
                                                 If item.id IsNot Nothing Then
                                                     Dim res As ComputerDevice = db.ComputerDevice.Find(item.id)
                                                     If res IsNot Nothing Then
                                                         res.name = item.name
                                                         res.quantity = item.quantity
                                                         res.import_date = item.import_date
                                                         res.sort = item.sort
                                                         res.include_deleted = item.include_deleted
                                                         db.Entry(res).State = EntityState.Modified
                                                     Else
                                                         Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                                                     End If
                                                 Else
                                                     maxSort += 1
                                                     item.sort = maxSort
                                                     db.ComputerDevice.Add(item) ' Use Add method
                                                 End If
                                             End Function)

            db.SaveChanges()
            StoreActionEvent("Save list devices")
            Return View("Index", computerDevices)
        End Function

        Function getMaxSort()
            Dim max As Integer = db.ComputerDevice.ToList().Max(Function(item) item.sort)
            Return max
        End Function

        <HttpPost()>
        <ActionName("Add-Column")>
        Function AddColumn(ByVal computerDevices As List(Of ComputerDevice)) As ActionResult
            Return View("Index", computerDevices)
        End Function
        <HttpPost()>
        <ActionName("Search")>
        Function Search(ByVal searchString As String, ByVal includeDeleted As Boolean)
            Session("searchName") = searchString
            Session("deletedSearch") = includeDeleted
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        <ActionName("Download")>
        Function DownloadExcelFile()
            Using dt As New DataTable("Devices")
                dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Id", GetType(Integer)),
                                                         New DataColumn("Quanity", GetType(Integer)),
                                                         New DataColumn("Device name"),
                                                         New DataColumn("Import date", GetType(String))
                                                         })

                Dim devices = db.ComputerDevice.ToList()

                For Each device In devices
                    dt.Rows.Add(device.id, device.quantity, device.name, device.import_date)
                Next

                Using wb As New XLWorkbook()
                    Dim ws = wb.Worksheets.Add(dt)
                    Using stream As New MemoryStream()
                        ws.Columns().AdjustToContents()

                        ws.Tables.FirstOrDefault().ShowAutoFilter = False
                        wb.SaveAs(stream)
                        StoreActionEvent("Export file excel list devices")
                        Return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Devices.xlsx")
                    End Using
                End Using
            End Using
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Sub StoreActionEvent(actionEvent As String)
            Dim userId = User.Identity.GetUserId()
            Dim userLog As user_log_action
            userLog = New user_log_action With {
                    .user_id = userId,
                    .action_name = actionEvent,
                    .action_time = DateTime.Now
                }
            db.UserLogAction.Add(userLog)
            db.SaveChanges()
        End Sub
    End Class
End Namespace
