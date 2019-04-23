Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Public Class PrmuserBO
    
    	<Key>
	<Display(Name:="User Id", ShortName:="prmuser")>
	<Required(ErrorMessage:="User Id is required.")>
	<Column(Order:=1)>
	<MaxLength(20)>
	Private _prmuser As String
	Public Property prmuser() As String
		Get
			Return _prmuser
		End Get
		Set(ByVal value As String)
			_prmuser = value
		End Set
	End Property

	<Display(Name:="Description", ShortName:="descr")>
	<Required(ErrorMessage:="Description is required.")>
	<Column(Order:=2)>
	<MaxLength(100)>
	Private _descr As String
	Public Property descr() As String
		Get
			Return _descr
		End Get
		Set(ByVal value As String)
			_descr = value
		End Set
	End Property

	<Display(Name:="Add Location", ShortName:="addloc")>
	<Column(Order:=3)>
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
	<Column(Order:=4)>
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

	<Display(Name:="Add TimeStamp", ShortName:="addstm")>
	<Column(Order:=5)>
	Private _addstm As DateTime
	Public Property addstm() As DateTime
		Get
			Return _addstm
		End Get
		Set(ByVal value As DateTime)
			_addstm = value
		End Set
	End Property

	<Display(Name:="Add User", ShortName:="addusr")>
	<Column(Order:=6)>
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
	<Column(Order:=7)>
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
	<Column(Order:=8)>
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
	<Column(Order:=9)>
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
	<Column(Order:=10)>
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

	<Display(Name:="Active (yes/no)", ShortName:="active")>
	<Column(Order:=11)>
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
	<Column(Order:=12)>
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
