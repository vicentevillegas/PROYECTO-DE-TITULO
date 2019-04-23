Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Public Class SecusrBO

    <Key>
    <Display(Name:="Security User", ShortName:="secusr")>
    <Required(ErrorMessage:="Security User is required.")>
    <Column(Order:=15)>
    <MaxLength(10)>
    Private _secusr As String
    Public Property secusr() As String
		Get
			Return _secusr
		End Get
		Set(ByVal value As String)
			_secusr = value
		End Set
	End Property

	<Key>
	<Display(Name:="Security Application", ShortName:="secapp")>
	<Required(ErrorMessage:="Security Application is required.")>
	<Column(Order:=12)>
	<MaxLength(20)>
	Private _secapp As String
	Public Property secapp() As String
		Get
			Return _secapp
		End Get
		Set(ByVal value As String)
			_secapp = value
		End Set
	End Property

	<Display(Name:="Active", ShortName:="active")>
	<Column(Order:=1)>
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

	<Display(Name:="Add Location", ShortName:="addloc")>
	<Column(Order:=2)>
	<MaxLength(8)>
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
	<Column(Order:=3)>
	<MaxLength(10)>
	Private _addmod As String
	Public Property addmod() As String
		Get
			Return _addmod
		End Get
		Set(ByVal value As String)
			_addmod = value
		End Set
	End Property

	<Display(Name:="Add Time Stamp", ShortName:="addstm")>
	<Column(Order:=4)>
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
	<Column(Order:=5)>
	<MaxLength(10)>
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
	<Column(Order:=6)>
	<MaxLength(8)>
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
	<Column(Order:=7)>
	<MaxLength(10)>
	Private _chgmod As String
	Public Property chgmod() As String
		Get
			Return _chgmod
		End Get
		Set(ByVal value As String)
			_chgmod = value
		End Set
	End Property

	<Display(Name:="Change Time Stamp", ShortName:="chgstm")>
	<Column(Order:=8)>
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
	<Column(Order:=9)>
	<MaxLength(10)>
	Private _chgusr As String
	Public Property chgusr() As String
		Get
			Return _chgusr
		End Get
		Set(ByVal value As String)
			_chgusr = value
		End Set
	End Property

	<Display(Name:="Email Address 01", ShortName:="email01")>
	<Column(Order:=10)>
	<MaxLength(50)>
	Private _email01 As String
	Public Property email01() As String
		Get
			Return _email01
		End Get
		Set(ByVal value As String)
			_email01 = value
		End Set
	End Property

	<Display(Name:="Email Address 02", ShortName:="email02")>
	<Column(Order:=11)>
	<MaxLength(50)>
	Private _email02 As String
	Public Property email02() As String
		Get
			Return _email02
		End Get
		Set(ByVal value As String)
			_email02 = value
		End Set
	End Property

	<Display(Name:="Security Group", ShortName:="secgrp")>
	<Required(ErrorMessage:="Security Group is required.")>
	<Column(Order:=13)>
	<MaxLength(20)>
	Private _secgrp As String
	Public Property secgrp() As String
		Get
			Return _secgrp
		End Get
		Set(ByVal value As String)
			_secgrp = value
		End Set
	End Property

	<Display(Name:="Security Name", ShortName:="secnam")>
	<Column(Order:=14)>
	<MaxLength(50)>
	Private _secnam As String
	Public Property secnam() As String
		Get
			Return _secnam
		End Get
		Set(ByVal value As String)
			_secnam = value
		End Set
	End Property

	<Display(Name:="Status Code", ShortName:="status")>
	<Column(Order:=16)>
	<MaxLength(2)>
	Private _status As String
	Public Property status() As String
		Get
			Return _status
		End Get
		Set(ByVal value As String)
			_status = value
		End Set
	End Property

	<Display(Name:="User Flag 1", ShortName:="usrfg1")>
	<Column(Order:=17)>
	<MaxLength(1)>
	Private _usrfg1 As String
	Public Property usrfg1() As String
		Get
			Return _usrfg1
		End Get
		Set(ByVal value As String)
			_usrfg1 = value
		End Set
	End Property

	<Display(Name:="User Flag 2", ShortName:="usrfg2")>
	<Column(Order:=18)>
	<MaxLength(1)>
	Private _usrfg2 As String
	Public Property usrfg2() As String
		Get
			Return _usrfg2
		End Get
		Set(ByVal value As String)
			_usrfg2 = value
		End Set
	End Property

	<Display(Name:="User Flag 3", ShortName:="usrfg3")>
	<Column(Order:=19)>
	<MaxLength(1)>
	Private _usrfg3 As String
	Public Property usrfg3() As String
		Get
			Return _usrfg3
		End Get
		Set(ByVal value As String)
			_usrfg3 = value
		End Set
	End Property

	<Display(Name:="User Flag 4", ShortName:="usrfg4")>
	<Column(Order:=20)>
	<MaxLength(1)>
	Private _usrfg4 As String
	Public Property usrfg4() As String
		Get
			Return _usrfg4
		End Get
		Set(ByVal value As String)
			_usrfg4 = value
		End Set
	End Property

	<Display(Name:="User Flag 5", ShortName:="usrfg5")>
	<Column(Order:=21)>
	<MaxLength(1)>
	Private _usrfg5 As String
	Public Property usrfg5() As String
		Get
			Return _usrfg5
		End Get
		Set(ByVal value As String)
			_usrfg5 = value
		End Set
	End Property

	<Display(Name:="Transfer Location", ShortName:="xfrloc")>
	<Column(Order:=22)>
	<MaxLength(8)>
	Private _xfrloc As String
	Public Property xfrloc() As String
		Get
			Return _xfrloc
		End Get
		Set(ByVal value As String)
			_xfrloc = value
		End Set
	End Property

End Class
