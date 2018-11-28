Imports System.Data
Imports System.Data.OleDb

Public Class clsItemPeps
   Implements IDisposable

   Private mlngItemPepsId As Long
   Private mlngEmpresaId As Long
   Private mlngGestionId As Long
   Private mlngAlmacenId As Long
   Private mlngNotaId As Long
   Private mlngNotaDetId As Long
   Private mlngItemId As Long
   Private mstrFecha As String
   Private mlngFechaNro As Long
   Private mdecPrecio As Decimal
   Private mdecSaldo As Decimal
   Private mstrLastUpdateId As String
   Private mstrLastUpdateDate As String
   Private mintConcurrencyId As Integer

   Private moConnection As OleDbConnection
   Private moDataAdapter As OleDbDataAdapter
   Private moDataSet As DataSet
   Private mintRow As Integer
   Private mintRowsCount As Integer

   Private mstrConnectionString As String
   Private mstrTableName As String
   Private mstrClassName As String
   Private mstrSQL As String

   '******************************************************
   ' Private Data To Match the Table Definition
   '******************************************************
   Property ItemPepsId() As Long
      Get
         Return mlngItemPepsId
      End Get

      Set(ByVal Value As Long)
         mlngItemPepsId = Value
      End Set
   End Property

   Property EmpresaId() As Long
      Get
         Return mlngEmpresaId
      End Get

      Set(ByVal Value As Long)
         mlngEmpresaId = Value
      End Set
   End Property

   Property GestionId() As Long
      Get
         Return mlngGestionId
      End Get

      Set(ByVal Value As Long)
         mlngGestionId = Value
      End Set
   End Property

   Property AlmacenId() As Long
      Get
         Return mlngAlmacenId
      End Get

      Set(ByVal Value As Long)
         mlngAlmacenId = Value
      End Set
   End Property

   Property NotaId() As Long
      Get
         Return mlngNotaId
      End Get

      Set(ByVal Value As Long)
         mlngNotaId = Value
      End Set
   End Property

   Property NotaDetId() As Long
      Get
         Return mlngNotaDetId
      End Get

      Set(ByVal Value As Long)
         mlngNotaDetId = Value
      End Set
   End Property

   Property ItemId() As Long
      Get
         Return mlngItemId
      End Get

      Set(ByVal Value As Long)
         mlngItemId = Value
      End Set
   End Property

   Property Fecha() As String
      Get
         Return mstrFecha
      End Get

      Set(ByVal Value As String)
         mstrFecha = Value
      End Set
   End Property

   Property FechaNro() As Long
      Get
         Return mlngFechaNro
      End Get

      Set(ByVal Value As Long)
         mlngFechaNro = Value
      End Set
   End Property

   Property Precio() As Decimal
      Get
         Return mdecPrecio
      End Get

      Set(ByVal Value As Decimal)
         mdecPrecio = Value
      End Set
   End Property

   Property Saldo() As Decimal
      Get
         Return mdecSaldo
      End Get

      Set(ByVal Value As Decimal)
         mdecSaldo = Value
      End Set
   End Property

   '******************************************************
   ' Private Data To Concurrency Table Definition
   '******************************************************
   Property LastUpdateId() As String
      Get
         Return mstrLastUpdateId
      End Get

      Set(ByVal Value As String)
         mstrLastUpdateId = Value
      End Set
   End Property

   Property LastUpdateDate() As String
      Get
         Return mstrLastUpdateDate
      End Get

      Set(ByVal Value As String)
         mstrLastUpdateDate = Value
      End Set
   End Property

   Property ConcurrencyId() As Integer
      Get
         Return mintConcurrencyId
      End Get

      Set(ByVal Value As Integer)
         mintConcurrencyId = Value
      End Set
   End Property

   Property ConnectionString() As String
      Get
         Return mstrConnectionString
      End Get

      Set(ByVal Value As String)
         mstrConnectionString = Value
      End Set
   End Property

   Property DataSet() As DataSet
      Get
         Return moDataSet
      End Get

      Set(ByVal Value As DataSet)
         moDataSet = Value
      End Set
   End Property

   ReadOnly Property TableName() As String
      Get
         Return mstrTableName
      End Get
   End Property

   ReadOnly Property ClassName() As String
      Get
         Return mstrClassName
      End Get
   End Property

   ReadOnly Property SQL() As String
      Get
         Return mstrSQL
      End Get
   End Property

   '******************************************************
   '* The following enumerations will change for each
   '* data access class
   '******************************************************
   Public Enum SelectFilters As Byte
      All = 0
      ListBox = 1
      Grid = 2
      Report = 3
   End Enum

   Public Enum WhereFilters As Byte
      None = 0
      PrimaryKey = 1
      Grid = 3
      Report = 4
      EmpresaId = 5
      ItemId = 6
      Fecha = 7
      NotaDetId = 8
   End Enum

   Public Enum OrderByFilters As Byte
      None = 0
      ItemPepsId = 1
      Grid = 3
      Report = 4
      Fecha = 5
   End Enum

   Public Enum InsertFilters As Byte
      All = 0
   End Enum

   Public Enum UpdateFilters As Byte
      All = 0
      Precio = 1
   End Enum

   Public Enum DeleteFilters As Byte
      All = 0
   End Enum

   Public Enum RowCountFilters As Byte
      All = 0
   End Enum

   Public Enum RowMaxFilters As Byte
      FechaNro = 1
   End Enum

   '*********************************************************
   '* The following filters will change for each
   '* data access class
   '*********************************************************
   Private mintSelectFilter As SelectFilters
   Private mintWhereFilter As WhereFilters
   Private mintOrderByFilter As OrderByFilters
   Private mintInsertFilter As InsertFilters
   Private mintUpdateFilter As UpdateFilters
   Private mintDeleteFilter As DeleteFilters
   Private mintRowCountFilter As RowCountFilters
   Private mintRowMaxFilter As RowMaxFilters

   Property SelectFilter() As SelectFilters
      Get
         Return mintSelectFilter
      End Get

      Set(ByVal Value As SelectFilters)
         mintSelectFilter = Value
      End Set
   End Property

   Property WhereFilter() As WhereFilters
      Get
         Return mintWhereFilter
      End Get

      Set(ByVal Value As WhereFilters)
         mintWhereFilter = Value
      End Set
   End Property

   Property OrderByFilter() As OrderByFilters
      Get
         Return mintOrderByFilter
      End Get

      Set(ByVal Value As OrderByFilters)
         mintOrderByFilter = Value
      End Set
   End Property

   Property InsertFilter() As InsertFilters
      Get
         Return mintInsertFilter
      End Get

      Set(ByVal Value As InsertFilters)
         mintInsertFilter = Value
      End Set
   End Property

   Property UpdateFilter() As UpdateFilters
      Get
         Return mintUpdateFilter
      End Get

      Set(ByVal Value As UpdateFilters)
         mintUpdateFilter = Value
      End Set
   End Property

   Property DeleteFilter() As DeleteFilters
      Get
         Return mintDeleteFilter
      End Get

      Set(ByVal Value As DeleteFilters)
         mintDeleteFilter = Value
      End Set
   End Property

   Property RowCountFilter() As RowCountFilters
      Get
         Return mintRowCountFilter
      End Get

      Set(ByVal Value As RowCountFilters)
         mintRowCountFilter = Value
      End Set
   End Property

   Property RowMaxFilter() As RowMaxFilters
      Get
         Return mintRowMaxFilter
      End Get

      Set(ByVal Value As RowMaxFilters)
         mintRowMaxFilter = Value
      End Set
   End Property

   '************************************************************
   '* Method Name  : New()
   '* Syntax       : Constructor
   '* Parameters   : None
   '*
   '* Description  : This event is called when the object is created.
   '* It can be used to initialize private data variables.
   '*
   '************************************************************
   Public Sub New()
      mstrTableName = "invItemPeps"
      mstrClassName = "clsItemPeps"

      moConnection = New OleDbConnection

      Call PropertyInit()
      Call FilterInit()
   End Sub

   Public Sub New(ByVal ConnectString As String)
      Me.New()

      mstrConnectionString = ConnectString
   End Sub

   Public Sub New(ByVal ConnectString As String, ByVal bytSelectFilter As SelectFilters)
      Me.New()

      mstrConnectionString = ConnectString
      mintSelectFilter = bytSelectFilter
   End Sub

   Public Sub New(ByVal ConnectString As String, _
                  ByVal bytSelectFilter As SelectFilters, _
                  ByVal bytWhereFilter As WhereFilters)
      Me.New()

      mstrConnectionString = ConnectString
      mintSelectFilter = bytSelectFilter
      mintWhereFilter = bytWhereFilter
   End Sub

   Public Sub New(ByVal ConnectString As String, _
                  ByVal bytSelectFilter As SelectFilters, _
                  ByVal bytWhereFilter As WhereFilters, _
                  ByVal bytOrderByFilter As OrderByFilters)
      Me.New()

      mstrConnectionString = ConnectString
      mintSelectFilter = bytSelectFilter
      mintWhereFilter = bytWhereFilter
      mintOrderByFilter = bytOrderByFilter
   End Sub

   Public Sub PropertyInit()
      mlngItemPepsId = 0
      mlngEmpresaId = 0
      mlngGestionId = 0
      mlngAlmacenId = 0
      mlngNotaId = 0
      mlngNotaDetId = 0
      mlngItemId = 0
      mstrFecha = ""
      mlngFechaNro = 0
      mdecPrecio = 0
      mdecSaldo = 0

      mstrLastUpdateId = ""
      mstrLastUpdateDate = ""
      mintConcurrencyId = 0
   End Sub

   Private Function SelectSQL() As String
      Dim strSQL As String

      Select Case mintSelectFilter
         Case SelectFilters.All
            strSQL = " SELECT  "
            strSQL &= "    invItemPeps.ItemPepsId,  "
            strSQL &= "    invItemPeps.EmpresaId,  "
            strSQL &= "    invItemPeps.GestionId,  "
            strSQL &= "    invItemPeps.AlmacenId,  "
            strSQL &= "    invItemPeps.NotaId,  "
            strSQL &= "    invItemPeps.NotaDetId,  "
            strSQL &= "    invItemPeps.ItemId,  "
            strSQL &= "    invItemPeps.Fecha,  "
            strSQL &= "    invItemPeps.FechaNro,  "
            strSQL &= "    invItemPeps.Precio,  "
            strSQL &= "    invItemPeps.Saldo,  "
            strSQL &= "    invItemPeps.sLastUpdate_id,  "
            strSQL &= "    invItemPeps.dtLastUpdate_dt,  "
            strSQL &= "    invItemPeps.iConcurrency_id  "
            strSQL &= " FROM invItemPeps "

         Case SelectFilters.ListBox

         Case SelectFilters.Grid

         Case SelectFilters.Report

      End Select

      strSQL &= WhereFilterGet()

      strSQL &= OrderByFilterGet()

      mstrSQL = strSQL

      Return strSQL
   End Function

   Private Function WhereFilterGet() As String
      Dim strSQL As String

      Select Case mintWhereFilter
         Case WhereFilters.PrimaryKey
            strSQL = " WHERE  invItemPeps.ItemPepsId = " & NumberToField(mlngItemPepsId)

         Case WhereFilters.Grid

         Case WhereFilters.Report

         Case WhereFilters.EmpresaId
            strSQL = " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)

         Case WhereFilters.ItemId
            strSQL = " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)
            strSQL &= " AND  invItemPeps.GestionId = " & NumberToField(mlngGestionId)
            strSQL &= " AND  invItemPeps.AlmacenId = " & NumberToField(mlngAlmacenId)
            strSQL &= " AND  invItemPeps.ItemId = " & NumberToField(mlngItemId)

         Case WhereFilters.Fecha
            strSQL = " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)
            strSQL &= " AND  invItemPeps.GestionId = " & NumberToField(mlngGestionId)
            strSQL &= " AND  invItemPeps.AlmacenId = " & NumberToField(mlngAlmacenId)
            strSQL &= " AND  invItemPeps.ItemId = " & NumberToField(mlngItemId)
            strSQL &= " AND  invItemPeps.Fecha = " & DateToField(mstrFecha)

         Case WhereFilters.NotaDetId
            strSQL = " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)
            strSQL &= " AND  invItemPeps.NotaDetId = " & NumberToField(mlngNotaDetId)

      End Select

      Return strSQL
   End Function

   Private Function OrderByFilterGet() As String
      Dim strSQL As String

      Select Case mintOrderByFilter
         Case OrderByFilters.ItemPepsId
            strSQL = " ORDER BY invItemPeps.ItemPepsId "

         Case OrderByFilters.Grid
            strSQL = " ORDER BY invItemPeps.ItemPepsId "

         Case OrderByFilters.Report

         Case OrderByFilters.Fecha
            strSQL = " ORDER BY invItemPeps.Fecha, invItemPeps.FechaNro "

      End Select

      Return strSQL
   End Function

   Private Function RowCountSQL() As String
      Dim strSQL As String

      Select Case mintRowCountFilter
         Case RowCountFilters.All
            strSQL = "SELECT Count(*) As NumRecs FROM " & mstrTableName
            strSQL &= WhereFilterGet()

      End Select

      Return strSQL
   End Function

   Private Function RowMaxSQL() As String
      Dim strSQL As String

      Select Case mintRowMaxFilter
         Case RowMaxFilters.FechaNro
            strSQL = "SELECT Max(FechaNro) FROM " & mstrTableName
            strSQL &= WhereFilterGet()

      End Select

      Return strSQL
   End Function

   Private Function InsertSQL() As String
      Dim strSQL As String

      Select Case mintInsertFilter
         Case InsertFilters.All
            strSQL = "INSERT INTO invItemPeps ("
            strSQL &= "ItemPepsId, "
            strSQL &= "EmpresaId, "
            strSQL &= "GestionId, "
            strSQL &= "AlmacenId, "
            strSQL &= "NotaId, "
            strSQL &= "NotaDetId, "
            strSQL &= "ItemId, "
            strSQL &= "Fecha, "
            strSQL &= "FechaNro, "
            strSQL &= "Precio, "
            strSQL &= "Saldo, "
            strSQL &= ConcurInsert()
            strSQL &= ") VALUES ("
            strSQL &= NumberToField(mlngItemPepsId) & ", "
            strSQL &= NumberToField(mlngEmpresaId) & ", "
            strSQL &= NumberToField(mlngGestionId) & ", "
            strSQL &= NumberToField(mlngAlmacenId) & ", "
            strSQL &= NumberToField(mlngNotaId) & ", "
            strSQL &= NumberToField(mlngNotaDetId) & ", "
            strSQL &= NumberToField(mlngItemId) & ", "
            strSQL &= DateToField(mstrFecha) & ", "
            strSQL &= NumberToField(mlngFechaNro) & ", "
            strSQL &= DecimalToField(mdecPrecio) & ", "
            strSQL &= DecimalToField(mdecSaldo) & ", "
            strSQL &= ConcurDateInserted(clsAppInfo.LoginId)

      End Select

      Return strSQL
   End Function

   Private Function UpdateSQL() As String
      Dim strSQL As String

      Select Case mintUpdateFilter
         Case UpdateFilters.All
            strSQL = "UPDATE invItemPeps SET "
            strSQL &= "EmpresaId = " & NumberToField(mlngEmpresaId) & ", "
            strSQL &= "GestionId = " & NumberToField(mlngGestionId) & ", "
            strSQL &= "AlmacenId = " & NumberToField(mlngAlmacenId) & ", "
            strSQL &= "NotaId = " & NumberToField(mlngNotaId) & ", "
            strSQL &= "NotaDetId = " & NumberToField(mlngNotaDetId) & ", "
            strSQL &= "ItemId = " & NumberToField(mlngItemId) & ", "
            strSQL &= "Fecha = " & DateToField(mstrFecha) & ", "
            strSQL &= "FechaNro = " & NumberToField(mlngFechaNro) & ", "
            strSQL &= "Precio = " & DecimalToField(mdecPrecio) & ", "
            strSQL &= "Saldo = " & DecimalToField(mdecSaldo) & ", "
            strSQL &= ConcurDateUpdated(mintConcurrencyId, clsAppInfo.LoginId)
            strSQL &= " WHERE "
            strSQL &= " ItemPepsId = " & NumberToField(mlngItemPepsId) & " "

         Case UpdateFilters.Precio
            strSQL = "UPDATE invItemPeps SET "
            strSQL &= "Precio = " & DecimalToField(mdecPrecio) & " "
            strSQL &= " WHERE "
            strSQL &= " ItemPepsId = " & NumberToField(mlngItemPepsId) & " "

      End Select

      Return strSQL
   End Function

   Private Function DeleteSQL() As String
      Dim strSQL As String

      Select Case mintDeleteFilter
         Case DeleteFilters.All
            strSQL = "DELETE FROM " & mstrTableName
            strSQL &= WhereFilterGet()

      End Select

      Return strSQL
   End Function

   Private Sub Retrieve(ByVal oDataRow As DataRow)
      Try
         Call PropertyInit()

         Select Case mintSelectFilter
            Case SelectFilters.All
               mlngItemPepsId = ToLong(oDataRow("ItemPepsId"))
               mlngEmpresaId = ToLong(oDataRow("EmpresaId"))
               mlngGestionId = ToLong(oDataRow("GestionId"))
               mlngAlmacenId = ToLong(oDataRow("AlmacenId"))
               mlngNotaId = ToLong(oDataRow("NotaId"))
               mlngNotaDetId = ToLong(oDataRow("NotaDetId"))
               mlngItemId = ToLong(oDataRow("ItemId"))
               mstrFecha = ToDateDMY(oDataRow("Fecha"))
               mlngFechaNro = ToLong(oDataRow("FechaNro"))
               mdecPrecio = ToDecimal(oDataRow("Precio"))
               mdecSaldo = ToDecimal(oDataRow("Saldo"))
               mstrLastUpdateId = ToStr(oDataRow("sLastUpdate_id"))
               mstrLastUpdateDate = ToStr(oDataRow("dtLastUpdate_dt"))
               mintConcurrencyId = ToInteger(oDataRow("iConcurrency_id"))

            Case SelectFilters.ListBox

         End Select

      Catch exp As Exception
         Throw exp
      End Try
   End Sub

   Private Function GetNewPrimaryKey() As Boolean
      Try
         GetNewPrimaryKey = False

         Call OpenConection()

         mlngItemPepsId = TableIDGet(mstrTableName, "ItemPepsId", moConnection)

         If mlngItemPepsId = -1 Then
            Throw New Exception("No se puede generar un identificador unico para esta tabla: " & mstrTableName)
         Else
            GetNewPrimaryKey = True
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Validate() As Boolean
      Dim strMsg As String = String.Empty

      If mlngEmpresaId = 0 Then
         strMsg &= "Empresa Inv�lida" & vbCrLf
      End If

      If mlngGestionId = 0 Then
         strMsg &= "Gesti�n Inv�lida" & vbCrLf
      End If

      If mlngAlmacenId = 0 Then
         strMsg &= "Almac�n Inv�lido" & vbCrLf
      End If

      If mlngNotaId = 0 Then
         strMsg &= "Nota Inv�lida" & vbCrLf
      End If

      If mlngNotaDetId = 0 Then
         strMsg &= "Detalle de Nota Inv�lida" & vbCrLf
      End If

      If mlngItemId = 0 Then
         strMsg &= "Item Inv�lido" & vbCrLf
      End If

      If strMsg.Trim <> String.Empty Then
         Throw New Exception(strMsg)
         Validate = False
      Else
         Validate = True
      End If
   End Function

   Public Function NoDuplicates(ByVal boolReplace As Boolean) As Boolean
      Dim strSQL As String
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Try
         'strSQL = " SELECT  "
         'strSQL &= " Count(*) As NumRecs  "
         'strSQL &= " FROM invItemPeps "

         'If Not boolReplace Then
         '   strSQL &= " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)
         '   strSQL &= " AND  invItemPeps.TipoNotaId = " & NumberToField(mlngTipoNotaId)
         'Else
         '   strSQL &= " WHERE  invItemPeps.EmpresaId = " & NumberToField(mlngEmpresaId)
         '   strSQL &= " AND  invItemPeps.TipoNotaId = " & NumberToField(mlngTipoNotaId)
         '   strSQL &= " AND  invItemPeps.ItemPepsId <> " & NumberToField(mlngItemPepsId)
         'End If

         If strSQL <> "" Then
            Call OpenConection()

            oCommand = New OleDbCommand
            oCommand.CommandText = strSQL
            oCommand.Connection = moConnection

            intRecordsAffected = oCommand.ExecuteScalar

            If intRecordsAffected = 0 Then
               NoDuplicates = True
            Else
               NoDuplicates = False
            End If
         Else
            NoDuplicates = True
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Open() As Boolean
      Try
         Open = False

         Call OpenConection()

         moDataSet = New DataSet

         moDataAdapter = New OleDbDataAdapter(SelectSQL, moConnection)

         moDataAdapter.Fill(moDataSet, mstrTableName)

         moDataAdapter.Dispose()

         mintRow = 0
         mintRowsCount = moDataSet.Tables(mstrTableName).Rows.Count()

         Open = True

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Read() As Boolean
      Dim oDataRow As Data.DataRow

      Read = False

      Try
         If mintRowsCount > 0 Then
            If mintRow <= mintRowsCount - 1 Then
               oDataRow = moDataSet.Tables(mstrTableName).Rows(mintRow)

               Call Retrieve(oDataRow)
               Read = True
            End If
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Find() As Boolean
      Find = False

      Try
         If Open() Then
            If Read() Then
               Find = True
            End If
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function FindByPK() As Boolean
      FindByPK = False

      Try
         mintSelectFilter = SelectFilters.All
         mintWhereFilter = WhereFilters.PrimaryKey
         mintOrderByFilter = OrderByFilters.None

         If Open() Then
            If Read() Then
               FindByPK = True
            End If
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Sub MoveNext()
      If mintRowsCount > 0 Then
         If mintRow < mintRowsCount Then
            mintRow += 1
         End If
      End If
   End Sub

   Public Sub MovePrevious()
      If mintRowsCount > 0 Then
         If mintRow > 0 Then
            mintRow -= 1
         End If
      End If
   End Sub

   Public Sub MoveFirst()
      If mintRowsCount > 0 Then
         mintRow = 0
      End If
   End Sub

   Public Sub MoveLast()
      If mintRowsCount > 0 Then
         mintRow = mintRowsCount - 1
      End If
   End Sub

   Public Function Insert() As Boolean
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Insert = False

      Try
         If Validate() Then
            If NoDuplicates(False) Then
               If GetNewPrimaryKey() Then
                  Call OpenConection()

                  oCommand = New OleDbCommand
                  oCommand.CommandText = InsertSQL()
                  oCommand.Connection = moConnection

                  intRecordsAffected = oCommand.ExecuteNonQuery()

                  If intRecordsAffected > 0 Then
                     Insert = True
                  End If
               End If
            Else
               Throw New Exception("Registro Duplicado")
               Return False
            End If
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Update() As Boolean
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Update = False

      Try
         If Validate() Then
            If NoDuplicates(True) Then
               Call OpenConection()

               oCommand = New OleDbCommand
               oCommand.CommandText = UpdateSQL()
               oCommand.Connection = moConnection

               intRecordsAffected = oCommand.ExecuteNonQuery()

               If intRecordsAffected > 0 Then
                  Update = True
               End If
            Else
               Throw New Exception("Registro Duplicado")
               Return False
            End If
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function Delete() As Boolean
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Delete = False

      Try
         Call OpenConection()

         oCommand = New OleDbCommand
         oCommand.CommandText = DeleteSQL()
         oCommand.Connection = moConnection

         intRecordsAffected = oCommand.ExecuteNonQuery()

         If intRecordsAffected > 0 Then
            Delete = True
         End If

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function RowCount() As Integer
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Try
         Call OpenConection()

         oCommand = New OleDbCommand
         oCommand.CommandText = RowCountSQL()
         oCommand.Connection = moConnection

         intRecordsAffected = CInt(oCommand.ExecuteScalar)

         Return intRecordsAffected

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Function RowMax() As Integer
      Dim oCommand As OleDbCommand
      Dim intRecordsAffected As Integer

      Try
         Call OpenConection()

         oCommand = New OleDbCommand
         oCommand.CommandText = RowMaxSQL()
         oCommand.Connection = moConnection

         intRecordsAffected = ToInteger(oCommand.ExecuteScalar)

         Return intRecordsAffected

      Catch exp As Exception
         Throw exp

      End Try
   End Function

   Public Sub FilterInit()
      mintWhereFilter = 0
      mintOrderByFilter = 0
      mintSelectFilter = 0
      mintInsertFilter = 0
      mintUpdateFilter = 0
      mintDeleteFilter = 0
      mintRowCountFilter = 0
   End Sub

   Private Sub OpenConection()
      If moConnection.State = ConnectionState.Closed Then
         moConnection = New OleDbConnection(mstrConnectionString)
         moConnection.Open()
      End If
   End Sub

   Public Sub CloseConection()
      If moConnection.State = ConnectionState.Open Then
         moConnection.Close()
      End If
   End Sub

   Overridable Sub Dispose() Implements IDisposable.Dispose
      Call CloseConection()
   End Sub

End Class