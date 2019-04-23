Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization

Public Class PrmstsBO
    
    	<Key>
	<Display(Name:="Status Id", ShortName:="prmsts")>
	<Required(ErrorMessage:="Status Id is required.")>
	<Column(Order:=1)>
	<MaxLength(20)>
	Private _prmsts As String
	Public Property prmsts() As String
		Get
			Return _prmsts
		End Get
		Set(ByVal value As String)
			_prmsts = value
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


End Class
