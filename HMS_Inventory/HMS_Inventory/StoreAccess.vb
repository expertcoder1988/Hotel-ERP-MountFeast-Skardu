Imports System.Data
Imports System.Data.SqlClient


Public Class StoreAccess
    'ACCESS CONNECTION
    Dim strConnection As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\bin\Debug\HMS_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    Dim objConnection As New SqlConnection(strConnection)
    Dim objCommand As SqlCommand

    'ACCESS DATA
    Dim objDataAdapter As SqlDataAdapter
    Public objDataSet As DataSet
    'Dim objSNDataAdapter As SqlDataAdapter
    Public objSupplierNameDataTable As DataTable
    Public objItemNameDataTable As DataTable
    Public objCustomerNameDataTable As DataTable
    Public objGetLowPriceDataTable As DataTable

    Public strExceptionHasConnection As String
    Public strExceptionRunQuery As String

    'DETAILS OF TABLES VARIABLES
    Public objDataAdapterGetDetails As SqlDataAdapter
    Public objDataSetGetDetails As DataSet
    Public strExceptionGetDetails As String

    'SEARCHING VARIABLES
    Public objCustomerNameDataTableForSearching As DataTable
    Public objSupplierNameDataTableForSearching As DataTable
    Public objItemNameDataTableForSearching As DataTable
    Public objDataSetSearchRecords As DataSet
    Public intNumberOfRecords As Integer
    Public strExceptionGetCustomerNameForSearching As String
    Public strExceptionSearchRecords As String
    Public strExceptionGetItemNameForSearching As String
    Public strExceptionGetSupplierNameForSearching As String

    'QUERY STATISTICS
    'Public intRecordCountGetSupplierName As Integer
    'Public intRecordCountGetItemName As Integer
    Public intRecordCountGetCustomerName As Integer
    Public strExceptionGetSupplierName As String
    Public strExceptionGetItemName As String
    Public strExceptionGetCustomerName As String
    Public strExceptionGetLowPriceDetails As String
    Public strItemMinimumValue As String

    'ITEM ENTRANCE FORM VARIABLES
    Public strExceptionAddItemSuppliedDetails As String
    Public strExceptionAddSupplierAndItemSuppliedDetails As String
    Public strExceptionAddSupplierAndItemSuppliedAndItemDetails As String
    Public strExceptionAddItemSuppliedAndItemDetails As String
    Public strExceptionDeleteItemSuppliedDataOnly As String
    Public strExceptionDeleteItemSuppliedAndStoreData As String
    'Dim itemEntranceTable As DataTable


    'Public Sub NewItemEntranceTable(sourceTable As DataTable)

    'End Sub


    'ITEM SALES FORM VARIABLES
    Public strExceptionAddSalesAndCustomerDetailsNonDeductFromStore As String
    Public strExceptionAddSalesAndCustomerDetailsDeductFromStore As String
    Public strExceptionAddSalesDetailsNonDeductFromStore As String
    Public strExceptionAddSalesDetailsDeductFromStore As String
    Public strExceptionDeleteSales As String
    Public strExceptionDeleteSalesAndAddToStore As String


    'BRANCH DETAILS REPORT VARIABLES
    Public objSupplierDataTableForReporting As DataTable
    Public objStoreDetailsDataTableForReporting As DataTable
    Public objCustomerDetailsDataTableForReporting As DataTable







    Public Function AutoNumberedTable(ByVal sourceTable As DataTable)
        Dim ResultTable As DataTable = New DataTable

        Dim AutoNumberColumn As New DataColumn
        AutoNumberColumn.DataType = GetType(Integer)
        AutoNumberColumn.AutoIncrement = True
        AutoNumberColumn.AutoIncrementSeed = 1
        AutoNumberColumn.AutoIncrementStep = 1
        ResultTable.Columns.Add(AutoNumberColumn)
        sourceTable.Columns.RemoveAt(0)


        ResultTable.Merge(sourceTable)
        Return ResultTable
    End Function

    Public Function HasConnection() As Boolean
        Try
            'Open the connection
            objConnection.Open()

            'Close the connection
            objConnection.Close()
            Return True
        Catch ex As Exception
            'Set the error message in a variable
            strExceptionHasConnection = ex.Message

            Return False

            'Make sure connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Function

    'METHOD TO RETRIEVE DATA FROM TABLES
    Public Sub RunQuery(Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the dataset
            objDataAdapter = New SqlDataAdapter(objCommand)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            objConnection.Close()
        Catch ex As Exception
            'Capture error message
            strExceptionRunQuery = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub

    'METHOD FOR SEARCHING RECORDS BASED ON QUERY
    Public Sub RunQueryForSearchingRecords(ByVal query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(query, objConnection)

            'Fill the dataset
            objDataAdapter = New SqlDataAdapter(objCommand)
            objDataSetSearchRecords = New DataSet
            intNumberOfRecords = objDataAdapter.Fill(objDataSetSearchRecords)

            objConnection.Close()
        Catch ex As Exception
            'Capture error
            strExceptionSearchRecords = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub


    'METHOD TO RETRIEVE DATA FROM TABLES
    Public Sub RunQueryToGetDetails(Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the dataset
            objDataAdapterGetDetails = New SqlDataAdapter(objCommand)
            objDataSetGetDetails = New DataSet
            objDataAdapterGetDetails.Fill(objDataSetGetDetails)

            objConnection.Close()
        Catch ex As Exception
            'Capture error message
            strExceptionGetDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub

    'GET SUPPLIER NAME
    Public Sub GetSupplierNameForComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            objSupplierNameDataTable = New DataTable
            objSupplierNameDataTable.Load(objCommand.ExecuteReader)

            Dim row As DataRow = objSupplierNameDataTable.NewRow
            row(0) = "NONE"
            row(1) = ""
            row(2) = ""
            objSupplierNameDataTable.Rows.Clear()
            objSupplierNameDataTable.Rows.Add(row)
            objSupplierNameDataTable.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetSupplierName = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetSupplierNameForSearchingComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the dataset
            objSupplierNameDataTableForSearching = New DataTable
            objSupplierNameDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetSupplierNameForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'GET ITEMNAME
    Public Sub GetItemNameForComboBox(ByVal Query As String)
        Try
            'Open the Connection
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the dataset
            objItemNameDataTable = New DataTable
            objItemNameDataTable.Load(objCommand.ExecuteReader)
            Dim row As DataRow = objItemNameDataTable.NewRow
            row(0) = "NONE"
            objItemNameDataTable.Rows.Clear()
            objItemNameDataTable.Rows.Add(row)
            objItemNameDataTable.Load(objCommand.ExecuteReader)

            'Close the Connection
            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetItemName = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetItemNameForComboBoxForSearching(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the dataset
            objItemNameDataTableForSearching = New DataTable
            objItemNameDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetItemNameForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'GET CUSTOMER NAME
    Public Sub GetCustomerNameForComboBox(ByVal Query As String)
        Try
            'Open the connection
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the datatable
            objCustomerNameDataTable = New DataTable
            objCustomerNameDataTable.Load(objCommand.ExecuteReader)
            Dim row As DataRow = objCustomerNameDataTable.NewRow
            row(0) = ""
            row(1) = "NONE"
            objCustomerNameDataTable.Rows.Clear()
            objCustomerNameDataTable.Rows.Add(row)
            objCustomerNameDataTable.Load(objCommand.ExecuteReader)

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Capture error
            strExceptionGetCustomerName = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    Public Sub GetCustomerNameForSearchingComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(Query, objConnection)

            'Fill the datatable
            objCustomerNameDataTableForSearching = New DataTable
            objCustomerNameDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetCustomerNameForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetLowPrice(ByVal itemName As String)
        Try
            Dim strRetriveLowPriceOnly As String = "SELECT MIN(Rate) As MINIMUM " &
                                "FROM Store_ITEM_SUPPLIED " &
                                "WHERE Item_name='" & itemName & "' "


            objConnection.Open()

            objCommand = New SqlCommand(strRetriveLowPriceOnly, objConnection)

            Dim objGetLowPriceOnlyDataTable = New DataTable
            objGetLowPriceOnlyDataTable.Load(objCommand.ExecuteReader)

            If objGetLowPriceOnlyDataTable.Rows.Count > 0 Then
                Dim strLowValue As String = objGetLowPriceOnlyDataTable.Rows(0).Item(0).ToString
                strItemMinimumValue = strLowValue
                Dim strRetriveLowPrice As String = "SELECT DISTINCT Store_ITEM_SUPPLIED.Supplier_ph_no, Supplier_name, Supplier_address " &
                                   "FROM Store_ITEM_SUPPLIED, Store_SUPPLIER " &
                                   "WHERE Store_ITEM_SUPPLIED.Supplier_ph_no=Store_SUPPLIER.Supplier_ph_no " &
                                   "AND Item_name='" & itemName & "' " &
                                   "AND Rate= " & strLowValue

                objCommand = New SqlCommand(strRetriveLowPrice, objConnection)

                objGetLowPriceDataTable = New DataTable
                objGetLowPriceDataTable.Load(objCommand.ExecuteReader)
            End If

            objConnection.Close()
        Catch ex As Exception
            strExceptionGetLowPriceDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub






    'REPORTING METHODS

    'GET SUPPLIER DETAILS FOR REPORT
    Public Sub GetSupplierDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM Store_SUPPLIER ORDER BY Supplier_name"

            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(strCommand, objConnection)

            'Fill the datatable
            objSupplierDataTableForReporting = New DataTable
            objSupplierDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'GET QUANTITY ON STORE DETAILS FOR REPORT
    Public Sub GetStoreDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM STORE ORDER BY Item_name"

            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(strCommand, objConnection)

            'Fill the datatable
            objStoreDetailsDataTableForReporting = New DataTable
            objStoreDetailsDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'GET QUANTITY ON STORE DETAILS FOR REPORT
    Public Sub GetCustomerDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM Store_Customer ORDER BY Customer_name"

            objConnection.Open()

            'Create a command
            objCommand = New SqlCommand(strCommand, objConnection)

            'Fill the datatable
            objCustomerDetailsDataTableForReporting = New DataTable
            objCustomerDetailsDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub








    'ITEM ENTRANCE FORM METHODS

    'ADD NEW SUPPLIER AND ITEM SUPPLIED DETAILS
    Public Sub AddSupplierAndItemSupplied(ByVal supplierName As String, ByVal supplierAddress As String, ByVal supplierPhoneNumber As String, ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal rate As String, ByVal quantity As String)
        Try
            Dim strAddSupplier As String = "INSERT INTO Store_SUPPLIER " &
                            "(Supplier_name, Supplier_address, Supplier_ph_no) " &
                            "VALUES(" &
                            "'" & supplierName & "'," &
                            "'" & supplierAddress & "'," &
                            "'" & supplierPhoneNumber & "')"
            Dim strAddItemSupplied As String = "INSERT INTO Store_ITEM_SUPPLIED(Supplier_ph_no, Item_name, Date_of_supplied, Rate, Quantity)" &
                            "VALUES(" &
                            "'" & supplierPhoneNumber & "'," &
                            "'" & itemName & "'," &
                            "#" & dateOfSupplied & "#," &
                            "'" & rate & "'," &
                            "'" & quantity & "')"
            Dim strAddItemQuantityToStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " &
                "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandSupplier = New SqlCommand(strAddSupplier, objConnection)
            Dim objCommandItemSupplied = New SqlCommand(strAddItemSupplied, objConnection)
            Dim objItemQuantityToStore = New SqlCommand(strAddItemQuantityToStore, objConnection)

            'Execute the command
            objCommandSupplier.ExecuteNonQuery()
            objCommandItemSupplied.ExecuteNonQuery()
            objItemQuantityToStore.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

        Catch ex As Exception
            strExceptionAddSupplierAndItemSuppliedDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub

    'ADD NEW SUPPLIER, ITEM SUPPLIED AND NEW ITEM DETAILS
    Public Sub AddSupplierAndItemSuppliedAndItem(ByVal supplierName As String, supplierAddress As String, supplierPhoneNumber As String, ByVal itemName As String, ByVal dateofSupplied As Date, ByVal rate As String, ByVal quantity As String)
        Try

            Dim strAddSupplier As String = "INSERT INTO Store_SUPPLIER " &
                            "(Supplier_name, Supplier_address, Supplier_ph_no) " &
                            "VALUES(" &
                            "'" & supplierName & "'," &
                            "'" & supplierAddress & "'," &
                            "'" & supplierPhoneNumber & "')"
            Dim strAddStore As String = "INSERT INTO STORE " &
                "VALUES(" &
                "'" & itemName & "', " &
                "'" & quantity & "')"
            Dim strAddItemSupplied As String = "INSERT INTO Store_ITEM_SUPPLIED(Supplier_ph_no, Item_name, Date_of_supplied, Rate, Quantity)" &
                            "VALUES(" &
                            "'" & supplierPhoneNumber & "'," &
                            "'" & itemName & "'," &
                            "#" & dateofSupplied & "#," &
                            "'" & rate & "'," &
                            "'" & quantity & "')"

            objConnection.Open()

            'Create a command
            Dim objCommandSupplier = New SqlCommand(strAddSupplier, objConnection)
            Dim objCommandItemSupplied = New SqlCommand(strAddItemSupplied, objConnection)
            Dim objCommandStore = New SqlCommand(strAddStore, objConnection)

            'Execute the Command object to insert into SUPPLIER, ITEM_SUPPLIED and STORE TABLES
            objCommandSupplier.ExecuteNonQuery()
            objCommandStore.ExecuteNonQuery()
            objCommandItemSupplied.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddSupplierAndItemSuppliedAndItemDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD ITEM SUPPLIED AND NEW ITEM DETAILS
    Public Sub AddItemSuppliedAndItem(ByVal supplierPhoneNumber As String, ByVal itemName As String, ByVal dateofSupplied As Date, ByVal rate As String, ByVal quantity As String)
        Try
            Dim strAddStore As String = "INSERT INTO STORE " &
                "VALUES(" &
                "'" & itemName & "', " &
                "'" & quantity & "')"

            Dim strAddItemSupplied As String = "INSERT INTO Store_ITEM_SUPPLIED(Supplier_ph_no, Item_name, Date_of_supplied, Rate, Quantity) " &
                            "VALUES(" &
                            "'" & supplierPhoneNumber & "'," &
                            "'" & itemName & "'," &
                            "#" & dateofSupplied & "#," &
                            "'" & rate & "'," &
                            "'" & quantity & "')"

            objConnection.Open()

            'Create a command
            Dim objCommandStore = New SqlCommand(strAddStore, objConnection)
            Dim objCommandItemSupplied = New SqlCommand(strAddItemSupplied, objConnection)

            'Execute the Command object to insert into SUPPLIER, ITEM_SUPPLIED and STORE TABLES
            objCommandStore.ExecuteNonQuery()
            objCommandItemSupplied.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemSuppliedAndItemDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD ITEM SUPPLIED DETAILS
    Public Sub AddItemSupplied(ByVal supplierPhoneNumber As String, ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal rate As String, ByVal quantity As String)
        Try
            Dim strAddItemSupplied As String = "INSERT INTO Store_ITEM_SUPPLIED(Supplier_ph_no, Item_name, Date_of_supplied, Rate, Quantity) " &
                            "VALUES(" &
                            "'" & supplierPhoneNumber & "'," &
                            "'" & itemName & "'," &
                            "#" & dateOfSupplied & "#," &
                            "'" & rate & "'," &
                            "'" & quantity & "')"

            Dim strAddItemQuantityToStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand = (Quantity_on_hand + " & quantity & ") " &
                "WHERE Item_name = '" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommand = New SqlCommand(strAddItemSupplied, objConnection)
            Dim objItemQuantityToStore = New SqlCommand(strAddItemQuantityToStore, objConnection)

            objCommand.ExecuteNonQuery()
            objItemQuantityToStore.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemSuppliedDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'DELETE THE ITEM SUPPLIED DETAILS ONLY
    Public Sub DeleteItemSuppliedDataOnly(ByVal supplierPhoneNumber As String, ByVal itemName As String, ByVal dateOfSupplied As Date)
        Try
            Dim strDeleteItemSupplied = "DELETE * FROM Store_ITEM_SUPPLIED " &
            "WHERE Supplier_ph_no='" & supplierPhoneNumber & "' " &
            "AND Item_name='" & itemName & "' " &
            "AND Date_of_supplied=#" & dateOfSupplied & "#"

            'Open the connection
            objConnection.Open()

            Dim objCommandItemSupplied = New SqlCommand(strDeleteItemSupplied, objConnection)

            Dim intChangeCount As Integer = objCommandItemSupplied.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

            'REPORT RESULTS
            If intChangeCount = 0 Then
                MsgBox("The item you wanted to delete could not be found.")
            Else
                MsgBox(intChangeCount & " records Affected!")
            End If

        Catch ex As Exception
            strExceptionDeleteItemSuppliedDataOnly = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE ITEM SUPPLIED DETAILS AND ALSO DEDUCT THE THE QUANTITY OF ITEM FROM THE STORE
    Public Sub DeleteItemSuppliedAndStoreData(ByVal supplierPhoneNumber As String, ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal quantity As String)
        Try
            Dim strDeleteItemSupplied = "DELETE * FROM Store_ITEM_SUPPLIED " &
            "WHERE Supplier_ph_no='" & supplierPhoneNumber & "' " &
            "AND Item_name='" & itemName & "' " &
            "AND Date_of_supplied=#" & dateOfSupplied & "#"
            Dim strSubtractItemQuantityInStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand=(Quantity_on_hand - " & quantity & ") " &
                    "WHERE Item_name='" & itemName & "'"


            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteItemSupplied = New SqlCommand(strDeleteItemSupplied, objConnection)
            Dim objCommandSubractStoreQuantity = New SqlCommand(strSubtractItemQuantityInStore, objConnection)

            Dim intChangeCount1 As Integer = objCommandDeleteItemSupplied.ExecuteNonQuery()
            Dim intChangeCount2 As Integer = objCommandSubractStoreQuantity.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

            'REPORT RESULTS
            If intChangeCount1 = 0 And intChangeCount2 = 0 Then
                MsgBox("The item you wanted to delete could not be found.")
            Else
                MsgBox(intChangeCount1 & " record deleted and another " & intChangeCount2 & " record is altered.")
            End If

        Catch ex As Exception
            strExceptionDeleteItemSuppliedAndStoreData = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub UpdateData(ByVal dateOfSupplied As Date, ByVal rate As String, ByVal quantity As String, ByVal amount As String, ByVal ph As String, ByVal iname As String)
        Try
            Dim strUpdateItemSupplied As String = "UPDATE Store_ITEM_SUPPLIED " &
            "SET Date_of_supplied=#" & dateOfSupplied & "#, " &
            "Rate='" & rate & "'," &
            "Quantity='" & quantity & "'," &
            "Amount='" & amount & "'" &
            "WHERE Supplier_ph_no='" & ph & "' " &
            "AND Item_name='" & iname & "'"

            'Open the connection
            objConnection.Open()

            Dim objUpdateCommand = New SqlCommand(strUpdateItemSupplied, objConnection)

            Dim intChangeCount As Integer = objUpdateCommand.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

            'REPORT RESULTS
            If intChangeCount = 0 Then
                MsgBox("The item you wanted to update could not be found.")
            Else
                MsgBox(intChangeCount & " records Affected!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub







    'ITEM SALES FORM METHODS

    'ADD SALES AND NEW CUSTOMER DETAILS AND DO NOT DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesAndCustomerAndNonDeductFromStore(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddCustomer As String = "INSERT INTO Store_CUSTOMER " &
                "VALUES(" &
                "'" & customerPhoneNumber & "'," &
                "'" & customerName & "')"

            Dim strAddSales As String = "INSERT INTO Store_SALES " &
                "(Item_name, Date_of_bought, Customer_ph_no, Quantity) " &
                "VALUES(" &
                "'" & itemName & "'," &
                "#" & dateOfBought & "#," &
                "'" & customerPhoneNumber & "'," &
                "'" & quantity & "')"

            objConnection.Open()

            'Create a command
            Dim objCommandCustomer = New SqlCommand(strAddCustomer, objConnection)
            Dim objCommandSales = New SqlCommand(strAddSales, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandCustomer.ExecuteNonQuery()
            objCommandSales.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddSalesAndCustomerDetailsNonDeductFromStore = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS AND DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesAndCustomerAndDeductFromStore(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddCustomer As String = "INSERT INTO Store_CUSTOMER " &
                "VALUES(" &
                "'" & customerPhoneNumber & "'," &
                "'" & customerName & "')"

            Dim strAddSales As String = "INSERT INTO Store_SALES " &
                "(Item_name, Date_of_bought, Customer_ph_no, Quantity) " &
                "VALUES(" &
                "'" & itemName & "'," &
                "#" & dateOfBought & "#," &
                "'" & customerPhoneNumber & "'," &
                "'" & quantity & "')"

            Dim strSubtractItemQuantityInStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand=(Quantity_on_hand - " & quantity & ") " &
                    "WHERE Item_name='" & itemName & "'"

            objConnection.Open()

            'Create a command
            Dim objCommandCustomer = New SqlCommand(strAddCustomer, objConnection)
            Dim objCommandSales = New SqlCommand(strAddSales, objConnection)
            Dim objCommandSubractStoreQuantity = New SqlCommand(strSubtractItemQuantityInStore, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandCustomer.ExecuteNonQuery()
            objCommandSales.ExecuteNonQuery()
            objCommandSubractStoreQuantity.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddSalesAndCustomerDetailsDeductFromStore = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'ADD SALES AND DO NOT DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesAndNonDeductFromStore(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddSales As String = "INSERT INTO Store_SALES " &
                "(Item_name, Date_of_bought, Customer_ph_no, Quantity) " &
                "VALUES(" &
                "'" & itemName & "'," &
                "#" & dateOfBought & "#," &
                "'" & customerPhoneNumber & "'," &
                "'" & quantity & "')"

            objConnection.Open()

            'Create a command
            Dim objCommandSales = New SqlCommand(strAddSales, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandSales.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddSalesDetailsNonDeductFromStore = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD SALES AND DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesAndDeductFromStore(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddSales As String = "INSERT INTO Store_SALES " &
                "(Item_name, Date_of_bought, Customer_ph_no, Quantity) " &
                "VALUES(" &
                "'" & itemName & "'," &
                "#" & dateOfBought & "#," &
                "'" & customerPhoneNumber & "'," &
                "'" & quantity & "')"

            Dim strSubtractItemQuantityInStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand=(Quantity_on_hand - " & quantity & ") " &
                    "WHERE Item_name='" & itemName & "'"

            objConnection.Open()

            'Create a command
            Dim objCommandSales = New SqlCommand(strAddSales, objConnection)
            Dim objCommandSubractStoreQuantity = New SqlCommand(strSubtractItemQuantityInStore, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandSales.ExecuteNonQuery()
            objCommandSubractStoreQuantity.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddSalesDetailsDeductFromStore = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'DELETE THE ITEM SOLD DETAILS ONLY
    Public Sub DeleteSales(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String)
        Try
            Dim strDeleteSales = "DELETE * FROM Store_SALES " &
           "WHERE Item_name='" & itemName & "' " &
           "AND Date_of_bought=#" & dateOfBought & "#" &
           "AND Customer_ph_no='" & customerPhoneNumber & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandSales = New SqlCommand(strDeleteSales, objConnection)

            objCommandSales.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteSales = ex.Message

            'Make sure that the connection is closed..
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE ITEM SOLD DETAILS AND ALSO ADD THE QUANTITY OF ITEM TO THE STORE
    Public Sub DeleteSalesAndAddToStore(ByVal itemName As String, ByVal dateOfBought As Date, ByVal customerPhoneNumber As String, ByVal quantity As String)
        Try
            Dim strDeleteSales = "DELETE * FROM Store_SALES " &
           "WHERE Item_name='" & itemName & "' " &
           "AND Date_of_bought=#" & dateOfBought & "#" &
           "AND Customer_ph_no='" & customerPhoneNumber & "'"

            Dim strAddItemQuantityInStore As String = "UPDATE STORE " &
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " &
                    "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandSales = New SqlCommand(strDeleteSales, objConnection)
            Dim objCommandAddStoreQuantity = New SqlCommand(strAddItemQuantityInStore, objConnection)

            objCommandSales.ExecuteNonQuery()
            objCommandAddStoreQuantity.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteSalesAndAddToStore = ex.Message

            'Make sure that the connection is closed..
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub
End Class
