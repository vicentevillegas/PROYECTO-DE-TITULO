Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Public Class PrmregBO
    
    	<Key>
	<Display(Name:="Week Number", ShortName:="wknum")>
	<Required(ErrorMessage:="Week Number is required.")>
	<Column(Order:=1)>
	<MaxLength(20)>
	Private _wknum As String
	Public Property wknum() As String
		Get
			Return _wknum
		End Get
		Set(ByVal value As String)
			_wknum = value
		End Set
	End Property

	<Key>
	<Display(Name:="Project Id", ShortName:="prmpro")>
	<Required(ErrorMessage:="Project Id is required.")>
	<Column(Order:=2)>
	<MaxLength(20)>
	Private _prmpro As String
    Public Property prmpro().Trim As String
        Get
            Return _prmpro
        End Get
        Set(ByVal value As String)
            _prmpro = value
        End Set
    End Property

    <Key>
	<Display(Name:="User Id", ShortName:="prmuser")>
	<Required(ErrorMessage:="User Id is required.")>
	<Column(Order:=3)>
	<MaxLength(20)>
	Private _prmuser As String
    Public Property prmuser().Trim As String
        Get
            Return _prmuser
        End Get
        Set(ByVal value As String)
            _prmuser = value
        End Set
    End Property

    <Display(Name:="Start Date", ShortName:="strdate")>
    <Required(ErrorMessage:="Start Date is required.")>
    <Column(Order:=4)>
    Protected _strdate As String = "0001-01-01"
    Public Overridable Property strdate() As String
        Get
            Return _strdate
        End Get
        Set(ByVal value As String)
            Dim _date As Date = value
            value = _date.ToString("yyyy-MM-dd")
            _strdate = value
        End Set
    End Property

    <Display(Name:="Work Hours", ShortName:="wrkhrs")>
	<Required(ErrorMessage:="Work Hours is required.")>
	<Column(Order:=5)>
	<MaxLength(4)>
	Private _wrkhrs As String
	Public Property wrkhrs() As String
		Get
			Return _wrkhrs
		End Get
		Set(ByVal value As String)
			_wrkhrs = value
		End Set
	End Property

	<Display(Name:="Add Location", ShortName:="addloc")>
	<Column(Order:=6)>
	<MaxLength(30)>
	Private _addloc As String
	Public Property addloc() As String
		Get
			Return _addloc
		End Get
		Set(ByVal value As String)
			_addloc = value
		End Set
	End Property

	<Display(Name:="Add Module", ShortName:="addmod")>
	<Column(Order:=7)>
	<MaxLength(30)>
	Private _addmod As String
	Public Property addmod() As String
		Get
			Return _addmod
		End Get
		Set(ByVal value As String)
			_addmod = value
		End Set
	End Property

	<Display(Name:="Add User", ShortName:="addusr")>
	<Column(Order:=8)>
	<MaxLength(30)>
	Private _addusr As String
	Public Property addusr() As String
		Get
			Return _addusr
		End Get
		Set(ByVal value As String)
			_addusr = value
		End Set
	End Property

	<Display(Name:="Change Location", ShortName:="chgloc")>
	<Column(Order:=9)>
	<MaxLength(30)>
	Private _chgloc As String
	Public Property chgloc() As String
		Get
			Return _chgloc
		End Get
		Set(ByVal value As String)
			_chgloc = value
		End Set
	End Property

	<Display(Name:="Change Module", ShortName:="chgmod")>
	<Column(Order:=10)>
	<MaxLength(30)>
	Private _chgmod As String
	Public Property chgmod() As String
		Get
			Return _chgmod
		End Get
		Set(ByVal value As String)
			_chgmod = value
		End Set
	End Property

	<Display(Name:="Change TimeStamp", ShortName:="chgstm")>
	<Column(Order:=11)>
	Private _chgstm As DateTime
	Public Property chgstm() As DateTime
		Get
			Return _chgstm
		End Get
		Set(ByVal value As DateTime)
			_chgstm = value
		End Set
	End Property

	<Display(Name:="Change User", ShortName:="chgusr")>
	<Column(Order:=12)>
	<MaxLength(30)>
	Private _chgusr As String
	Public Property chgusr() As String
		Get
			Return _chgusr
		End Get
		Set(ByVal value As String)
			_chgusr = value
		End Set
	End Property

	<Display(Name:="Add TimeStamp", ShortName:="addstm")>
	<Column(Order:=13)>
	Private _addstm As DateTime
	Public Property addstm() As DateTime
		Get
			Return _addstm
		End Get
		Set(ByVal value As DateTime)
			_addstm = value
		End Set
	End Property

	<Display(Name:="Active (yes/no)", ShortName:="active")>
	<Column(Order:=14)>
	<MaxLength(1)>
	Private _active As String
	Public Property active() As String
		Get
			Return _active
		End Get
		Set(ByVal value As String)
			_active = value
		End Set
	End Property

	<Display(Name:="Notes", ShortName:="notes")>
	<Column(Order:=15)>
	<MaxLength(1048576)>
	Private _notes As String
	Public Property notes() As String
		Get
			Return _notes
		End Get
		Set(ByVal value As String)
			_notes = value
		End Set
	End Property


End Class
